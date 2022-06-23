using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace NguyenNgocThien.Models
{
    public partial class SinhVienContext : DbContext
    {
        public SinhVienContext()
            : base("name=SinhVienContext")
        {
        }

        public virtual DbSet<DangKy> DangKy { get; set; }
        public virtual DbSet<HocPhan> HocPhan { get; set; }
        public virtual DbSet<NganhHoc> NganhHoc { get; set; }
        public virtual DbSet<SinhVien> SinhVien { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DangKy>()
                .Property(e => e.MaSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DangKy>()
                .HasMany(e => e.HocPhan)
                .WithMany(e => e.DangKy)
                .Map(m => m.ToTable("ChiTietDangKy").MapLeftKey("MaDK").MapRightKey("MaHP"));

            modelBuilder.Entity<HocPhan>()
                .Property(e => e.MaHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NganhHoc>()
                .Property(e => e.MaNganh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.Hinh)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MaNganh)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
