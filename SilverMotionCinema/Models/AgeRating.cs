using System;
using System.Collections.Generic;

namespace SilverMotionCinema.Models;

public partial class AgeRating
{
    public int AgeRatingId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
