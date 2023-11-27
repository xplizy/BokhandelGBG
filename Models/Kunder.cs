using System;
using System.Collections.Generic;

namespace BokhandelGBG.Models;

public partial class Kunder
{
    public int Id { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public string? Adress { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Ordrar> Ordrars { get; } = new List<Ordrar>();
}
