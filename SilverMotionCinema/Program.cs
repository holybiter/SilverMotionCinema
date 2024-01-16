using SilverMotionCinema.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SilverMotionCinema.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionStringIdentity = builder.Configuration.GetConnectionString("SilverMotionIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'SilverMotionIdentityContextConnection' not found.");
var connectionString = builder.Configuration.GetConnectionString("SilverMotionConnection") ?? throw new InvalidOperationException("Connection string 'SilverMotionConnection' not found.");


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SilverMotionContext>();
builder.Services.AddDbContext<SilverMotionIdentityContext>(options => options.UseSqlServer(connectionStringIdentity));
builder.Services.AddDefaultIdentity<SilverMotionUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<SilverMotionIdentityContext>();
var app = builder.Build();


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


app.Run();
