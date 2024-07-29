using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Notes.DB.Entity;

namespace Notes.DB;

public partial class NotesDbContext : DbContext
{

    public NotesDbContext()
    {
    }

    public NotesDbContext(DbContextOptions<NotesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Sticker> Stickers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-CO6H50E\\SQLEXPRESS;Initial Catalog=NotesDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.IdNote);

            entity.ToTable(tb => tb.HasTrigger("Note_Insert_Triger"));

            entity.Property(e => e.IdNote).ValueGeneratedNever();
            entity.Property(e => e.DateChange).HasColumnType("date");
            entity.Property(e => e.DateCreate).HasColumnType("date");
            entity.Property(e => e.TargetDate).HasColumnType("date");

            entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.IdOwner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notes_Users");
        });

        modelBuilder.Entity<Sticker>(entity =>
        {
            entity.HasKey(e => e.IdSticker);

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Stickers)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stickers_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.Login).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
