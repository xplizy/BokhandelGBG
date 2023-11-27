using System;
using System.Collections.Generic;

namespace BokhandelGBG.Models;

public partial class Ordrar
{
    public int Id { get; set; }

    public DateTime? Datum { get; set; }

    public int? KundId { get; set; }

    public virtual Kunder? Kund { get; set; }
}
