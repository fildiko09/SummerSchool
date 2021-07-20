using MusicWebApi.Services.Repositories;
using System;

namespace MusicWebApi.Services.UnitsOfWork
{
    public interface ISongUnitOfWork : IDisposable
    {
        ISongRepository Songs { get; }

        IAlbumRepository Albums { get; }

        int Complete();
    }
}
