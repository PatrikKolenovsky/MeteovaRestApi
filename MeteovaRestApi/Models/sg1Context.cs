using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MeteovaRestApi.Models
{
    public partial class sg1Context : DbContext
    {
        public sg1Context()
        {
        }

        public sg1Context(DbContextOptions<sg1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Comtype> Comtype { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Devicename> Devicename { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Maker> Maker { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Moduletype> Moduletype { get; set; }
        public virtual DbSet<TblMessages> TblMessages { get; set; }
        public virtual DbSet<Valint> Valint { get; set; }
        public virtual DbSet<Valreal> Valreal { get; set; }
        public virtual DbSet<Valstring> Valstring { get; set; }
        public virtual DbSet<Vardef> Vardef { get; set; }
        public virtual DbSet<Variable> Variable { get; set; }
        public virtual DbSet<Varname> Varname { get; set; }
        public virtual DbSet<Vartype> Vartype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comtype>(entity =>
            {
                entity.ToTable("comtype");

                entity.Property(e => e.ComTypeId)
                    .HasColumnName("ComTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("device");

                entity.HasIndex(e => e.ComTypeId)
                    .HasName("fk_DEVICE_COMTYPE1_idx");

                entity.HasIndex(e => e.DeviceNameId)
                    .HasName("fk_DEVICE_DEVICENAME1_idx");

                entity.Property(e => e.DeviceId)
                    .HasColumnName("DeviceID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ComServIp)
                    .IsRequired()
                    .HasColumnName("ComServIP")
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ComServPort).HasColumnType("int(11)");

                entity.Property(e => e.ComTypeId)
                    .HasColumnName("ComTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DeviceNameId)
                    .HasColumnName("DeviceNameID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Port).HasColumnType("int(11)");

                entity.HasOne(d => d.ComType)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.ComTypeId)
                    .HasConstraintName("fk_DEVICE_COMTYPE1");

                entity.HasOne(d => d.DeviceName)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.DeviceNameId)
                    .HasConstraintName("fk_DEVICE_DEVICENAME1");
            });

            modelBuilder.Entity<Devicename>(entity =>
            {
                entity.ToTable("devicename");

                entity.Property(e => e.DeviceNameId)
                    .HasColumnName("DeviceNameID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Maker>(entity =>
            {
                entity.ToTable("maker");

                entity.Property(e => e.MakerId)
                    .HasColumnName("MakerID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("module");

                entity.HasIndex(e => e.DeviceId)
                    .HasName("fk_MODULE_DEVICE1_idx");

                entity.HasIndex(e => e.LocationId)
                    .HasName("fk_MODULE_LOCATION1_idx");

                entity.HasIndex(e => e.ModuleTypeId)
                    .HasName("fk_MODULE_MODULETYPE1_idx");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("ModuleID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DeviceId)
                    .HasColumnName("DeviceID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModuleTypeId)
                    .HasColumnName("ModuleTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("fk_MODULE_DEVICE1");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("fk_MODULE_LOCATION1");

                entity.HasOne(d => d.ModuleType)
                    .WithMany(p => p.Module)
                    .HasForeignKey(d => d.ModuleTypeId)
                    .HasConstraintName("fk_MODULE_MODULETYPE1");
            });

            modelBuilder.Entity<Moduletype>(entity =>
            {
                entity.ToTable("moduletype");

                entity.HasIndex(e => e.MakerId)
                    .HasName("fk_MODULETYPE_MAKER1_idx");

                entity.Property(e => e.ModuleTypeId)
                    .HasColumnName("ModuleTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MakerId)
                    .HasColumnName("MakerID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Maker)
                    .WithMany(p => p.Moduletype)
                    .HasForeignKey(d => d.MakerId)
                    .HasConstraintName("fk_MODULETYPE_MAKER1");
            });

            modelBuilder.Entity<TblMessages>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_messages");

                entity.Property(e => e.MessageId)
                    .HasColumnName("messageID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasColumnName("clientID")
                    .HasColumnType("varchar(20)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DateTimeCreated)
                    .HasColumnName("DateTime_created")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Enable).HasDefaultValueSql("'1'");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message")
                    .HasColumnType("varchar(100)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasColumnName("topic")
                    .HasColumnType("varchar(50)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Valint>(entity =>
            {
                entity.ToTable("valint");

                entity.HasIndex(e => e.VariableId)
                    .HasName("fk_Int_Variable1_idx");

                entity.Property(e => e.ValIntId)
                    .HasColumnName("ValIntID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Time)
                    .HasColumnType("timestamp(3)")
                    .HasDefaultValueSql("'current_timestamp(3)'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Value).HasColumnType("int(11)");

                entity.Property(e => e.VariableId)
                    .HasColumnName("VariableID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Variable)
                    .WithMany(p => p.Valint)
                    .HasForeignKey(d => d.VariableId)
                    .HasConstraintName("fk_Int_Variable1");
            });

            modelBuilder.Entity<Valreal>(entity =>
            {
                entity.ToTable("valreal");

                entity.HasIndex(e => e.VariableId)
                    .HasName("fk_Real_Variable1_idx");

                entity.Property(e => e.ValRealId)
                    .HasColumnName("ValRealID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Time)
                    .HasColumnType("timestamp(3)")
                    .HasDefaultValueSql("'current_timestamp(3)'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.VariableId)
                    .HasColumnName("VariableID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Variable)
                    .WithMany(p => p.Valreal)
                    .HasForeignKey(d => d.VariableId)
                    .HasConstraintName("fk_Real_Variable1");
            });

            modelBuilder.Entity<Valstring>(entity =>
            {
                entity.ToTable("valstring");

                entity.HasIndex(e => e.VariableId)
                    .HasName("fk_VALSTRING_VARIABLE1_idx");

                entity.Property(e => e.ValStringId)
                    .HasColumnName("ValStringID")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Time)
                    .HasColumnType("timestamp(3)")
                    .HasDefaultValueSql("'current_timestamp(3)'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.VariableId)
                    .HasColumnName("VariableID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Variable)
                    .WithMany(p => p.Valstring)
                    .HasForeignKey(d => d.VariableId)
                    .HasConstraintName("fk_VALSTRING_VARIABLE1");
            });

            modelBuilder.Entity<Vardef>(entity =>
            {
                entity.ToTable("vardef");

                entity.HasIndex(e => e.ModuleTypeId)
                    .HasName("fk_VARDEF_MODULETYPE1_idx");

                entity.HasIndex(e => e.VarNameId)
                    .HasName("fk_VARDEF_VARNAME1_idx");

                entity.HasIndex(e => e.VarTypeId)
                    .HasName("fk_VARDEF_VARTYPE1_idx");

                entity.Property(e => e.VarDefId)
                    .HasColumnName("VarDefID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ModuleTypeId)
                    .HasColumnName("ModuleTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VarNameId)
                    .HasColumnName("VarNameID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VarTypeId)
                    .HasColumnName("VarTypeID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.ModuleType)
                    .WithMany(p => p.Vardef)
                    .HasForeignKey(d => d.ModuleTypeId)
                    .HasConstraintName("fk_VARDEF_MODULETYPE1");

                entity.HasOne(d => d.VarName)
                    .WithMany(p => p.Vardef)
                    .HasForeignKey(d => d.VarNameId)
                    .HasConstraintName("fk_VARDEF_VARNAME1");

                entity.HasOne(d => d.VarType)
                    .WithMany(p => p.Vardef)
                    .HasForeignKey(d => d.VarTypeId)
                    .HasConstraintName("fk_VARDEF_VARTYPE1");
            });

            modelBuilder.Entity<Variable>(entity =>
            {
                entity.ToTable("variable");

                entity.HasIndex(e => e.ModuleId)
                    .HasName("fk_VARIABLE_MODULE1_idx");

                entity.HasIndex(e => e.VarDefId)
                    .HasName("fk_VARIABLE_VARDEF1_idx");

                entity.Property(e => e.VariableId)
                    .HasColumnName("VariableID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("ModuleID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Pub)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.VarDefId)
                    .HasColumnName("VarDefID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Variable)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("fk_VARIABLE_MODULE1");

                entity.HasOne(d => d.VarDef)
                    .WithMany(p => p.Variable)
                    .HasForeignKey(d => d.VarDefId)
                    .HasConstraintName("fk_VARIABLE_VARDEF1");
            });

            modelBuilder.Entity<Varname>(entity =>
            {
                entity.ToTable("varname");

                entity.Property(e => e.VarNameId)
                    .HasColumnName("VarNameID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Vartype>(entity =>
            {
                entity.ToTable("vartype");

                entity.Property(e => e.VarTypeId)
                    .HasColumnName("VarTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
