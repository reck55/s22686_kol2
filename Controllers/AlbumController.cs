using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using s22686_kol2.DTOs;
using s22686_kol2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s22686_kol2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IRepoService _service;

        public AlbumController(IRepoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbum (int IdAlbum)
        {
            return Ok(
                await _service.GetAlbum(IdAlbum)
                .Select(e =>
                new AlbumGet
                {
                    IdAlbum = e.IdAlbum,
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    IdMusicLabel = e.IdMusicLabel,
                    Tracks = e.Tracks.Select(e => new Track
                    {
                        IdTrack = e.IdTrack,
                        TrackName = e.TrackName,
                        Duration = e.Duration
                    }).OrderBy(e => e.Duration).ToList()
                }).ToListAsync()
                );
        }
    }
}
