using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Reflections
{
    public partial class ElectionContext : DbContext
    {
        public ElectionContext()
        {
        }

        public ElectionContext(DbContextOptions<ElectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<ChiefHouseOfficer> ChiefHouseOfficer { get; set; }
        public virtual DbSet<ChiefRegionOfficer> ChiefRegionOfficer { get; set; }
        public virtual DbSet<Citizen> Citizen { get; set; }
        public virtual DbSet<CitizenFeedback> CitizenFeedback { get; set; }
        public virtual DbSet<CitizenVirtualHouse> CitizenVirtualHouse { get; set; }
        public virtual DbSet<Election> Election { get; set; }
        public virtual DbSet<Observer> Observer { get; set; }
        public virtual DbSet<ObserverFeedback> ObserverFeedback { get; set; }
        public virtual DbSet<VirtualHouse> VirtualHouse { get; set; }
        public virtual DbSet<VirtualRegion> VirtualRegion { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=pg.lnu.algotester.com;Port=47474;Database=reflections;Username=dl19;Password=LErSj88U3*FLP&fP");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("candidate");

                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");

                entity.Property(e => e.BallotNumber).HasColumnName("ballot_number");

                entity.Property(e => e.CitizenId).HasColumnName("citizen_id");

                entity.Property(e => e.ElectionId).HasColumnName("election_id");

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.Candidate)
                    .HasForeignKey(d => d.CitizenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("candidate_citizen_id_fkey");
            });

            modelBuilder.Entity<ChiefHouseOfficer>(entity =>
            {
                entity.ToTable("chief_house_officer");

                entity.Property(e => e.ChiefHouseOfficerId).HasColumnName("chief_house_officer_id");

                entity.Property(e => e.CitizenId).HasColumnName("citizen_id");

                entity.Property(e => e.ElectionId).HasColumnName("election_id");

                entity.Property(e => e.VirtualHouseId).HasColumnName("virtual_house_id");

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.ChiefHouseOfficer)
                    .HasForeignKey(d => d.CitizenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chief_house_officer_citizen");

                entity.HasOne(d => d.Election)
                    .WithMany(p => p.ChiefHouseOfficer)
                    .HasForeignKey(d => d.ElectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chief_house_officer_election");

                entity.HasOne(d => d.VirtualHouse)
                    .WithMany(p => p.ChiefHouseOfficer)
                    .HasForeignKey(d => d.VirtualHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chief_house_officer_virtual_house");
            });

            modelBuilder.Entity<ChiefRegionOfficer>(entity =>
            {
                entity.ToTable("chief_region_officer");

                entity.Property(e => e.ChiefRegionOfficerId).HasColumnName("chief_region_officer_id");

                entity.Property(e => e.CitizenId).HasColumnName("citizen_id");

                entity.Property(e => e.ElectionId).HasColumnName("election_id");

                entity.Property(e => e.VirtulRegionId).HasColumnName("virtul_region_id");

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.ChiefRegionOfficer)
                    .HasForeignKey(d => d.CitizenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chief_region_officer_citizen");

                entity.HasOne(d => d.Election)
                    .WithMany(p => p.ChiefRegionOfficer)
                    .HasForeignKey(d => d.ElectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chief_region_officer_election");

                entity.HasOne(d => d.VirtulRegion)
                    .WithMany(p => p.ChiefRegionOfficer)
                    .HasForeignKey(d => d.VirtulRegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chief_region_officer_virtual_region");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.ToTable("citizen");

                entity.Property(e => e.CitizenId).HasColumnName("citizen_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Ipn).HasColumnName("ipn");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasColumnName("patronymic")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CitizenFeedback>(entity =>
            {
                entity.ToTable("citizen_feedback");

                entity.Property(e => e.CitizenFeedbackId).HasColumnName("citizen_feedback_id");

                entity.Property(e => e.CitizenFeedbackText)
                    .HasColumnName("citizen_feedback_text")
                    .HasMaxLength(500);

                entity.Property(e => e.CitizenId).HasColumnName("citizen_id");

                entity.Property(e => e.ElectionId).HasColumnName("election_id");

                entity.Property(e => e.VirtualHouseId).HasColumnName("virtual_house_id");

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.CitizenFeedback)
                    .HasForeignKey(d => d.CitizenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_citizen_feedback_citizen");

                entity.HasOne(d => d.Election)
                    .WithMany(p => p.CitizenFeedback)
                    .HasForeignKey(d => d.ElectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_citizen_feedback_election");

                entity.HasOne(d => d.VirtualHouse)
                    .WithMany(p => p.CitizenFeedback)
                    .HasForeignKey(d => d.VirtualHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_citizen_feedback_virtual_house");
            });

            modelBuilder.Entity<CitizenVirtualHouse>(entity =>
            {
                entity.ToTable("citizen_virtual_house");

                entity.Property(e => e.CitizenVirtualHouseId).HasColumnName("citizen_virtual_house_id");

                entity.Property(e => e.CitizenId).HasColumnName("citizen_id");

                entity.Property(e => e.RegistrationTime).HasColumnName("registration_time");

                entity.Property(e => e.VirtualHouseId).HasColumnName("virtual_house_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.CitizenVirtualHouse)
                    .HasForeignKey(d => d.CitizenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("citizen_virtual_house_citizen_id_fkey");

                entity.HasOne(d => d.VirtualHouse)
                    .WithMany(p => p.CitizenVirtualHouse)
                    .HasForeignKey(d => d.VirtualHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("citizen_virtual_house_virtual_house_id_fkey");
            });

            modelBuilder.Entity<Election>(entity =>
            {
                entity.ToTable("election");

                entity.Property(e => e.ElectionId).HasColumnName("election_id");

                entity.Property(e => e.BeginningTime).HasColumnName("beginning_time");

                entity.Property(e => e.ChiefOfficerId).HasColumnName("chief_officer_id");

                entity.Property(e => e.ElectionName)
                    .IsRequired()
                    .HasColumnName("election_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ElectionYear)
                    .HasColumnName("election_year")
                    .HasColumnType("date");

                entity.Property(e => e.EndingTime).HasColumnName("ending_time");

                entity.Property(e => e.Tur).HasColumnName("tur");
            });

            modelBuilder.Entity<Observer>(entity =>
            {
                entity.ToTable("observer");

                entity.Property(e => e.ObserverId).HasColumnName("observer_id");

                entity.Property(e => e.CitizenId).HasColumnName("citizen_id");

                entity.Property(e => e.ElectionId).HasColumnName("election_id");

                entity.Property(e => e.VirtualHouseId).HasColumnName("virtual_house_id");

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.Observer)
                    .HasForeignKey(d => d.CitizenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("observer_citizen_id_fkey");
            });

            modelBuilder.Entity<ObserverFeedback>(entity =>
            {
                entity.HasKey(e => e.ObserverFeeedbackId)
                    .HasName("observer_feeedback_pkey");

                entity.ToTable("observer_feedback");

                entity.Property(e => e.ObserverFeeedbackId)
                    .HasColumnName("observer_feeedback_id")
                    .HasDefaultValueSql("nextval('observer_feeedback_observer_feeedback_id_seq'::regclass)");

                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");

                entity.Property(e => e.ElectionId).HasColumnName("election_id");

                entity.Property(e => e.FeedbackText)
                    .HasColumnName("feedback_text")
                    .HasMaxLength(500);

                entity.Property(e => e.ObserverId).HasColumnName("observer_id");

                entity.Property(e => e.VirtualHouseId).HasColumnName("virtual_house_id");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.ObserverFeedback)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("observer_feedback_candidate_id_fkey");

                entity.HasOne(d => d.Election)
                    .WithMany(p => p.ObserverFeedback)
                    .HasForeignKey(d => d.ElectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_observer_feeedback_election");

                entity.HasOne(d => d.Observer)
                    .WithMany(p => p.ObserverFeedback)
                    .HasForeignKey(d => d.ObserverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_observer_feeedback_observer");

                entity.HasOne(d => d.VirtualHouse)
                    .WithMany(p => p.ObserverFeedback)
                    .HasForeignKey(d => d.VirtualHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_observer_feeedback_virtual_house");
            });

            modelBuilder.Entity<VirtualHouse>(entity =>
            {
                entity.ToTable("virtual_house");

                entity.Property(e => e.VirtualHouseId).HasColumnName("virtual_house_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.VirtualHouseNumber).HasColumnName("virtual_house_number");

                entity.Property(e => e.VirtualRegionId).HasColumnName("virtual_region_id");
            });

            modelBuilder.Entity<VirtualRegion>(entity =>
            {
                entity.ToTable("virtual_region");

                entity.Property(e => e.VirtualRegionId).HasColumnName("virtual_region_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100);

                entity.Property(e => e.Center)
                    .IsRequired()
                    .HasColumnName("center")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.VirtualRegionNumber).HasColumnName("virtual_region_number");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.ToTable("vote");

                entity.Property(e => e.VoteId).HasColumnName("vote_id");

                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");

                entity.Property(e => e.CitizenId).HasColumnName("citizen_id");

                entity.Property(e => e.ElectionId).HasColumnName("election_id");

                entity.Property(e => e.VirtualHouseId).HasColumnName("virtual_house_id");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.Vote)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vote_candidate");

                entity.HasOne(d => d.Citizen)
                    .WithMany(p => p.Vote)
                    .HasForeignKey(d => d.CitizenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vote_citizen");

                entity.HasOne(d => d.Election)
                    .WithMany(p => p.Vote)
                    .HasForeignKey(d => d.ElectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vote_election");

                entity.HasOne(d => d.VirtualHouse)
                    .WithMany(p => p.Vote)
                    .HasForeignKey(d => d.VirtualHouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vote_virtual_house");
            });

            modelBuilder.HasSequence<int>("observer_feeedback_observer_feeedback_id_seq");
        }
    }
}
