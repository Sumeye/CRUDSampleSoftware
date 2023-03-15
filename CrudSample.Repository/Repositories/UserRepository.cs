using CrudSample.Core.Models;
using CrudSample.Core.Repositories;

namespace CrudSample.Repository.Repositories
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

    }
}

