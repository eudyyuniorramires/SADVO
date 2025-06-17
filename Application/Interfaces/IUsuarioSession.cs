using SADVO.Core.Application.ViewModels.UsuarioViewModel;

namespace SADVO.Core.Application.Interfaces
{
    public interface IUsuarioSession
    {
        UsuarioViewModel? GetUserSession();
        bool HasUser();
    }
}