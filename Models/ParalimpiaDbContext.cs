using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API250416.Models;

public partial class ParalimpiaDbContext : DbContext
{
    public ParalimpiaDbContext()
    {
    }

    public ParalimpiaDbContext(DbContextOptions<ParalimpiaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paralimpium> Paralimpia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=paralimpiadb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paralimpium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__paralimp__3213E83F29EBCDE3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
