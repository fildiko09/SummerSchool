using MusicWebApi.Context;
using MusicWebApi.Services.Repositories;
using System;

namespace MusicWebApi.Services.UnitsOfWork
{
    public class SongUnitOfWork : ISongUnitOfWork
    {
        private readonly MusicContext _context;

        public SongUnitOfWork(MusicContext context, ISongRepository songs,
            IAlbumRepository albums)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Songs = songs ?? throw new ArgumentNullException(nameof(context));
            Albums = albums ?? throw new ArgumentNullException(nameof(context));
        }

        public ISongRepository Songs { get; }

        public IAlbumRepository Albums { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
