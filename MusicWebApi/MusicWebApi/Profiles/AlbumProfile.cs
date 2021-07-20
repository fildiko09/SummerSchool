using AutoMapper;

namespace MusicWebApi.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Entities.Artist, ExternalModels.ArtistDTO>();
            CreateMap<ExternalModels.ArtistDTO, Entities.Artist>();

            CreateMap<Entities.Album, ExternalModels.AlbumDTO>();
            CreateMap<ExternalModels.AlbumDTO, Entities.Album>();
        }
    }
}
