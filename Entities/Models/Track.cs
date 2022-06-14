using System;
using System.Collections.Generic;

#nullable disable

namespace s22686_kol2.Models
{
    public partial class Track
    {
        public Track()
        {
            MusicianTracks = new HashSet<MusicianTrack>();
        }

        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public int Duration { get; set; }
        public int? IdAlbum { get; set; }

        public virtual Album IdAlbumNavigation { get; set; }
        public virtual ICollection<MusicianTrack> MusicianTracks { get; set; }
    }
}
