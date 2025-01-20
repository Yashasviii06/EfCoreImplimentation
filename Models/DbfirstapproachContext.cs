using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EfCoreImplimentation.Models;

public partial class DbfirstapproachContext : DbContext
{
    public DbfirstapproachContext()
    {
    }

    public DbfirstapproachContext(DbContextOptions<DbfirstapproachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Vehichledatum> Vehichledata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source =LAPTOP-3T7PAKLT\\YASHI; Initial Catalog = dbfirstapproach; Integrated Security = True ; MultipleActiveResultSets=True; Encrypt =False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehichledatum>(entity =>
        {
            entity.HasKey(e => e.VehId);

            entity.Property(e => e.VehId).HasColumnName("vehId");
            entity.Property(e => e.VehSerialno).HasColumnName("vehSerialno");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
