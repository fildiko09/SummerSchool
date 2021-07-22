using AutoMapper;
using MusicWebApi.Entities;
using MusicWebApi.ExternalModels;
using MusicWebApi.Services.UnitsOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MusicWebApi.Controllers
{
    [Route("album")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumUnitOfWork _albumUnit;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumUnitOfWork albumUnit,
            IMapper mapper)
        {
            _albumUnit = albumUnit ?? throw new ArgumentNullException(nameof(albumUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region Albums
        [HttpGet, Authorize]
        [Route("{id}", Name = "GetAlbum")]
        public IActionResult GetAlbum(Guid id)
        {
            var albumEntity = _albumUnit.Albums.Get(id);
            if (albumEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AlbumDTO>(albumEntity));
        }

        [HttpGet, Authorize]
        [Route("", Name = "GetAllAlbums")]
        public IActionResult GetAllAlbums()
        {
            var albumEntities = _albumUnit.Albums.Find(a => a.Deleted == false || a.Deleted == null);
            if (albumEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<AlbumDTO>>(albumEntities));
        }

        [HttpGet, Authorize]
        [Route("details/{id}", Name = "GetAlbumDetails")]
        public IActionResult GetAlbumDetails(Guid id)
        {
            var albumEntity = _albumUnit.Albums.GetAlbumDetails(id);
            if (albumEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AlbumDTO>(albumEntity));
        }

        [Route("add", Name = "Add a new album")]
        [HttpPost, Authorize]
        public IActionResult AddAlbum([FromBody] AlbumDTO album)
        {
            var albumEntity = _mapper.Map<Album>(album);
            _albumUnit.Albums.Add(albumEntity);

            _albumUnit.Complete();

            _albumUnit.Albums.Get(albumEntity.Id);

            return CreatedAtRoute("GetAlbum",
                new { id = albumEntity.Id },
                _mapper.Map<AlbumDTO>(albumEntity));
        }
        #endregion Albums

        #region Artists
        [HttpGet, Authorize]
        [Route("artist/{artistId}", Name = "GetArtist")]
        public IActionResult GetArtist(Guid artistId)
        {
            var artistEntity = _albumUnit.Artists.Get(artistId);
            if (artistEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ArtistDTO>(artistEntity));
        }

        [HttpGet, Authorize]
        [Route("artist", Name = "GetAllArtists")]
        public IActionResult GetAllArtists()
        {
            var artistEntities = _albumUnit.Artists.Find(a => a.Deleted == false || a.Deleted == null);
            if (artistEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ArtistDTO>>(artistEntities));
        }

        [Route("artist/add", Name = "Add a new artist")]
        [HttpPost, Authorize]
        public IActionResult AddArtist([FromBody] ArtistDTO artist)
        {
            var artistEntity = _mapper.Map<Artist>(artist);
            _albumUnit.Artists.Add(artistEntity);

            _albumUnit.Complete();

            _albumUnit.Artists.Get(artistEntity.Id);

            return CreatedAtRoute("GetArtist",
                new { artistId = artistEntity.Id },
                _mapper.Map<ArtistDTO>(artistEntity));
        }

        [Route("artist/{artistId}", Name = "Mark artist as deleted")]
        [HttpPut, Authorize]
        public IActionResult MarkArtistAsDeleted(Guid artistId)
        {
            var artist = _albumUnit.Artists.FindDefault(a => a.Id.Equals(artistId) && (a.Deleted == false || a.Deleted == null));
            if (artist != null)
            {
                artist.Deleted = true;
                if (_albumUnit.Complete() > 0)
                {
                    return Ok("Artist " + artistId + " was deleted.");
                }
            }
            return NotFound();
        }
        #endregion Artists

    }
}
