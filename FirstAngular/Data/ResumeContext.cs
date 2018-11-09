using Microsoft.EntityFrameworkCore;

namespace FirstAngular.Models
{
    public partial class ResumeContext : DbContext
    {
        public ResumeContext()
        {
        }

        public ResumeContext(DbContextOptions<ResumeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cert> Cert { get; set; }
        public virtual DbSet<Duty> Duty { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobDuty> JobDuty { get; set; }
        public virtual DbSet<JobLocation> JobLocation { get; set; }
        public virtual DbSet<JobManager> JobManager { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonCert> PersonCert { get; set; }
        public virtual DbSet<PersonEducation> PersonEducation { get; set; }
        public virtual DbSet<PersonJob> PersonJob { get; set; }
        public virtual DbSet<PersonLocation> PersonLocation { get; set; }
        public virtual DbSet<PersonReference> PersonReference { get; set; }
        public virtual DbSet<PersonSkill> PersonSkill { get; set; }
        public virtual DbSet<PersonUrl> PersonUrl { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Url> Url { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Resume;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cert>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Duty>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.DiplomaTypes)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Institution)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<JobDuty>(entity =>
            {
                entity.HasOne(d => d.Duty)
                    .WithMany(p => p.JobDuty)
                    .HasForeignKey(d => d.DutyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobDuty_Duty");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobDuty)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobDuty_Job");
            });

            modelBuilder.Entity<JobLocation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LocationId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobLocation)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobLocation_Job");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.JobLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobLocation_Location");
            });

            modelBuilder.Entity<JobManager>(entity =>
            {
                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobManager)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobManager_Job");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.JobManager)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobManager_Person");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CityCounty)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PersonCert>(entity =>
            {
                entity.HasOne(d => d.Cert)
                    .WithMany(p => p.PersonCert)
                    .HasForeignKey(d => d.CertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonCert_Cert");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonCert)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonCert_Person");
            });

            modelBuilder.Entity<PersonEducation>(entity =>
            {
                entity.HasOne(d => d.Education)
                    .WithMany(p => p.PersonEducation)
                    .HasForeignKey(d => d.EducationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonEducation_Education");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonEducation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonEducation_Person");
            });

            modelBuilder.Entity<PersonJob>(entity =>
            {
                entity.HasOne(d => d.Job)
                    .WithMany(p => p.PersonJob)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonJob_Job");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonJob)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonJob_Person");
            });

            modelBuilder.Entity<PersonLocation>(entity =>
            {
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.PersonLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonLocation_Location");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonLocation)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonLocation_Person");
            });

            modelBuilder.Entity<PersonReference>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonReferencePerson)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonReference_Person");

                entity.HasOne(d => d.RefPerson)
                    .WithMany(p => p.PersonReferenceRefPerson)
                    .HasForeignKey(d => d.RefPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonReference_RefPerson");
            });

            modelBuilder.Entity<PersonSkill>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonSkill)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonSkill_Person");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.PersonSkill)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonSkill_Skill");
            });

            modelBuilder.Entity<PersonUrl>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonUrl)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonUrl_Person");

                entity.HasOne(d => d.Url)
                    .WithMany(p => p.PersonUrl)
                    .HasForeignKey(d => d.UrlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonUrl_Url");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Url>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Url1)
                    .IsRequired()
                    .HasColumnName("Url")
                    .HasMaxLength(200);
            });
        }
    }
}