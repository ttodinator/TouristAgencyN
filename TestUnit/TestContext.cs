using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestUnit
{
    public class TestContext:IdentityDbContext<AppUser, AppRole, int,
                 IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
         IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Destination> Destination { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<AppUser> AspNetUsers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<DestinationRooms> DestinationRooms { get; set; }

        //private RoleManager<AppRole> roleManager
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                                            Database=TouristAgencyN");
        }

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
