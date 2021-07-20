using MusicWebApi.Context;
using MusicWebApi.Services.Repositories;
using System;

namespace MusicWebApi.Services.UnitsOfWork
{
    public class AlbumUnitOfWork : IAlbumUnitOfWork
    {
        private readonly MusicContext _context;

        public AlbumUnitOfWork(MusicContext context, IAlbumRepository albums,
            IArtistRepository artists)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Albums = albums ?? throw new ArgumentNullException(nameof(context));
            Artists = artists ?? throw new ArgumentNullException(nameof(context));
        }

        public IAlbumRepository Albums { get; }

        public IArtistRepository Artists { get; }

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
