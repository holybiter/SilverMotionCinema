using System;
using System.Collections.Generic;

namespace SilverMotionCinema.Models;

public partial class Show
{
    public int ShowId { get; set; }

    public DateTime Date { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int CinemaHallId { get; set; }

    public int MovieId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual CinemaHall CinemaHall { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<ShowSeat> ShowSeats { get; set; } = new List<ShowSeat>();
}
