using MusicWebApi.Context;
using MusicWebApi.Entities;
using System;

namespace MusicWebApi.Services.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private readonly MusicContext _context;

        public ArtistRepository(MusicContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
