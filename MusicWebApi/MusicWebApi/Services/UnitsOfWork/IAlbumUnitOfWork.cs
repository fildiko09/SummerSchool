using MusicWebApi.Services.Repositories;
using System;

namespace MusicWebApi.Services.UnitsOfWork
{
    public interface IAlbumUnitOfWork : IDisposable
    {
        IAlbumRepository Albums { get; }

        IArtistRepository Artists { get; }

        int Complete();
    }
}
