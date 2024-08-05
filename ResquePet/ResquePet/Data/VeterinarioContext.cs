using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ResquePet.Models;

namespace ResquePet.Data;

public partial class VeterinarioContext : DbContext
{

    public VeterinarioContext()
    {
    }

    public VeterinarioContext(DbContextOptions<VeterinarioContext> options)
        : base(options)
    {

    }
    public DbSet<Utente> Utente { get; set; }
    public DbSet<Animale> animale { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Veterinario;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Animale>()
            .HasOne(a => a.utente)
            .WithOne(u => u.animale)
            .HasForeignKey<Animale>(a => a.IdUtente)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
