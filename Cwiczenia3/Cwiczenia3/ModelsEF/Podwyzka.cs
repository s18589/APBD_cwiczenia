using System;
using System.Collections.Generic;

namespace Cwiczenia3.ModelsEF
{
    public partial class Podwyzka
    {
        public int Lp { get; set; }
        public int? IdOsoby { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
        public int? Mgr { get; set; }
        public int? Dzial { get; set; }
        public int? StaraPensja { get; set; }
        public int? NowaPensja { get; set; }
        public DateTime? Data { get; set; }
    }
}
