using Microsoft.EntityFrameworkCore;
namespace Hotels_app
{
    /// <summary>
    /// класс для подключения к бд
    /// </summary>
    public class ApplicationDbContext : DbContext
    {   /// <summary>
        /// DbSet для пользователей
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// DbSet для отелей
        /// </summary>
        public DbSet<Hotel> Hotels { get; set; }
        /// <summary>
        /// DbSet для лайков
        /// </summary>
        public DbSet<UserHotelLike> Likes { get; set; }
        /// <summary>
        /// DbSet для комнат
        /// </summary>
        public DbSet<Room> Rooms { get; set; }
        /// <summary>
        /// DbSet для бронирований
        /// </summary>
        public DbSet<Booking> Bookings { get; set; }
        /// <summary>
        /// DbSet для городов
        /// </summary>
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Строка подключения к PostgreSQL
            var connectionString = Properties.Resources.ConnectionString;
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserHotelLike>()
            .HasKey(uhl => new { uhl.user_id, uhl.hotel_id }); // Составной ключ
            modelBuilder.Entity<UserHotelLike>()
                .HasOne(uhl => uhl.user)
                .WithMany()
                .HasForeignKey(uhl => uhl.user_id);

            modelBuilder.Entity<UserHotelLike>()
                .HasOne(uhl => uhl.hotel)
                .WithMany()
                .HasForeignKey(uhl => uhl.hotel_id);
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.room) 
                .WithMany(r => r.bookings)
                .HasForeignKey(b => b.room_id);

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Hotel>().ToTable("hotels");
            modelBuilder.Entity<UserHotelLike>().ToTable("likes");
            modelBuilder.Entity<Room>().ToTable("rooms");
            modelBuilder.Entity<Booking>().ToTable("bookings");
            modelBuilder.Entity<City>().ToTable("cities");
        }
    }
}