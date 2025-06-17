
using Microsoft.AspNetCore.Http;
using SADVO.Core.Application.ViewModels.UsuarioViewModel;
using SADVO.Core.Application.Helpers;
using SADVO.Core.Application.Interfaces;


namespace SADVO.Middlewares
{
    public class UsuarioSession :IUsuarioSession
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public bool HasUser()
        {

            UsuarioViewModel? usuarioViewModel = _httpContextAccessor.HttpContext?
                .Session.Get<UsuarioViewModel>("Usuario");

            if (usuarioViewModel == null)
            {

                return false;
            }

            return true;

        }



        public UsuarioViewModel? GetUserSession()
        {

            UsuarioViewModel? usuarioViewModel = _httpContextAccessor.HttpContext?
                .Session.Get<UsuarioViewModel>("Usuario");

            if (usuarioViewModel == null)
            {

                return null;
            }

            return usuarioViewModel;

        }
    }
}
