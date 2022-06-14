using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s22686_kol2.DTOs
{
    public class AlbumGet
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public List<Track> Tracks { get; set; }
    }

    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public int Duration { get; set; }
    }
}
