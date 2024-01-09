using System;
using System.Collections.Generic;

namespace SilverMotionCinema;

public partial class Booking
{
    public int BookingId { get; set; }

    public int NumberOfSeats { get; set; }

    public DateTime Timestamp { get; set; }

    public int Status { get; set; }

    public int UserId { get; set; }

    public int ShowId { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Show Show { get; set; } = null!;

    public virtual ICollection<ShowSeat> ShowSeats { get; set; } = new List<ShowSeat>();

    public virtual User User { get; set; } = null!;
}
