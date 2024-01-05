using System;
using System.Collections.Generic;

namespace SilverMotionCinema.Models;

public partial class CinemaHall
{
    public int CinemaHallId { get; set; }

    public string Name { get; set; } = null!;

    public int TotalSeats { get; set; }

    public int CinemaId { get; set; }

    public virtual Cinema Cinema { get; set; } = null!;

    public virtual ICollection<CinemaSeat> CinemaSeats { get; set; } = new List<CinemaSeat>();

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
