using System;
using System.Collections.Generic;

namespace BusTicket.Models;

public partial class Sefer
{
    public int SeferId { get; set; }

    public string Guzergah { get; set; } = null!;

    public decimal TahminiSure { get; set; }

    public int OtobusId { get; set; }

    public virtual Otobu Otobus { get; set; } = null!;

    public virtual SeferYolcu? SeferYolcu { get; set; }
}
