using System;
using System.Collections.Generic;

namespace BokhandelGBG.Models;

public partial class Förlag
{
    public int Id { get; set; }

    public string? Förlagsnam { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<Böcker> Isbns { get; } = new List<Böcker>();
}
