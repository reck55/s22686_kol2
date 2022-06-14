using System;
using System.Collections.Generic;

#nullable disable

namespace s22686_kol2.Models
{
    public partial class MusicLabel
    {
        public MusicLabel()
        {
            Albums = new HashSet<Album>();
        }

        public int IdMusicLabel { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
