using System;
using System.Collections.Generic;

namespace BokhandelGBG.Models;

public partial class Butiker
{
    public int Id { get; set; }

    public string? Butiksnamn { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<LagerStatus> LagerStatuses { get; } = new List<LagerStatus>();
}
