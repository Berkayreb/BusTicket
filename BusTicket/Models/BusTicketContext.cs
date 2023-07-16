using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusTicket.Models;

public partial class BusTicketContext : DbContext
{
    public BusTicketContext()
    {
    }

    public BusTicketContext(DbContextOptions<BusTicketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Otobu> Otobus { get; set; }

    public virtual DbSet<Sefer> Sefers { get; set; }

    public virtual DbSet<SeferYolcu> SeferYolcus { get; set; }

    public virtual DbSet<Yolcu> Yolcus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BusTicket;Integrated Security=True;TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Otobu>(entity =>
        {
            entity.HasKey(e => e.OtobusId).HasName("PK__Otobus__655C002078C2C1D8");

            entity.Property(e => e.OtobusModel).HasMaxLength(100);
            entity.Property(e => e.SoforIsmi).HasMaxLength(100);
            entity.Property(e => e.Tv).HasColumnName("TV");
            entity.Property(e => e.Wc).HasColumnName("WC");
        });

        modelBuilder.Entity<Sefer>(entity =>
        {
            entity.HasKey(e => e.SeferId).HasName("PK__Sefer__B989AAF1AA57B0D5");

            entity.ToTable("Sefer");

            entity.Property(e => e.Guzergah).HasMaxLength(100);
            entity.Property(e => e.TahminiSure).HasColumnType("decimal(2, 1)");

            entity.HasOne(d => d.Otobus).WithMany(p => p.Sefers)
                .HasForeignKey(d => d.OtobusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sefer__OtobusId__3D5E1FD2");
        });

        modelBuilder.Entity<SeferYolcu>(entity =>
        {
            entity.HasKey(e => e.SeferId).HasName("PK__SeferYol__B989AAF1EA6EC19C");

            entity.ToTable("SeferYolcu");

            entity.Property(e => e.SeferId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Sefer).WithOne(p => p.SeferYolcu)
                .HasForeignKey<SeferYolcu>(d => d.SeferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SeferYolc__Sefer__3E52440B");

            entity.HasOne(d => d.Yolcu).WithMany(p => p.SeferYolcus)
                .HasForeignKey(d => d.YolcuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SeferYolc__Yolcu__3F466844");
        });

        modelBuilder.Entity<Yolcu>(entity =>
        {
            entity.HasKey(e => e.YolcuId).HasName("PK__Yolcu__04008240A77AE69E");

            entity.ToTable("Yolcu");

            entity.Property(e => e.Ad).HasMaxLength(100);
            entity.Property(e => e.Cinsiyet).HasMaxLength(10);
            entity.Property(e => e.DogumTarihi).HasColumnType("date");
            entity.Property(e => e.Soyad).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
