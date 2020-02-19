﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace asan.data.core
{
    public class InkContext : DbContext
    {
        public InkContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=tcp:asan.database.windows.net,1433;Initial Catalog=ink-dev;Persist Security Info=False;User ID=asan-admin;Password={lN*fM3D@0g*h};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }

    public class BookingDetail
    {
        [Key]
        public int Id { get; set; }
        public string Detail { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string Overview { get; set; }

        public string ArtistName { get; set; }

        public IEnumerable<BookingDetail> BookingDetails { get; set; }
    }

}
