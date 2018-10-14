using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ASPDotNetWebApplication.Models;

namespace ASPDotNetWebApplication.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Moving these into their own configuration files.
            /*modelBuilder.Entity<ItemList>()
                .Property(t => t.Name)
                .IsRequired();*/

            //modelBuilder.Configurations.Add(new ItemConfiguration());
            //modelBuilder.Configurations.Add(new ItemListConfiguration());
        }
    }
}