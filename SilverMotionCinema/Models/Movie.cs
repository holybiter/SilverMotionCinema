using System;
using System.Collections.Generic;

namespace SilverMotionCinema.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? Duration { get; set; }

    public string? Language { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Country { get; set; }

    public string? Genre { get; set; }

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
