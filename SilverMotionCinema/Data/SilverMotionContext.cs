using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SilverMotionCinema.Models;

namespace SilverMotionCinema.Data;

public partial class SilverMotionContext : DbContext
{
    public SilverMotionContext()
    {
    }

    public SilverMotionContext(DbContextOptions<SilverMotionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeRating> AgeRatings { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<CinemaHall> CinemaHalls { get; set; }

    public virtual DbSet<CinemaSeat> CinemaSeats { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<ShowSeat> ShowSeats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=SilverMotion;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgeRating>(entity =>
        {
            entity.HasKey(e => e.AgeRatingId).HasName("PK__Age_Rati__CC7BFE1EAE025F9D");

            entity.ToTable("Age_Rating");

            entity.Property(e => e.Name)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD3D0354D1");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.ShowId).HasColumnName("ShowID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Show).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ShowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__ShowID__4AB81AF0");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__UserID__49C3F6B7");
        });

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.HasKey(e => e.CinemaId).HasName("PK__Cinema__59C926262FF5E513");

            entity.ToTable("Cinema");

            entity.Property(e => e.CinemaId).HasColumnName("CinemaID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Cinemas)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cinema__CityID__3D5E1FD2");
        });

        modelBuilder.Entity<CinemaHall>(entity =>
        {
            entity.HasKey(e => e.CinemaHallId).HasName("PK__Cinema_H__D21219604F82DAE6");

            entity.ToTable("Cinema_Hall");

            entity.Property(e => e.CinemaHallId).HasColumnName("CinemaHallID");
            entity.Property(e => e.CinemaId).HasColumnName("CinemaID");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.Cinema).WithMany(p => p.CinemaHalls)
                .HasForeignKey(d => d.CinemaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cinema_Ha__Cinem__403A8C7D");
        });

        modelBuilder.Entity<CinemaSeat>(entity =>
        {
            entity.HasKey(e => e.CinemaSeatId).HasName("PK__Cinema_S__771B5FE3E066ACB8");

            entity.ToTable("Cinema_Seat");

            entity.Property(e => e.CinemaSeatId).HasColumnName("CinemaSeatID");
            entity.Property(e => e.CinemaHallId).HasColumnName("CinemaHallID");

            entity.HasOne(d => d.CinemaHall).WithMany(p => p.CinemaSeats)
                .HasForeignKey(d => d.CinemaHallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cinema_Se__Cinem__46E78A0C");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A9633E75EAA");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(16)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385057EEB552FEE");

            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__B93855ABAF6BAD34");

            entity.ToTable("Language");

            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movie__4BD2943A6AD5712A");

            entity.ToTable("Movie");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.AgeRating).HasDefaultValue(1);
            entity.Property(e => e.Country)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(512)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.LanguageId).HasDefaultValue(1);
            entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.AgeRatingNavigation).WithMany(p => p.Movies)
                .HasForeignKey(d => d.AgeRating)
                .HasConstraintName("FK__Movie__AgeRating__6383C8BA");

            entity.HasOne(d => d.Language).WithMany(p => p.Movies)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK__Movie__LanguageI__6C190EBB");

            entity.HasMany(d => d.Genres).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MovieGenre_Genre"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MovieGenre_Movie"),
                    j =>
                    {
                        j.HasKey("MovieId", "GenreId");
                        j.ToTable("MovieGenre");
                    });
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A58B90BE465");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.DiscountCouponId).HasColumnName("DiscountCouponID");
            entity.Property(e => e.RemoteTransactionId).HasColumnName("RemoteTransactionID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__Booking__52593CB8");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.HasKey(e => e.ShowId).HasName("PK__Show__6DE3E0D222C4785A");

            entity.ToTable("Show");

            entity.Property(e => e.ShowId).HasColumnName("ShowID");
            entity.Property(e => e.CinemaHallId).HasColumnName("CinemaHallID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.CinemaHall).WithMany(p => p.Shows)
                .HasForeignKey(d => d.CinemaHallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Show__CinemaHall__4316F928");

            entity.HasOne(d => d.Movie).WithMany(p => p.Shows)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Show__MovieID__440B1D61");
        });

        modelBuilder.Entity<ShowSeat>(entity =>
        {
            entity.HasKey(e => e.ShowSeatId).HasName("PK__Show_Sea__9536FCB355635266");

            entity.ToTable("Show_Seat");

            entity.Property(e => e.ShowSeatId).HasColumnName("ShowSeatID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.CinemaSeatId).HasColumnName("CinemaSeatID");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ShowId).HasColumnName("ShowID");

            entity.HasOne(d => d.Booking).WithMany(p => p.ShowSeats)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Show_Seat__Booki__4F7CD00D");

            entity.HasOne(d => d.CinemaSeat).WithMany(p => p.ShowSeats)
                .HasForeignKey(d => d.CinemaSeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Show_Seat__Cinem__4D94879B");

            entity.HasOne(d => d.Show).WithMany(p => p.ShowSeats)
                .HasForeignKey(d => d.ShowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Show_Seat__ShowI__4E88ABD4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC3F910AEF");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(16)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
