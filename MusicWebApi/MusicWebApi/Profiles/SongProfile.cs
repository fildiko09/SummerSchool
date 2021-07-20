using AutoMapper;

namespace MusicWebApi.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Entities.Album, ExternalModels.AlbumDTO>();
            CreateMap<ExternalModels.AlbumDTO, Entities.Album>();

            CreateMap<Entities.Song, ExternalModels.SongDTO>();
            CreateMap<ExternalModels.SongDTO, Entities.Song>();
        }
    }
}
