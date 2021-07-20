using MusicWebApi.Context;
using MusicWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MusicWebApi.Services.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        private readonly MusicContext _context;

        public SongRepository(MusicContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Song GetSongDetails(Guid songId)
        {
            return _context.Songs
                .Where(b => b.Id == songId && (b.Deleted == false || b.Deleted == null))
                .Include(b => b.Album)
                .FirstOrDefault();
        }
    }
}
