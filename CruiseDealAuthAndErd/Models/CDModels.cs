namespace CruiseDealAuthAndErd.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CDModels : DbContext
    {
        public CDModels()
            : base("name=CDModels")
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Cruise> Cruises { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .HasMany(e => e.Bookings)
                .WithOptional(e => e.Administrator)
                .HasForeignKey(e => e.AdminId);

            modelBuilder.Entity<Cruise>()
                .Property(e => e.Price)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Cruise>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Cruise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.CusEmail)
                .WillCascadeOnDelete(false);
        }
    }
}
