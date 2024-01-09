using System;
using System.Collections.Generic;

namespace SilverMotionCinema;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Language { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Country { get; set; }

    public string? Genre { get; set; }

    public int Duration { get; set; }

    public string AgeRating { get; set; } = null!;

    public string? Image { get; set; }

    public bool? Selected { get; set; }

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
