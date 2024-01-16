using System;
using System.Collections.Generic;

namespace SilverMotionCinema;

public partial class Language
{
    public int LanguageId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
