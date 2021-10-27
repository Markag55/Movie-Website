using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapProj_Updated_.Models
{
    public class TitleContext : DbContext
    {
        public TitleContext(DbContextOptions<TitleContext> options)
            : base(options)
        { }

        public DbSet<titleBasics> titleBasics { get; set; }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<titleBasics>().HasNoKey();
            //modelBuilder.Entity<titleBasics>().HasData(
            //    new titleBasics
            //    {
            //        tconst = null,
            //        titleType = "Movie",
            //        primaryTitle = "Shrek",
            //        originalTitle = "Shrek",
            //        isAdult = 0,
            //        startYear = 2001,
            //        endYear = null,
            //        runtimeMinutes = 120,
            //        genres = "Animation, Comedy"
            //    });
        }
    }
}