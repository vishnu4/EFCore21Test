using EFCoreTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTest.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        { }

        public virtual DbSet<Parent> Parent { get; set; }
        public virtual DbSet<ReferenceType> ReferenceType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasKey(e => e.ParentGUID)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ClusterId)
                    .IsUnique()
                    .ForSqlServerIsClustered();
                entity.Property(e => e.ClusterId)
                     .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
                
            });

            modelBuilder.Entity<ReferenceType>(entity =>
            {
                entity.HasKey(e => e.ReferenceTypeGUID)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ClusterId)
                    .IsUnique()
                    .ForSqlServerIsClustered();
                entity.Property(e => e.ClusterId)
                     .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                entity.HasMany(c => c.ParentGU)
                    .WithOne(e => e.ReferenceTypeObject)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for GUIDance on storing connection strings.
                optionsBuilder.UseSqlServer(TestDBContextFactory.cnnString);
            }
        }

    }
}
