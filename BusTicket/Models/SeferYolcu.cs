using System;
using System.Collections.Generic;

namespace BusTicket.Models;

public partial class SeferYolcu
{
    public int SeferId { get; set; }

    public int YolcuId { get; set; }

    public virtual Sefer Sefer { get; set; } = null!;

    public virtual Yolcu Yolcu { get; set; } = null!;
}
