using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.MenuItem> MenuItems { get; set; }
        public DbSet<Models.MenuOption> MenuOptions { get; set; }
        public DbSet<Models.MenuItemOption> MenuItemOptions { get; set; }
        public DbSet<Models.Table> Tables { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.MenuItemOption>()
                .HasKey(m => new { m.MenuItemId, m.MenuOptionId });

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict); // If User is deleted, keep the Invoice

        // FIX: Stop Cascade Delete for User -> InvoiceItem
            modelBuilder.Entity<InvoiceItem>()
                .HasOne(i => i.User)
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict); // If User is deleted, keep the Item

            // FIX: Stop Cascade Delete for Table -> Invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Table)
                .WithMany()
                .HasForeignKey(i => i.TableId)
                .OnDelete(DeleteBehavior.Restrict);
            var decimalProps = new[] 
                { 
                    modelBuilder.Entity<MenuItem>().Property(p => p.Price),
                    modelBuilder.Entity<MenuItem>().Property(p => p.Cost),
                    modelBuilder.Entity<MenuOption>().Property(p => p.Price),
                    modelBuilder.Entity<Invoice>().Property(p=>p.DiscountPrice),
                    modelBuilder.Entity<Invoice>().Property(p=>p.SubTotalPrice),
                    modelBuilder.Entity<Invoice>().Property(p=>p.FinalPrice),
                    modelBuilder.Entity<InvoiceItem>().Property(p=>p.Price),
                    modelBuilder.Entity<InvoiceItem>().Property(p=>p.TotalPrice),
                    modelBuilder.Entity<InvoiceItemOption>().Property(p=>p.Price),
                    modelBuilder.Entity<Customer>().Property(p=>p.Balance),
                    modelBuilder.Entity<Customer>().Property(p=>p.Debt)
                };

                foreach (var prop in decimalProps)
                {
                    prop.HasColumnType("decimal(18,2)");
                }
                    base.OnModelCreating(modelBuilder);
        }

    }
}