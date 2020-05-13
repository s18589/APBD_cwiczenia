using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class Artist
    {
        public Artist()
        {
            ArtistConcert = new HashSet<ArtistConcert>();
        }

        public int IdArtist { get; set; }
        public string Name { get; set; }
        public int Wage { get; set; }

        public virtual ICollection<ArtistConcert> ArtistConcert { get; set; }
    }
}
