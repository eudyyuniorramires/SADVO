using Microsoft.EntityFrameworkCore;
using SADVO.Core.Application.Helpers;
using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using SADVO.Infrastructure.Persistence.Context;


namespace SADVO.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExisteAsignacionParaUsuario(int id)
        {
            return await _context.DirigentePartidos.AnyAsync(a => a.UsuarioId == id);

        }

        public async Task<Usuario> LoginAsync(string UserName, string contrasena) 
        {

            string contrasenaEscrypt = PasswordEncryptation.ComputeSha25Hash(contrasena);
            Usuario? usuario = await _context.Set<Usuario>().FirstOrDefaultAsync
            (u => u.UserName == UserName && u.ContrasenaHash == contrasenaEscrypt);
            return usuario;



        }

    }
}
