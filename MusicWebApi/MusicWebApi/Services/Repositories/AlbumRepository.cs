using MusicWebApi.Context;
using MusicWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MusicWebApi.Services.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly MusicContext _context;

        public AlbumRepository(MusicContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Album GetAlbumDetails(Guid albumId)
        {
            return _context.Albums
                .Where(b => b.Id == albumId && (b.Deleted == false || b.Deleted == null))
                .Include(b => b.Artist)
                .FirstOrDefault();
        }
    }
}
