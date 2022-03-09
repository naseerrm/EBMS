using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EBMSProject.DatabaseContext
{
    public partial class GGEODEvalContext : DbContext
    {
        public GGEODEvalContext()
        {
        }

        public GGEODEvalContext(DbContextOptions<GGEODEvalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChargeMaster> ChargeMasters { get; set; } = null!;
        public virtual DbSet<ContainerType> ContainerTypes { get; set; } = null!;
        public virtual DbSet<CountryMaster> CountryMasters { get; set; } = null!;
        public virtual DbSet<CurrencyMaster> CurrencyMasters { get; set; } = null!;
        public virtual DbSet<InvoiceDtl> InvoiceDtls { get; set; } = null!;
        public virtual DbSet<InvoiceHdr> InvoiceHdrs { get; set; } = null!;
        public virtual DbSet<InvoiceTaxDtl> InvoiceTaxDtls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=ebmsngdev13.postgres.database.azure.com;Database=GGEODEval;Username=GGEODEval;Password=GG(0DEv@L");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<ChargeMaster>(entity =>
            {
                entity.HasKey(e => e.ChargeMasterAutoId)
                    .HasName("ChargeMaster_pkey");

                entity.ToTable("ChargeMaster", "Accounts");

                entity.HasIndex(e => e.UniqueId, "ChargeMaster_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.ChargeCode).HasMaxLength(10);

                entity.Property(e => e.ChargeName).HasMaxLength(70);

                entity.Property(e => e.Ngstatus)
                    .HasMaxLength(8)
                    .HasColumnName("NGStatus")
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");
            });

            modelBuilder.Entity<ContainerType>(entity =>
            {
                entity.HasKey(e => e.ContainerTypeAutoId)
                    .HasName("ContainerType_pkey");

                entity.ToTable("ContainerType", "Accounts");

                entity.HasIndex(e => e.UniqueId, "ContainerType_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.ContainerCommonName).HasMaxLength(50);

                entity.Property(e => e.ContainerTypeId).HasMaxLength(50);

                entity.Property(e => e.IsoCode).HasMaxLength(25);

                entity.Property(e => e.NewIsoCode).HasMaxLength(25);

                entity.Property(e => e.Ngstatus)
                    .HasMaxLength(8)
                    .HasColumnName("NGStatus")
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.WeightLimit).HasPrecision(28, 8);
            });

            modelBuilder.Entity<CountryMaster>(entity =>
            {
                entity.HasKey(e => e.CountryMasterAutoId)
                    .HasName("CountryMaster_pkey");

                entity.ToTable("CountryMaster", "Accounts");

                entity.HasIndex(e => e.UniqueId, "CountryMaster_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.CapitalName).HasMaxLength(30);

                entity.Property(e => e.CountryId).HasMaxLength(2);

                entity.Property(e => e.CountryName).HasMaxLength(50);

                entity.Property(e => e.IsGcc).HasColumnName("IsGCC");

                entity.Property(e => e.Iso3code)
                    .HasMaxLength(3)
                    .HasColumnName("ISO3Code");

                entity.Property(e => e.Ngstatus)
                    .HasMaxLength(8)
                    .HasColumnName("NGStatus")
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.PhonePrefix).HasMaxLength(27);

                entity.Property(e => e.StateLabel).HasMaxLength(20);

                entity.Property(e => e.TaxType).HasMaxLength(16);

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");
            });

            modelBuilder.Entity<CurrencyMaster>(entity =>
            {
                entity.HasKey(e => e.CurrencyMasterAutoId)
                    .HasName("CurrencyMaster_pkey");

                entity.ToTable("CurrencyMaster", "Accounts");

                entity.HasIndex(e => e.UniqueId, "CurrencyMaster_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.CurrencyId).HasMaxLength(50);

                entity.Property(e => e.CurrencyName).HasMaxLength(30);

                entity.Property(e => e.CurrencyStyle).HasMaxLength(20);

                entity.Property(e => e.CurrencySymbol).HasMaxLength(10);

                entity.Property(e => e.DecimalName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ngstatus)
                    .HasMaxLength(8)
                    .HasColumnName("NGStatus")
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.HasOne(d => d.CountryMasterAuto)
                    .WithMany(p => p.CurrencyMasters)
                    .HasForeignKey(d => d.CountryMasterAutoId)
                    .HasConstraintName("FK_Currency_Country");
            });

            modelBuilder.Entity<InvoiceDtl>(entity =>
            {
                entity.HasKey(e => e.InvoiceDtlAutoId)
                    .HasName("InvoiceDtl_pkey");

                entity.ToTable("InvoiceDtl", "Accounts");

                entity.HasIndex(e => e.UniqueId, "InvoiceDtl_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.BaseCurrAmountWithTax).HasPrecision(28, 8);

                entity.Property(e => e.BaseCurrencyAmt).HasPrecision(28, 8);

                entity.Property(e => e.BaseCurrencyTaxableAmt).HasPrecision(28, 8);

                entity.Property(e => e.ChargePrintDisName).HasMaxLength(500);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ExchangeRate).HasPrecision(28, 8);

                entity.Property(e => e.LastModifiedNature).HasMaxLength(64);

                entity.Property(e => e.LastUpdateDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Ngstatus)
                    .HasMaxLength(8)
                    .HasColumnName("NGStatus")
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.Qty).HasPrecision(28, 8);

                entity.Property(e => e.Rate).HasPrecision(28, 8);

                entity.Property(e => e.Saccode)
                    .HasMaxLength(20)
                    .HasColumnName("SACCode");

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.TranCurrAmountWithTax).HasPrecision(28, 8);

                entity.Property(e => e.TranCurrencyAmt).HasPrecision(28, 8);

                entity.Property(e => e.TranCurrencyTaxableAmt).HasPrecision(28, 8);

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.HasOne(d => d.ChargeMasterAuto)
                    .WithMany(p => p.InvoiceDtls)
                    .HasForeignKey(d => d.ChargeMasterAutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceDtl_ChargeMasterAutoId_fkey");

                entity.HasOne(d => d.ContainerTypeAuto)
                    .WithMany(p => p.InvoiceDtls)
                    .HasForeignKey(d => d.ContainerTypeAutoId)
                    .HasConstraintName("InvoiceDtl_ContainerTypeAutoId_fkey");

                entity.HasOne(d => d.CurrencyMasterAuto)
                    .WithMany(p => p.InvoiceDtls)
                    .HasForeignKey(d => d.CurrencyMasterAutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceDtl_CurrencyMasterAutoId_fkey");

                entity.HasOne(d => d.RefInvoiceDtlAuto)
                    .WithMany(p => p.InverseRefInvoiceDtlAuto)
                    .HasForeignKey(d => d.RefInvoiceDtlAutoId)
                    .HasConstraintName("InvoiceDtl_RefInvoiceDtlAutoId_fkey");
            });

            modelBuilder.Entity<InvoiceHdr>(entity =>
            {
                entity.HasKey(e => e.InvoiceHdrAutoId)
                    .HasName("InvoiceHdr_pkey");

                entity.ToTable("InvoiceHdr", "Accounts");

                entity.HasIndex(e => e.UniqueId, "InvoiceHdr_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.BaseCurrAmtInWords).HasMaxLength(500);

                entity.Property(e => e.BaseCurrencyAmt).HasPrecision(28, 8);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.ExternalInvDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.ExternalInvNo).HasMaxLength(50);

                entity.Property(e => e.FromDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.GeneratedId).HasMaxLength(96);

                entity.Property(e => e.Gstno)
                    .HasMaxLength(32)
                    .HasColumnName("GSTNo");

                entity.Property(e => e.GsttaxInvType)
                    .HasMaxLength(16)
                    .HasColumnName("GSTTaxInvType");

                entity.Property(e => e.InvoiceDt).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.InvoiceExchangeRate)
                    .HasPrecision(28, 8)
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InvoiceStatus).HasMaxLength(15);

                entity.Property(e => e.InvoiceTo).HasMaxLength(100);

                entity.Property(e => e.InvoiceType).HasMaxLength(16);

                entity.Property(e => e.IsLut).HasColumnName("IsLUT");

                entity.Property(e => e.Isrcmapplicable).HasColumnName("ISRCMApplicable");

                entity.Property(e => e.JobcardId).HasMaxLength(30);

                entity.Property(e => e.LastModifiedNature).HasMaxLength(64);

                entity.Property(e => e.LastUpdateDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Lutnumber)
                    .HasMaxLength(20)
                    .HasColumnName("LUTNumber");

                entity.Property(e => e.Ngstatus)
                    .HasMaxLength(8)
                    .HasColumnName("NGStatus")
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.PartyGstType).HasColumnType("character varying");

                entity.Property(e => e.RawPrefix).HasMaxLength(64);

                entity.Property(e => e.Rcmtype)
                    .HasColumnType("character varying")
                    .HasColumnName("RCMType");

                entity.Property(e => e.ReasonsForCreditNote).HasMaxLength(512);

                entity.Property(e => e.ScndCurrAmtInWords).HasMaxLength(512);

                entity.Property(e => e.ScndCurrencyAmt).HasPrecision(28, 8);

                entity.Property(e => e.SecondaryExchangeRate).HasPrecision(28, 8);

                entity.Property(e => e.Sezflag).HasColumnName("SEZFlag");

                entity.Property(e => e.Status)
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'DR'::character varying");

                entity.Property(e => e.TaxInvoiceType).HasMaxLength(16);

                entity.Property(e => e.TaxType).HasColumnType("character varying");

                entity.Property(e => e.ToDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.TranCurrAmtInWords).HasMaxLength(512);

                entity.Property(e => e.TranCurrencyAmt).HasPrecision(28, 8);

                entity.Property(e => e.Type).HasMaxLength(15);

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.HasOne(d => d.InvoiceCurrencyAuto)
                    .WithMany(p => p.InvoiceHdrInvoiceCurrencyAutos)
                    .HasForeignKey(d => d.InvoiceCurrencyAutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceCurrencyAutoId_InvoiceHdr_CurrencyMAster");

                entity.HasOne(d => d.RefInvoiceHdrAuto)
                    .WithMany(p => p.InverseRefInvoiceHdrAuto)
                    .HasForeignKey(d => d.RefInvoiceHdrAutoId)
                    .HasConstraintName("InvoiceHdr_RefInvoiceHdrAutoId_fkey");

                entity.HasOne(d => d.SecondaryCurrencyAuto)
                    .WithMany(p => p.InvoiceHdrSecondaryCurrencyAutos)
                    .HasForeignKey(d => d.SecondaryCurrencyAutoId)
                    .HasConstraintName("InvoiceHdr_SecondaryCurrencyAutoId_fkey");
            });

            modelBuilder.Entity<InvoiceTaxDtl>(entity =>
            {
                entity.HasKey(e => e.InvoiceTaxDtlAutoId)
                    .HasName("InvoiceTaxDtl_pkey");

                entity.ToTable("InvoiceTaxDtl", "Accounts");

                entity.HasIndex(e => e.UniqueId, "InvoiceTaxDtl_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.AppliedTaxRate).HasPrecision(28, 8);

                entity.Property(e => e.BaseCurrTaxAmount).HasPrecision(28, 8);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp without time zone");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.LastModifiedNature).HasMaxLength(64);

                entity.Property(e => e.LastUpdateDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Ngstatus)
                    .HasMaxLength(8)
                    .HasColumnName("NGStatus")
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.TaxType).HasMaxLength(10);

                entity.Property(e => e.TranCurrTaxAmount).HasPrecision(28, 8);

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.HasOne(d => d.ChargeMasterAuto)
                    .WithMany(p => p.InvoiceTaxDtls)
                    .HasForeignKey(d => d.ChargeMasterAutoId)
                    .HasConstraintName("InvoiceTaxDtl_ChargeMasterAutoId_fkey");

                entity.HasOne(d => d.InvoiceDtlAuto)
                    .WithMany(p => p.InvoiceTaxDtls)
                    .HasForeignKey(d => d.InvoiceDtlAutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceTaxDtl_InvoiceDtlAutoId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
