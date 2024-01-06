using System;
using System.Collections.Generic;

namespace SilverMotionCinema.Models;

public partial class City
{
    public int CityId { get; set; }

    public string Name { get; set; } = null!;

    public string State { get; set; } = null!;

    public string? ZipCode { get; set; }

    public virtual ICollection<Cinema> Cinemas { get; set; } = new List<Cinema>();
}
