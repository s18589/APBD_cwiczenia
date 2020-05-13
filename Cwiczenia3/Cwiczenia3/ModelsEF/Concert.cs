using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class Concert
    {
        public Concert()
        {
            ArtistConcert = new HashSet<ArtistConcert>();
            GuestConcert = new HashSet<GuestConcert>();
        }

        public int IdConcert { get; set; }
        public DateTime ConcertDate { get; set; }
        public int OrganizerIdOrganizer { get; set; }
        public int IdPlace { get; set; }

        public virtual Place IdPlaceNavigation { get; set; }
        public virtual Organizer OrganizerIdOrganizerNavigation { get; set; }
        public virtual ICollection<ArtistConcert> ArtistConcert { get; set; }
        public virtual ICollection<GuestConcert> GuestConcert { get; set; }
    }
}
