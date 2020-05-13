using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class Proj
    {
        public Proj()
        {
            ProjEmp = new HashSet<ProjEmp>();
        }

        public int Projno { get; set; }
        public string Pname { get; set; }
        public decimal? Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<ProjEmp> ProjEmp { get; set; }
    }
}
