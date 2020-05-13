using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class Place
    {
        public Place()
        {
            Concert = new HashSet<Concert>();
        }

        public int IdPlace { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Concert> Concert { get; set; }
    }
}
