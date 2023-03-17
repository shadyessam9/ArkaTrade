﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ArkaTrade.Models;

namespace ArkaTrade.Data
{
    public partial class arkatradeContext : DbContext
    {
        public arkatradeContext()
        {
        }

        public arkatradeContext(DbContextOptions<arkatradeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<blog> blogs { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<email> emails { get; set; }
        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<mail> mails { get; set; }
        public virtual DbSet<phone> phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<country>(entity =>
            {
                entity.HasKey(e => e.countrycode)
                    .HasName("PK__country__C704728232F5D295");

                entity.Property(e => e.countrycode).IsFixedLength();

                entity.Property(e => e.code).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}