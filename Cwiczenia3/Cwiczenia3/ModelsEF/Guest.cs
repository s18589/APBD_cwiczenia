using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class Guest
    {
        public Guest()
        {
            GuestConcert = new HashSet<GuestConcert>();
        }

        public int IdGuest { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<GuestConcert> GuestConcert { get; set; }
    }
}
