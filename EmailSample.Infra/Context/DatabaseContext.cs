using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EmailSample.Domain.Model;

namespace EmailSample.Data.Context
{
    public class DatabaseContext : DbContext
    {
        private AppConfiguration _config { get; set; }

        public DatabaseContext(AppConfiguration config)
        {
            _config= config;
        }

        public DbSet<EmailEntity> Email { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.DefaultConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmailEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.To).IsRequired();
                entity.Property(e => e.Message).IsRequired();
            });
        }
    }
}