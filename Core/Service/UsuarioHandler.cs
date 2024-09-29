using Amazon.Runtime.Internal;
using AutoMapper;
using DataAccess.Interface;
using Domain.Commonds;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace Core.Service
{
    public class UsuarioHandler : IRequestHandler<UsuarioAuthenticationRequest, BaseResponse>
    {

        private readonly IDataAccess<Users> usersAccess;
        private readonly IDataAccess<Settings> settingsAccess;
        private readonly IMapper maper;

        public UsuarioHandler(IDataAccess<Users> _usersAccess, IMapper _maper, IDataAccess<Settings> _settingsAccess)
        {
            usersAccess = _usersAccess;
            maper = _maper;
            settingsAccess = _settingsAccess;
        }

        public async Task<BaseResponse> Handle(UsuarioAuthenticationRequest request, CancellationToken cancellationToken)
        {
            BaseResponse response;

            try
            {
                if (request.Method == Method.Create)
                    response = await Create(request);
                else
                    response = await Update(request);              
                  
            }
            catch (Exception ex)
            {
                response = MapperBaseRespone(500, ex.Message);
            }

            return response;
        }

        private async Task<BaseResponse> Create(UsuarioAuthenticationRequest request)
        {
            BaseResponse response;
            try
            {
                if (request is null || string.IsNullOrEmpty(request.Contrasena))
                {
                    response = MapperBaseRespone(400, "Campos incompletos");
                    return response;
                }

                var user = maper.Map<Users>(request);
                user.Contrasena = await EncryptedPassword(request.Contrasena ?? string.Empty);
                await usersAccess.Insert(user);
                response = MapperBaseRespone(200, "Usuario creado con exito");
            }
            catch (Exception ex)
            {
                response = MapperBaseRespone(500, ex.Message);
            }
            return response;

        }

        private async Task<string> EncryptedPassword(string password)
        {
            var keyEncrypted = (await settingsAccess.GetByParam(x => x.Id.Equals(ParamConfig.KeyEncrypted.ToString())))?.Value ?? string.Empty;
            var iVEncrypted = (await settingsAccess.GetByParam(x => x.Id.Equals(ParamConfig.IVEncrypted.ToString())))?.Value ?? string.Empty;
            byte[] key = Encoding.UTF8.GetBytes(keyEncrypted);
            byte[] iv = Encoding.UTF8.GetBytes(iVEncrypted);
            using (TripleDES aes = TripleDES.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] encryptedPasswordBytes = encryptor.TransformFinalBlock(passwordBytes, 0, passwordBytes.Length);
                string encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);
                return encryptedPassword;
            }
        }

        private BaseResponse MapperBaseRespone(int status, string message)
        {
            return new BaseResponse()
            {
                statusCode = status,
                message = message
            };
        }

        private async Task<BaseResponse> Update(UsuarioAuthenticationRequest request)
        {
            BaseResponse response;
            try
            {
                if (request is null || request.Id == 0 || string.IsNullOrEmpty(request.Contrasena))
                {
                    response = MapperBaseRespone(400, "Campos incompletos");
                    return response;
                }
                var user = await GetUser(request);
                await usersAccess.Update(user);
                response = MapperBaseRespone(200, "Usuario actualizado con exito");
            }
            catch (Exception ex)
            {
                response = MapperBaseRespone(500, ex.Message);
            }
            return response;
        }

        private async Task<Users> GetUser(UsuarioAuthenticationRequest request)
        {
            var user = await usersAccess.GetById(request.Id);
            user!.Nombre = request.Nombre;
            user.Apellidos = request.Apellidos;
            user.Celular = request.Celular;
            user.Correo = request.Correo;
            user.Genero = request.Genero;
            user.Edad = request.Edad;
            user.Contrasena = await EncryptedPassword(request.Contrasena ?? string.Empty);
            return user;
        }

       

    }
}
