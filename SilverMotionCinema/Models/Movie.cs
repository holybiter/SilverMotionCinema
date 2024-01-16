using System;
using System.Collections.Generic;
using SilverMotionCinema.Models;

namespace SilverMotionCinema;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public string? Country { get; set; }

    public int Duration { get; set; }

    public string? Image { get; set; }

    public bool? Selected { get; set; }

    public int? AgeRating { get; set; }

    public int? LanguageId { get; set; }

    public virtual AgeRating? AgeRatingNavigation { get; set; }

    public virtual Language? Language { get; set; }

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
