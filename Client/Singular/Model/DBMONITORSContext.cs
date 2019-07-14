using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model
{
    public partial class DBMONITORSContext : DbContext
    {
        public DBMONITORSContext()
        {
        }

        public DBMONITORSContext(DbContextOptions<DBMONITORSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(e => e.IdMachine)
                    .HasName("PK__Machines__3C2F8914CAADF6E0");

                entity.Property(e => e.IdMachine).HasColumnName("id_machine");

                entity.Property(e => e.DsName)
                    .HasColumnName("ds_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DtDatehours)
                    .HasColumnName("dt_datehours")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.HasKey(e => e.IdPrograms)
                    .HasName("PK__Programs__DC3C5BD31DDCDC57");

                entity.Property(e => e.IdPrograms).HasColumnName("id_programs");

                entity.Property(e => e.DsName)
                    .HasColumnName("ds_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MachineId).HasColumnName("machine_id");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.Programs)
                    .HasForeignKey(d => d.MachineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_machine_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__D2D146373F99804D");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.DsFullname)
                    .HasColumnName("ds_fullname")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DsLogin)
                    .HasColumnName("ds_login")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DsPassword)
                    .HasColumnName("ds_password")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}