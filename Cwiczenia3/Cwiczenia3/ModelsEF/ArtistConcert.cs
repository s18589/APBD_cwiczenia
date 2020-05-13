using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class ArtistConcert
    {
        public int IdArtist { get; set; }
        public int IdConcert { get; set; }

        public virtual Artist IdArtistNavigation { get; set; }
        public virtual Concert IdConcertNavigation { get; set; }
    }
}
