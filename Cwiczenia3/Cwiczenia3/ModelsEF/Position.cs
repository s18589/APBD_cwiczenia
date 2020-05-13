using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class Position
    {
        public Position()
        {
            Organizer = new HashSet<Organizer>();
        }

        public int IdPosition { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Organizer> Organizer { get; set; }
    }
}
