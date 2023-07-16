using System;
using System.Collections.Generic;

namespace BusTicket.Models;

public partial class Otobu
{
    public int OtobusId { get; set; }

    public string OtobusModel { get; set; } = null!;

    public string SoforIsmi { get; set; } = null!;

    public int KoltukSayisi { get; set; }

    public bool Wc { get; set; }

    public bool Tv { get; set; }

    public virtual ICollection<Sefer> Sefers { get; set; } = new List<Sefer>();
}
