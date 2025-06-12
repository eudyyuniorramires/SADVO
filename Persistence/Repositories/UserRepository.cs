using SADVO.Core.Domain.Entities;
using SADVO.Core.Domain.Interfaces;
using SADVO.Infrastructure.Persistence.Context;


namespace SADVO.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<Usuario>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
