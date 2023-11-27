using System;
using System.Collections.Generic;

namespace BokhandelGBG.Models;

public partial class Böcker
{
    public string Isbn13 { get; set; } = null!;

    public string? Titel { get; set; }

    public string? Språk { get; set; }

    public decimal? Pris { get; set; }

    public DateTime? Utgivningsdatum { get; set; }

    public int? FörfattareId { get; set; }

    public virtual Författare? Författare { get; set; }

    public virtual ICollection<LagerStatus> LagerStatuses { get; } = new List<LagerStatus>();

    public virtual ICollection<Förlag> Förlags { get; } = new List<Förlag>();
}
