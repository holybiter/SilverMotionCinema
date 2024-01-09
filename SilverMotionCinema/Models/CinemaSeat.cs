using System;
using System.Collections.Generic;

namespace SilverMotionCinema;

public partial class CinemaSeat
{
    public int CinemaSeatId { get; set; }

    public int SeatNumber { get; set; }

    public int CinemaHallId { get; set; }

    public virtual CinemaHall CinemaHall { get; set; } = null!;

    public virtual ICollection<ShowSeat> ShowSeats { get; set; } = new List<ShowSeat>();
}
