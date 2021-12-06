using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UParkingWebAPI.Models
{
    public partial class UParkingContext : DbContext
    {
        public UParkingContext()
        {
        }

        public UParkingContext(DbContextOptions<UParkingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Pass> Passes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("data source=.;initial catalog=UParking;integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__booking__490D1AE1801F6B32");

                entity.ToTable("booking");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CarNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("car_no");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Endtime)
                    .HasColumnType("datetime")
                    .HasColumnName("endtime");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Slotno).HasColumnName("slotno");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.Starttime)
                    .HasColumnType("datetime")
                    .HasColumnName("starttime");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__booking__Id__5FB337D6");
            });

            modelBuilder.Entity<Pass>(entity =>
            {
                entity.HasKey(e => e.PassId)
                    .HasName("PK__pass__EFA330E757E00ADA");

                entity.ToTable("pass");

                entity.Property(e => e.PassId).HasColumnName("pass_id");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("booking_date");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.PassType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pass_type");

                entity.Property(e => e.Slotno).HasColumnName("slotno");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.Vechid).HasColumnName("vechid");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Passes)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__pass__Id__66603565");

                entity.HasOne(d => d.Vech)
                    .WithMany(p => p.Passes)
                    .HasForeignKey(d => d.Vechid)
                    .HasConstraintName("FK__pass__vechid__6754599E");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Payid)
                    .HasName("PK__payment__082D8EEB96B6327C");

                entity.ToTable("payment");

                entity.Property(e => e.Payid).HasColumnName("payid");

                entity.Property(e => e.Bank)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bank");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Cardnumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cardnumber");

                entity.Property(e => e.Choldername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("choldername");

                entity.Property(e => e.ExpMonth).HasColumnName("exp_month");

                entity.Property(e => e.ExpYear).HasColumnName("exp_year");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.PassId).HasColumnName("pass_id");

                entity.Property(e => e.UpiApp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("upi_app");

                entity.Property(e => e.UpiId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("upi_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__payment__book_id__6C190EBB");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__payment__Id__6B24EA82");

                entity.HasOne(d => d.Pass)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PassId)
                    .HasConstraintName("FK__payment__pass_id__6D0D32F4");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Vechid)
                    .HasName("PK__vehicle__CC39EE1CB8228F7D");

                entity.ToTable("vehicle");

                entity.Property(e => e.Vechid).HasColumnName("vechid");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Vechname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("vechname");

                entity.Property(e => e.Vechno)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("vechno");

                entity.Property(e => e.Vehcolor)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("vehcolor");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__vehicle__Id__628FA481");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
