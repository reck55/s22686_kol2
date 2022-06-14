using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace s22686_kol2.Models
{
    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<MusicLabel> MusicLabels { get; set; }
        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<MusicianTrack> MusicianTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("s22686")
                .HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.IdAlbum)
                    .HasName("Album_pk");

                entity.ToTable("Album");

                entity.Property(e => e.IdAlbum).ValueGeneratedNever();

                entity.HasOne(d => d.IdMusicLabelNavigation)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.IdMusicLabel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Album_MusicLabel");
                entity.HasData(
                    new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "pawlacz",
                        PublishDate = DateTime.Now,
                        IdMusicLabel = 1,
                    }
                );
        });

            modelBuilder.Entity<MusicLabel>(entity =>
            {
                entity.HasKey(e => e.IdMusicLabel)
                    .HasName("MusicLabel_pk");

                entity.ToTable("MusicLabel");

                entity.Property(e => e.IdMusicLabel).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.HasData(
                    new MusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "pawlacz records"
                    }
                );
            });

            modelBuilder.Entity<Musician>(entity =>
            {
                entity.HasKey(e => e.IdMusician)
                    .HasName("Musician_pk");

                entity.ToTable("Musician");

                entity.Property(e => e.IdMusician).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(20);
                entity.HasData(
                    new Musician
                    {
                        IdMusician =1,
                        FirstName = "Janusz",
                        LastName = "Pawlacz",
                        Nickname = "Papaj"
                    }
                );
            });

            modelBuilder.Entity<MusicianTrack>(entity =>
            {
                entity.HasKey(e => new { e.IdTrack, e.IdMusician })
                    .HasName("Musician_Track_pk");

                entity.ToTable("Musician_Track");

                entity.Property(e => e.IdTrack).HasColumnName("Track_IdTrack");

                entity.HasOne(d => d.IdMusicianNavigation)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(d => d.IdMusician)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Musician_Track_Musician");

                entity.HasOne(d => d.IdTrackNavigation)
                    .WithMany(p => p.MusicianTracks)
                    .HasForeignKey(d => d.IdTrack)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Musician_Track_Track");
                entity.HasData(
                    new MusicianTrack
                    {
                        IdMusician = 1,
                        IdTrack = 1
                    }
                );
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.IdTrack)
                    .HasName("Track_pk");

                entity.ToTable("Track");

                entity.Property(e => e.IdTrack).ValueGeneratedNever();

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.IdAlbum)
                    .HasConstraintName("Track_Album");
                entity.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "Bareczka",
                        Duration = 5,
                        IdAlbum = 1
                    }
                );
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
