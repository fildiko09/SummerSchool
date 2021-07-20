using MusicWebApi.Context;
using MusicWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicWebApi.Services.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MusicContext _context;

        public UserRepository(MusicContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<User> GetAdminUsers()
        {
            return _context.Users
                .Where(u => u.IsAdmin && (u.Deleted == false || u.Deleted == null))
                .ToList();
        }
    }
}
