using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class Emp
    {
        public Emp()
        {
            ProjEmp = new HashSet<ProjEmp>();
        }

        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime? Hiredate { get; set; }
        public int? Sal { get; set; }
        public int? Comm { get; set; }
        public int? Deptno { get; set; }

        public virtual Dept DeptnoNavigation { get; set; }
        public virtual ICollection<ProjEmp> ProjEmp { get; set; }
    }
}
