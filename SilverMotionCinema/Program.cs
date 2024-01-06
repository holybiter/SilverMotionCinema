using SilverMotionCinema.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var dbContext = new SilverMotionContext())
{
    var movies = dbContext.Movies.ToList();

    foreach (var movie in movies)
    {
        Console.WriteLine($"Movie Id: {movie.MovieId}, Name: {movie.Title}, Description: {movie.Description}, language: {movie.Language}, releasedate: {movie.ReleaseDate}, contry: {movie.Country} genre:{movie.Genre}, duration: {movie.Duration}, agerating: {movie.AgeRating}");
    }
}
app.Run();
