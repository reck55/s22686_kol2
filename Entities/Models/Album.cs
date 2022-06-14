using System;
using System.Collections.Generic;

#nullable disable

namespace s22686_kol2.Models
{
    public partial class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }

        public virtual MusicLabel IdMusicLabelNavigation { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
