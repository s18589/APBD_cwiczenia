using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cwiczenia3.ModelsEF
{
    public partial class s18589Context : DbContext
    {
        public s18589Context()
        {
        }

        public s18589Context(DbContextOptions<s18589Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistConcert> ArtistConcert { get; set; }
        public virtual DbSet<Budzet> Budzet { get; set; }
        public virtual DbSet<Concert> Concert { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<GuestConcert> GuestConcert { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<Organizer> Organizer { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Podwyzka> Podwyzka { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }
        public virtual DbSet<Proj> Proj { get; set; }
        public virtual DbSet<ProjEmp> ProjEmp { get; set; }
        public virtual DbSet<Salgrade> Salgrade { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.IdArtist)
                    .HasName("Artist_pk");

                entity.Property(e => e.IdArtist)
                    .HasColumnName("ID_Artist")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ArtistConcert>(entity =>
            {
                entity.HasKey(e => new { e.IdArtist, e.IdConcert })
                    .HasName("Artist_Concert_pk");

                entity.ToTable("Artist_Concert");

                entity.Property(e => e.IdArtist).HasColumnName("ID_Artist");

                entity.Property(e => e.IdConcert).HasColumnName("ID_Concert");

                entity.HasOne(d => d.IdArtistNavigation)
                    .WithMany(p => p.ArtistConcert)
                    .HasForeignKey(d => d.IdArtist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Artist_Concert_Artist");

                entity.HasOne(d => d.IdConcertNavigation)
                    .WithMany(p => p.ArtistConcert)
                    .HasForeignKey(d => d.IdConcert)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Artist_Concert_Concert");
            });

            modelBuilder.Entity<Budzet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("budzet");

                entity.Property(e => e.Wartosc).HasColumnName("wartosc");
            });

            modelBuilder.Entity<Concert>(entity =>
            {
                entity.HasKey(e => e.IdConcert)
                    .HasName("Concert_pk");

                entity.Property(e => e.IdConcert)
                    .HasColumnName("ID_Concert")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConcertDate).HasColumnType("date");

                entity.Property(e => e.IdPlace).HasColumnName("ID_Place");

                entity.Property(e => e.OrganizerIdOrganizer).HasColumnName("Organizer_ID_Organizer");

                entity.HasOne(d => d.IdPlaceNavigation)
                    .WithMany(p => p.Concert)
                    .HasForeignKey(d => d.IdPlace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Concert_Place");

                entity.HasOne(d => d.OrganizerIdOrganizerNavigation)
                    .WithMany(p => p.Concert)
                    .HasForeignKey(d => d.OrganizerIdOrganizer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Concert_Organizer");
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.Deptno)
                    .HasName("PK__DEPT__E0EB08D75F7FBD2B");

                entity.ToTable("DEPT");

                entity.Property(e => e.Deptno)
                    .HasColumnName("DEPTNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dname)
                    .HasColumnName("DNAME")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor)
                    .HasName("Doctor_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("PK__EMP__14CCF2EE439E21B6");

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");

                entity.HasOne(d => d.DeptnoNavigation)
                    .WithMany(p => p.Emp)
                    .HasForeignKey(d => d.Deptno)
                    .HasConstraintName("FK__EMP__DEPTNO__59FA5E80");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(e => e.IdGuest)
                    .HasName("Guest_pk");

                entity.Property(e => e.IdGuest)
                    .HasColumnName("ID_Guest")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GuestConcert>(entity =>
            {
                entity.HasKey(e => new { e.IdGuest, e.IdConcert })
                    .HasName("Guest_Concert_pk");

                entity.ToTable("Guest_Concert");

                entity.Property(e => e.IdGuest).HasColumnName("ID_Guest");

                entity.Property(e => e.IdConcert).HasColumnName("ID_Concert");

                entity.HasOne(d => d.IdConcertNavigation)
                    .WithMany(p => p.GuestConcert)
                    .HasForeignKey(d => d.IdConcert)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Guest_Concert_Concert");

                entity.HasOne(d => d.IdGuestNavigation)
                    .WithMany(p => p.GuestConcert)
                    .HasForeignKey(d => d.IdGuest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Guest_Concert_Guest");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament)
                    .HasName("Medicament_pk");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Organizer>(entity =>
            {
                entity.HasKey(e => e.IdOrganizer)
                    .HasName("Organizer_pk");

                entity.Property(e => e.IdOrganizer)
                    .HasColumnName("ID_Organizer")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPosition).HasColumnName("ID_Position");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.Organizer)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Organizer_Position");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("Patient_pk");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasKey(e => e.IdPlace)
                    .HasName("Place_pk");

                entity.Property(e => e.IdPlace)
                    .HasColumnName("ID_Place")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Podwyzka>(entity =>
            {
                entity.HasKey(e => e.Lp)
                    .HasName("PK__PODWYZKA__3214A50D4176E56C");

                entity.ToTable("PODWYZKA");

                entity.Property(e => e.Lp).HasColumnName("LP");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dzial).HasColumnName("DZIAL");

                entity.Property(e => e.IdOsoby).HasColumnName("ID_OSOBY");

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Nazwisko)
                    .HasColumnName("NAZWISKO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NowaPensja).HasColumnName("NOWA_PENSJA");

                entity.Property(e => e.Stanowisko)
                    .HasColumnName("STANOWISKO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaraPensja).HasColumnName("STARA_PENSJA");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.IdPosition)
                    .HasName("Position_pk");

                entity.Property(e => e.IdPosition)
                    .HasColumnName("ID_Position")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription)
                    .HasName("Prescription_pk");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.HasOne(d => d.IdDoctorNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Doctor");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Patient");
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription })
                    .HasName("Prescription_Medicament_pk");

                entity.ToTable("Prescription_Medicament");

                entity.Property(e => e.Details)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdMedicamentNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Medicament");

                entity.HasOne(d => d.IdPrescriptionNavigation)
                    .WithMany(p => p.PrescriptionMedicament)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescription_Medicament_Prescription");
            });

            modelBuilder.Entity<Proj>(entity =>
            {
                entity.HasKey(e => e.Projno)
                    .HasName("PK__PROJ__F7E30F7EF67F895E");

                entity.ToTable("PROJ");

                entity.Property(e => e.Projno).HasColumnName("PROJNO");

                entity.Property(e => e.Budget)
                    .HasColumnName("BUDGET")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.EndDate)
                    .HasColumnName("END_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Pname)
                    .HasColumnName("PNAME")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnName("START_DATE")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<ProjEmp>(entity =>
            {
                entity.HasKey(e => new { e.Projno, e.Empno })
                    .HasName("PROJ_EMP_PRIMARY_KEY");

                entity.ToTable("PROJ_EMP");

                entity.Property(e => e.Projno).HasColumnName("PROJNO");

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.ProjEmp)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMP_PROJEMP_KEY");

                entity.HasOne(d => d.ProjnoNavigation)
                    .WithMany(p => p.ProjEmp)
                    .HasForeignKey(d => d.Projno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PROJ_PROJEMP_KEY");
            });

            modelBuilder.Entity<Salgrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALGRADE");

                entity.Property(e => e.Grade).HasColumnName("GRADE");

                entity.Property(e => e.Hisal).HasColumnName("HISAL");

                entity.Property(e => e.Losal).HasColumnName("LOSAL");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
