using System;
using System.Collections.Generic;

namespace BusTicket.Models;

public partial class Yolcu
{
    public int YolcuId { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public DateTime DogumTarihi { get; set; }

    public string Cinsiyet { get; set; } = null!;

    public virtual ICollection<SeferYolcu> SeferYolcus { get; set; } = new List<SeferYolcu>();
}
