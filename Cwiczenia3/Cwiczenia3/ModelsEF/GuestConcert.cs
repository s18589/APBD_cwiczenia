using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class GuestConcert
    {
        public int IdGuest { get; set; }
        public int IdConcert { get; set; }

        public virtual Concert IdConcertNavigation { get; set; }
        public virtual Guest IdGuestNavigation { get; set; }
    }
}
