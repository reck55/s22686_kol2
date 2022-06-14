using System;
using System.Collections.Generic;

#nullable disable

namespace s22686_kol2.Models
{
    public partial class Musician
    {
        public Musician()
        {
            MusicianTracks = new HashSet<MusicianTrack>();
        }

        public int IdMusician { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<MusicianTrack> MusicianTracks { get; set; }
    }
}
