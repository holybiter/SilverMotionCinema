namespace SilverMotionCinema.Models.ViewModels
{
    public class CinemaDetailsViewModel
    {
        public Cinema SelectedCinema { get; set; }
        public List<Cinema> CinemasInCity { get; set; }
        public List<CinemaHall> CinemaHalls { get; set; }
        public List<Show> Shows { get; set; }
        public List<Movie> Movies { get; set; }
        public DateTime SelectedDate { get; set; }
    }
}
