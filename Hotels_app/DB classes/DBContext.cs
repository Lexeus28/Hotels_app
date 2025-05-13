using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
namespace Hotels_app.classes
{
    public class ApplicationDbContext : DbContext
    {
        // DbSet для каждой таблицы
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<UserHotelLike> Likes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
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
            // Настройка связи между Booking и Room
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.room) // У одного бронирования есть одна комната
                .WithMany(r => r.bookings) // У одной комнаты может быть много бронирований
                .HasForeignKey(b => b.room_id); // Внешний ключ

            // Если имена таблиц не совпадают с именами классов, можно явно указать их:
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Hotel>().ToTable("hotels");
            modelBuilder.Entity<UserHotelLike>().ToTable("likes");
            modelBuilder.Entity<Room>().ToTable("rooms");
            modelBuilder.Entity<Booking>().ToTable("bookings");
            modelBuilder.Entity<City>().ToTable("cities");

            // Автомаппинг выполняется автоматически, так как имена полей совпадают.
        }
    }
}