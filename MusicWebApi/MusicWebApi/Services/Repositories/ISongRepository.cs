using MusicWebApi.Entities;
using System;

namespace MusicWebApi.Services.Repositories
{
    public interface ISongRepository : IRepository<Song>
    {
        Song GetSongDetails(Guid songId);
    }
}
