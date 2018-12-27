using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetaWeb.Models
{
    public partial class assetaDbContext : DbContext
    {
        public assetaDbContext()
        {
        }

        public assetaDbContext(DbContextOptions<assetaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetGroupTbl> AssetGroupTbl { get; set; }
        public virtual DbSet<AssetTbl> AssetTbl { get; set; }
        public virtual DbSet<EntityTbl> EntityTbl { get; set; }
        public virtual DbSet<MaentenanceTbl> MaentenanceTbl { get; set; }
        public virtual DbSet<PeriodTbl> PeriodTbl { get; set; }
        public virtual DbSet<SiteMasterTbl> SiteMasterTbl { get; set; }
        public virtual DbSet<SparepartTbl> SparepartTbl { get; set; }
        public virtual DbSet<SupplierTbl> SupplierTbl { get; set; }
        public virtual DbSet<TaskLineTbl> TaskLineTbl { get; set; }
        public virtual DbSet<TaskTbl> TaskTbl { get; set; }
        public virtual DbSet<TechnicianTbl> TechnicianTbl { get; set; }
        public virtual DbSet<WoExceTbl> WoExceTbl { get; set; }
        public virtual DbSet<WorkOrderTbl> WorkOrderTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ced-dev.chrvl2iyzlxm.ap-southeast-1.rds.amazonaws.com;Database=assetaDb;Trusted_Connection=False;User ID= wmotion;Password= Wm0t!0n12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetGroupTbl>(entity =>
            {
                entity.HasKey(e => e.AssetGroupId);

                entity.Property(e => e.AssetGroupCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetGroupName).HasColumnType("text");

                entity.Property(e => e.CreatedAtAssetGroup).HasColumnType("datetime");

                entity.Property(e => e.ModifyAtAssetGroup).HasColumnType("datetime");
            });

            modelBuilder.Entity<AssetTbl>(entity =>
            {
                entity.HasKey(e => e.AssetId);

                entity.Property(e => e.AssetCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAtAsset).HasColumnType("datetime");

                entity.Property(e => e.Location).HasColumnType("text");

                entity.Property(e => e.ModifyAtAsset).HasColumnType("datetime");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityDate).HasColumnType("datetime");

                entity.Property(e => e.Valuation).HasColumnType("text");
            });

            modelBuilder.Entity<EntityTbl>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.CompanyName).HasColumnType("text");

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAtEntity).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntityName).HasColumnType("text");

                entity.Property(e => e.ModifyAtEntity).HasColumnType("datetime");

                entity.Property(e => e.ModifyBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pic)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MaentenanceTbl>(entity =>
            {
                entity.HasKey(e => e.MaentenanceId);

                entity.Property(e => e.CostMaentenance).HasColumnType("money");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastDate).HasColumnType("datetime");

                entity.Property(e => e.MaentenanceCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaentenanceDesc).HasColumnType("text");

                entity.Property(e => e.ModifyAt).HasColumnType("datetime");

                entity.Property(e => e.ModifyBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NextDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PeriodTbl>(entity =>
            {
                entity.HasKey(e => e.PeriodId);

                entity.Property(e => e.CreatedAtPeriod).HasColumnType("datetime");

                entity.Property(e => e.ModifyAtPeriod).HasColumnType("datetime");

                entity.Property(e => e.PeriodType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SiteMasterTbl>(entity =>
            {
                entity.HasKey(e => e.SiteId);

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.CreatedAtSite).HasColumnType("datetime");

                entity.Property(e => e.ModifyAtSite).HasColumnType("datetime");

                entity.Property(e => e.SiteCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).HasColumnType("text");
            });

            modelBuilder.Entity<SparepartTbl>(entity =>
            {
                entity.HasKey(e => e.SparepartId);

                entity.Property(e => e.CreatedAtSupp).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyAtSupp).HasColumnType("datetime");

                entity.Property(e => e.ModifyBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SparepartCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SparepartDesc).HasColumnType("text");

                entity.Property(e => e.UoM)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SupplierTbl>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAtSupplier).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ModifyAtSupplier).HasColumnType("datetime");

                entity.Property(e => e.ProductData).HasColumnType("text");

                entity.Property(e => e.SupplierCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaskLineTbl>(entity =>
            {
                entity.Property(e => e.TaskCode).HasMaxLength(50);

                entity.Property(e => e.TaskType).HasMaxLength(25);
            });

            modelBuilder.Entity<TaskTbl>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.CreatedAtTask).HasColumnType("datetime");

                entity.Property(e => e.ModifyAtTask).HasColumnType("datetime");

                entity.Property(e => e.TaskCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaskDetail).HasColumnType("text");
            });

            modelBuilder.Entity<TechnicianTbl>(entity =>
            {
                entity.HasKey(e => e.TechnicianId);

                entity.Property(e => e.CreatedAtTech).HasColumnType("datetime");

                entity.Property(e => e.ModifyAtTech).HasColumnType("datetime");

                entity.Property(e => e.TechnicianName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WoExceTbl>(entity =>
            {
                entity.HasKey(e => e.WoExeId);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkOrderTbl>(entity =>
            {
                entity.HasKey(e => e.WoId);

                entity.Property(e => e.CreatedAtWo).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ModifyAtWo).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.Priority)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WoDesc).HasColumnType("text");
            });
        }
    }
}
