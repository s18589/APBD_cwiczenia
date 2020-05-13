using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class Organizer
    {
        public Organizer()
        {
            Concert = new HashSet<Concert>();
        }

        public int IdOrganizer { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdPosition { get; set; }

        public virtual Position IdPositionNavigation { get; set; }
        public virtual ICollection<Concert> Concert { get; set; }
    }
}
