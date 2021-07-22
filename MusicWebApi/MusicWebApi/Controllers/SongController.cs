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
    [Route("song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongUnitOfWork _songUnit;
        private readonly IMapper _mapper;

        public SongController(ISongUnitOfWork songUnit,
            IMapper mapper)
        {
            _songUnit = songUnit ?? throw new ArgumentNullException(nameof(songUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region Songs
        [HttpGet, Authorize]
        [Route("{id}", Name = "GetSong")]
        public IActionResult GetSong(Guid id)
        {
            var songEntity = _songUnit.Songs.Get(id);
            if (songEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SongDTO>(songEntity));
        }

        [HttpGet, Authorize]
        [Route("", Name = "GetAllSongs")]
        public IActionResult GetAllSongs()
        {
            var songEntities = _songUnit.Songs.Find(a => a.Deleted == false || a.Deleted == null);
            if (songEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<SongDTO>>(songEntities));
        }

        [HttpGet, Authorize]
        [Route("details/{id}", Name = "GetSongDetails")]
        public IActionResult GetSongDetails(Guid id)
        {
            var songEntity = _songUnit.Songs.GetSongDetails(id);
            if (songEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SongDTO>(songEntity));
        }

        [Route("add", Name = "Add a new song")]
        [HttpPost, Authorize]
        public IActionResult AddSong([FromBody] SongDTO album)
        {
            var songEntity = _mapper.Map<Song>(album);
            _songUnit.Songs.Add(songEntity);

            _songUnit.Complete();

            _songUnit.Songs.Get(songEntity.Id);

            return CreatedAtRoute("GetSong",
                new { id = songEntity.Id },
                _mapper.Map<SongDTO>(songEntity));
        }
        #endregion Songs
    }
}
