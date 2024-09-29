using AutoMapper;
using DataAccess.Interface;
using Domain.Commonds;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationRequestMethod, AuthenticationResponse>
    {
        private readonly IDataAccess<Users> usersAccess;
        private readonly IDataAccess<Settings> settingsAccess;
        private readonly IMapper maper;
        public AuthenticationHandler(IDataAccess<Users> _usersAccess, IDataAccess<Settings> _settingsAccess, IMapper _maper)
        {
            usersAccess = _usersAccess;
            settingsAccess = _settingsAccess;
            maper = _maper; 
        }

        public async Task<AuthenticationResponse> Handle(AuthenticationRequestMethod request, CancellationToken cancellationToken)
        {
            AuthenticationResponse response;
            try
            {


                if (request.Method == Method.Create)
                    response = await CreateToken(request);
                else
                    response = await GetUserByEmail(request.Correo);
            }
            catch (Exception ex)
            {
                response = MapperBaseRespone(500, ex.Message);
            }
            return response;
        }

        private  async Task<AuthenticationResponse> CreateToken(AuthenticationRequestMethod request)
        {

            AuthenticationResponse response;
            var resultValidation = await ValidateCredentials(request.Correo, request.Password);

            if (!resultValidation.Item1)
            {
                response = MapperBaseRespone(401, resultValidation.Item2);
                return response;
            }

            response = MapperBaseRespone(200, resultValidation.Item2);
            response.Result = await GenerateToken(request.Correo);
            return response;
        }

        private async Task<(bool, string)> ValidateCredentials(string? email, string? password)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var user = await usersAccess.GetByParam(x => x.Correo!.Equals(email));
                if (user is not null && await ValidatePassword(password, user.Contrasena))
                    return (true, "");

                return (false, "El correo y/o  contraseña incorrectos");
            }
            return (false, "El correo no puede  ser nulo o estar en blanco");
        }

        public async Task<bool> ValidatePassword(string? password, string? encryptedPassword)
        {

            var keyEncrypted = (await settingsAccess.GetByParam(x => x.Id.Equals(ParamConfig.KeyEncrypted.ToString())))?.Value ?? string.Empty;
            var iVEncrypted = (await settingsAccess.GetByParam(x => x.Id.Equals(ParamConfig.IVEncrypted.ToString())))?.Value ?? string.Empty;
            byte[] key = Encoding.UTF8.GetBytes(keyEncrypted);
            byte[] iv = Encoding.UTF8.GetBytes(iVEncrypted);
            using (TripleDES aes = TripleDES.Create())
            {

                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                byte[] decryptedPasswordBytes = decryptor.TransformFinalBlock(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);
                string decryptedPassword = Encoding.UTF8.GetString(decryptedPasswordBytes);
                return decryptedPassword == password;
            }
        }

        private async Task<string> GenerateToken(string? userName)
        {
            var secretKey = (await settingsAccess.GetByParam(x => x.Id.Equals(ParamConfig.JwtSecretKey.ToString())))?.Value ?? string.Empty;
            var jwtIssuerToken = (await settingsAccess.GetByParam(x => x.Id.Equals(ParamConfig.JwtIssuerToken.ToString())))?.Value ?? string.Empty;
            var jwtAudienceToken = (await settingsAccess.GetByParam(x => x.Id.Equals(ParamConfig.JwtIssuerToken.ToString())))?.Value ?? string.Empty;
            var jwtExpireTime = (await settingsAccess.GetByParam(x => x.Id.Equals(ParamConfig.JwtExpireTime.ToString())))?.Value ?? string.Empty;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            ClaimsIdentity claimsIdentity = new(new[] { new Claim(ClaimTypes.Name, userName) });
            var currentDate = DateTime.Now;
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: jwtAudienceToken,
                issuer: jwtIssuerToken,
                subject: claimsIdentity,
                notBefore: currentDate,
                expires: currentDate.AddMinutes(Convert.ToInt32(jwtExpireTime)),
                signingCredentials: signingCredentials);
            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        private AuthenticationResponse MapperBaseRespone(int status, string message)
        {
            return new AuthenticationResponse()
            {
                statusCode = status,
                message = message

            };
        }

        public async Task<AuthenticationResponse> GetUserByEmail(string? email)
        {
            AuthenticationResponse response;
            UserResponse userResponse;
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var user = await usersAccess.GetByParam(x => x.Correo!.Equals(email));
                    userResponse = maper.Map<UserResponse>(user);
                    response = userResponse is not null ? MapperBaseRespone(200, "Encontrado") : MapperBaseRespone(404, "Correo no encontrado");
                    response.Result = userResponse;
                    return response;
                }
                response = MapperBaseRespone(400, "Campos incompletos");
            }
            catch (Exception ex)
            {
                response = MapperBaseRespone(500, ex.Message);
            }
            return response;

        }

    }
}
