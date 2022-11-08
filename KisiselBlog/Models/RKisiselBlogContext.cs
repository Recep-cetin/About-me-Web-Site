using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KisiselBlog.Models
{
    public partial class RKisiselBlogContext : DbContext
    {
        public RKisiselBlogContext()
        {
        }

        public RKisiselBlogContext(DbContextOptions<RKisiselBlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Iletisim> Iletisims { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }
        public virtual DbSet<Menuler> Menulers { get; set; }
        public virtual DbSet<Sayfalar> Sayfalars { get; set; }
        public virtual DbSet<Yorumlar> Yorumlars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=RKisiselBlog;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Iletisim>(entity =>
            {
                entity.ToTable("iletisim");

                entity.Property(e => e.IletisimId).HasColumnName("iletisimID");

                entity.Property(e => e.Adres)
                    .HasMaxLength(400)
                    .HasColumnName("adres");

                entity.Property(e => e.Aktif).HasColumnName("aktif");

                entity.Property(e => e.Eklenmetarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("eklenmetarihi");

                entity.Property(e => e.KulaniciId).HasColumnName("kulaniciID");

                entity.Property(e => e.Silindi).HasColumnName("silindi");

                entity.HasOne(d => d.Kulanici)
                    .WithMany(p => p.Iletisims)
                    .HasForeignKey(d => d.KulaniciId)
                    .HasConstraintName("FK__iletisim__kulani__2E1BDC42");
            });

            modelBuilder.Entity<Kullanicilar>(entity =>
            {
                entity.HasKey(e => e.KulaniciId)
                    .HasName("PK__kullanic__A9B486E0230CE9F9");

                entity.ToTable("kullanicilar");

                entity.Property(e => e.KulaniciId).HasColumnName("kulaniciID");

                entity.Property(e => e.Adi)
                    .HasMaxLength(100)
                    .HasColumnName("adi");

                entity.Property(e => e.Aktif).HasColumnName("aktif");

                entity.Property(e => e.Eposta)
                    .HasMaxLength(100)
                    .HasColumnName("eposta");

                entity.Property(e => e.Parola)
                    .HasMaxLength(35)
                    .HasColumnName("parola");

                entity.Property(e => e.Silindi).HasColumnName("silindi");

                entity.Property(e => e.Soyadi)
                    .HasMaxLength(100)
                    .HasColumnName("soyadi");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(15)
                    .HasColumnName("telefon");

                entity.Property(e => e.Yetki).HasColumnName("yetki");
            });

            modelBuilder.Entity<Menuler>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK__menuler__3B407E9431A934FA");

                entity.ToTable("menuler");

                entity.Property(e => e.MenuId).HasColumnName("menuID");

                entity.Property(e => e.Aktif).HasColumnName("aktif");

                entity.Property(e => e.Baslik)
                    .HasMaxLength(250)
                    .HasColumnName("baslik");

                entity.Property(e => e.Silindi).HasColumnName("silindi");

                entity.Property(e => e.Sira).HasColumnName("sira");

                entity.Property(e => e.Url)
                    .HasMaxLength(250)
                    .HasColumnName("url");

                entity.Property(e => e.UstId).HasColumnName("ustId");
            });

            modelBuilder.Entity<Sayfalar>(entity =>
            {
                entity.HasKey(e => e.SayfaId)
                    .HasName("PK__sayfalar__F81FC2B280109264");

                entity.ToTable("sayfalar");

                entity.Property(e => e.SayfaId).HasColumnName("sayfaID");

                entity.Property(e => e.Aktif).HasColumnName("aktif");

                entity.Property(e => e.Baslik)
                    .HasMaxLength(250)
                    .HasColumnName("baslik");

                entity.Property(e => e.Icerik)
                    .HasColumnType("ntext")
                    .HasColumnName("icerik");

                entity.Property(e => e.Silindi).HasColumnName("silindi");
            });

            modelBuilder.Entity<Yorumlar>(entity =>
            {
                entity.HasKey(e => e.YorumId)
                    .HasName("PK__yorumlar__222191BFC2F7E52A");

                entity.ToTable("yorumlar");

                entity.Property(e => e.YorumId).HasColumnName("yorumID");

                entity.Property(e => e.Aktif).HasColumnName("aktif");

                entity.Property(e => e.Eklenmetarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("eklenmetarihi");

                entity.Property(e => e.KulaniciId).HasColumnName("kulaniciID");

                entity.Property(e => e.SayfaId).HasColumnName("sayfaID");

                entity.Property(e => e.Silindi).HasColumnName("silindi");

                entity.Property(e => e.Yorum)
                    .HasMaxLength(400)
                    .HasColumnName("yorum");

                entity.HasOne(d => d.Kulanici)
                    .WithMany(p => p.Yorumlars)
                    .HasForeignKey(d => d.KulaniciId)
                    .HasConstraintName("FK__yorumlar__kulani__2B3F6F97");

                entity.HasOne(d => d.Sayfa)
                    .WithMany(p => p.Yorumlars)
                    .HasForeignKey(d => d.SayfaId)
                    .HasConstraintName("FK__yorumlar__sayfaI__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
