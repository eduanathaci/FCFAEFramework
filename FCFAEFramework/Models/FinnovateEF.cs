using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FCFAEFramework.Models
{
    public class FinnovateEF:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Consent> Consents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .Property(t => t.ServiceName)
                .HasMaxLength(100);

            modelBuilder.Entity<Service>()
                .Property(t => t.Banner)
                .HasMaxLength(255);

            modelBuilder.Entity<Company>()
                .Property(t => t.Name).HasMaxLength(100);
            modelBuilder.Entity<Company>()
               .Property(t => t.Password).HasMaxLength(100);
            modelBuilder.Entity<Company>()
               .Property(t => t.Email).HasMaxLength(255);
            modelBuilder.Entity<Company>()
               .Property(t => t.PhoneNo).HasMaxLength(20);
            modelBuilder.Entity<Company>()
               .Property(t => t.Address).HasMaxLength(255);


            modelBuilder.Entity<Client>()
                .Property(t => t.Name).HasMaxLength(100);
            modelBuilder.Entity<Client>()
               .Property(t => t.Password).HasMaxLength(100);
            modelBuilder.Entity<Client>()
               .Property(t => t.Email).HasMaxLength(255);
            modelBuilder.Entity<Client>()
               .Property(t => t.Surname).HasMaxLength(255);

            modelBuilder.Entity<Client>()
              .Property(t => t.PhoneNo).HasMaxLength(20);
            modelBuilder.Entity<Client>()
               .Property(t => t.Address).HasMaxLength(255);
            modelBuilder.Entity<Client>()
              .Property(t => t.Gender).HasMaxLength(1);


            modelBuilder.Entity<Data>()
             .Property(t => t.NameOfData).HasMaxLength(100);
            modelBuilder.Entity<Data>()
             .Property(t => t.TypeOfData).HasMaxLength(100);

            modelBuilder.Entity<Consent>()
                .Property(t => t.ID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);



        }
    }
}