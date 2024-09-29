namespace ApiAppHealth.Middlewares
{
    /// <summary>
    /// Middleware de comprobacion del token
    /// </summary>
    public class JwtMiddleware
    {
        private readonly RequestDelegate requestDelegate;


        /// <summary>
        /// Constructor
        /// </summary>
        public JwtMiddleware(RequestDelegate requestDelegat)
        {
            this.requestDelegate = requestDelegat;

        }

        /// <summary>
        /// Metodo para validar el token
        /// </summary>

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token is not null && ! string.IsNullOrEmpty(token))
            {
                context.Items["UserId"] = "Usuario valido";
            }
            await requestDelegate(context);
        }
    }
}
