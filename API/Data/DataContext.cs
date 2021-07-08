using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    /// <summary>
    /// Klasa koja sluzi za pristup podacima smesteni u bazi
    /// </summary>
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
                 IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
         IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        /// <summary>
        /// Destination tabela u bazi podataka
        /// </summary>
        public DbSet<Destination> Destination { get; set; }
        /// <summary>
        /// Reservation tabela u bazi podataka
        /// </summary>
        public DbSet<Reservation> Reservations { get; set; }
        /// <summary>
        /// Likes tabela u bazi podataka
        /// </summary>
        public DbSet<Like> Likes { get; set; }
        /// <summary>
        /// DestinationRooms tabela u bazi
        /// </summary>
        public DbSet<DestinationRooms> DestinationRooms { get; set; }

        //private RoleManager<AppRole> roleManager
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
        /// Metoda koja sluzi za konfigurisanje context klase
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DestinationRooms>().HasKey(dr => new { dr.DestinationId, dr.RoomId });

            builder.Entity<DestinationRooms>().HasOne(dr => dr.Destination)
                .WithMany(d => d.Rooms)
                .HasForeignKey(dr => dr.DestinationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<DestinationRooms>().HasOne(dr => dr.Room)
                .WithMany(d => d.Rooms)
                .HasForeignKey(dr => dr.RoomId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Like>().HasKey(l => new { l.AppUserId, l.DestinationId });

            builder.Entity<Like>().HasOne(l => l.AppUser)
                 .WithMany(u => u.Likes)
                 .HasForeignKey(l => l.AppUserId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Like>().HasOne(l => l.Destination)
     .WithMany(u => u.Likes)
                .HasForeignKey(l => l.DestinationId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<Reservation>()
                .HasOne(u => u.User)
                .WithMany(ap => ap.Reservations)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Reservation>()
                .HasOne(d => d.Destination).
                WithMany(des => des.Reservations)
                .OnDelete(DeleteBehavior.Restrict);





        }
    }
}
