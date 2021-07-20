using MusicWebApi.Entities;
using System.Collections.Generic;

namespace MusicWebApi.Services.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAdminUsers();
    }
}
