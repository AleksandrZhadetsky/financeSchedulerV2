﻿using Domain.Entities.Categories;
using Domain.Entities.Purchases;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbContext
{
    public class AuthDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<AppUser>()
            //     .HasMany(u => u.Purchases)
            //     .WithOne(p => p.AppUser)
            //     .HasForeignKey(p => p.AppUserId)
            //     .HasPrincipalKey(u => u.Id)
            //     .HasConstraintName("one2many");

            modelBuilder.Entity<Purchase>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(x => new { x.LoginProvider, x.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
        }
    }
}
