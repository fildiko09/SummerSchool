using MusicWebApi.Entities;
using System;

namespace MusicWebApi.Services.Repositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Album GetAlbumDetails(Guid albumId);
    }
}
