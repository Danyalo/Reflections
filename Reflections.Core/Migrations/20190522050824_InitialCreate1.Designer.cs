﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Reflections;

namespace Reflections.Core.Migrations
{
    [DbContext(typeof(ElectionContext))]
    [Migration("20190522050824_InitialCreate1")]
    partial class InitialCreate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:.observer_feeedback_observer_feeedback_id_seq", "'observer_feeedback_observer_feeedback_id_seq', '', '1', '1', '', '', 'Int32', 'False'");

            modelBuilder.Entity("Reflections.Candidate", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("candidate_id");

                    b.Property<int>("BallotNumber")
                        .HasColumnName("ballot_number");

                    b.Property<int>("CitizenId")
                        .HasColumnName("citizen_id");

                    b.Property<int>("ElectionId")
                        .HasColumnName("election_id");

                    b.HasKey("CandidateId");

                    b.HasIndex("CitizenId");

                    b.ToTable("candidate");
                });

            modelBuilder.Entity("Reflections.ChiefHouseOfficer", b =>
                {
                    b.Property<int>("ChiefHouseOfficerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("chief_house_officer_id");

                    b.Property<int>("CitizenId")
                        .HasColumnName("citizen_id");

                    b.Property<int>("ElectionId")
                        .HasColumnName("election_id");

                    b.Property<int>("VirtualHouseId")
                        .HasColumnName("virtual_house_id");

                    b.HasKey("ChiefHouseOfficerId");

                    b.HasIndex("CitizenId");

                    b.HasIndex("ElectionId");

                    b.HasIndex("VirtualHouseId");

                    b.ToTable("chief_house_officer");
                });

            modelBuilder.Entity("Reflections.ChiefRegionOfficer", b =>
                {
                    b.Property<int>("ChiefRegionOfficerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("chief_region_officer_id");

                    b.Property<int>("CitizenId")
                        .HasColumnName("citizen_id");

                    b.Property<int>("ElectionId")
                        .HasColumnName("election_id");

                    b.Property<int>("VirtulRegionId")
                        .HasColumnName("virtul_region_id");

                    b.HasKey("ChiefRegionOfficerId");

                    b.HasIndex("CitizenId");

                    b.HasIndex("ElectionId");

                    b.HasIndex("VirtulRegionId");

                    b.ToTable("chief_region_officer");
                });

            modelBuilder.Entity("Reflections.Citizen", b =>
                {
                    b.Property<int>("CitizenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("citizen_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(100);

                    b.Property<int>("Ipn")
                        .HasColumnName("ipn");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(100);

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnName("patronymic")
                        .HasMaxLength(100);

                    b.HasKey("CitizenId");

                    b.ToTable("citizen");
                });

            modelBuilder.Entity("Reflections.CitizenFeedback", b =>
                {
                    b.Property<int>("CitizenFeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("citizen_feedback_id");

                    b.Property<string>("CitizenFeedbackText")
                        .HasColumnName("citizen_feedback_text")
                        .HasMaxLength(500);

                    b.Property<int>("CitizenId")
                        .HasColumnName("citizen_id");

                    b.Property<int>("ElectionId")
                        .HasColumnName("election_id");

                    b.Property<int>("VirtualHouseId")
                        .HasColumnName("virtual_house_id");

                    b.HasKey("CitizenFeedbackId");

                    b.HasIndex("CitizenId");

                    b.HasIndex("ElectionId");

                    b.HasIndex("VirtualHouseId");

                    b.ToTable("citizen_feedback");
                });

            modelBuilder.Entity("Reflections.CitizenVirtualHouse", b =>
                {
                    b.Property<int>("CitizenVirtualHouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("citizen_virtual_house_id");

                    b.Property<int>("CitizenId")
                        .HasColumnName("citizen_id");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnName("registration_time");

                    b.Property<int>("VirtualHouseId")
                        .HasColumnName("virtual_house_id");

                    b.HasKey("CitizenVirtualHouseId");

                    b.HasIndex("CitizenId");

                    b.HasIndex("VirtualHouseId");

                    b.ToTable("citizen_virtual_house");
                });

            modelBuilder.Entity("Reflections.Election", b =>
                {
                    b.Property<int>("ElectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("election_id");

                    b.Property<DateTime>("BeginningTime")
                        .HasColumnName("beginning_time");

                    b.Property<int>("ChiefOfficerId")
                        .HasColumnName("chief_officer_id");

                    b.Property<string>("ElectionName")
                        .IsRequired()
                        .HasColumnName("election_name")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ElectionYear")
                        .HasColumnName("election_year")
                        .HasColumnType("date");

                    b.Property<DateTime>("EndingTime")
                        .HasColumnName("ending_time");

                    b.Property<int>("Tur")
                        .HasColumnName("tur");

                    b.HasKey("ElectionId");

                    b.ToTable("election");
                });

            modelBuilder.Entity("Reflections.Observer", b =>
                {
                    b.Property<int>("ObserverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("observer_id");

                    b.Property<int>("CitizenId")
                        .HasColumnName("citizen_id");

                    b.Property<int>("ElectionId")
                        .HasColumnName("election_id");

                    b.Property<int>("VirtualHouseId")
                        .HasColumnName("virtual_house_id");

                    b.HasKey("ObserverId");

                    b.HasIndex("CitizenId");

                    b.ToTable("observer");
                });

            modelBuilder.Entity("Reflections.ObserverFeedback", b =>
                {
                    b.Property<int>("ObserverFeeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("observer_feeedback_id")
                        .HasDefaultValueSql("nextval('observer_feeedback_observer_feeedback_id_seq'::regclass)");

                    b.Property<int>("CandidateId")
                        .HasColumnName("candidate_id");

                    b.Property<int>("ElectionId")
                        .HasColumnName("election_id");

                    b.Property<string>("FeedbackText")
                        .HasColumnName("feedback_text")
                        .HasMaxLength(500);

                    b.Property<int>("ObserverId")
                        .HasColumnName("observer_id");

                    b.Property<int>("VirtualHouseId")
                        .HasColumnName("virtual_house_id");

                    b.HasKey("ObserverFeeedbackId")
                        .HasName("observer_feeedback_pkey");

                    b.HasIndex("CandidateId");

                    b.HasIndex("ElectionId");

                    b.HasIndex("ObserverId");

                    b.HasIndex("VirtualHouseId");

                    b.ToTable("observer_feedback");
                });

            modelBuilder.Entity("Reflections.VirtualHouse", b =>
                {
                    b.Property<int>("VirtualHouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("virtual_house_id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<int>("VirtualHouseNumber")
                        .HasColumnName("virtual_house_number");

                    b.Property<int>("VirtualRegionId")
                        .HasColumnName("virtual_region_id");

                    b.HasKey("VirtualHouseId");

                    b.ToTable("virtual_house");
                });

            modelBuilder.Entity("Reflections.VirtualRegion", b =>
                {
                    b.Property<int>("VirtualRegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("virtual_region_id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasMaxLength(100);

                    b.Property<string>("Center")
                        .IsRequired()
                        .HasColumnName("center")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(100);

                    b.Property<int>("VirtualRegionNumber")
                        .HasColumnName("virtual_region_number");

                    b.HasKey("VirtualRegionId");

                    b.ToTable("virtual_region");
                });

            modelBuilder.Entity("Reflections.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("vote_id");

                    b.Property<int>("CandidateId")
                        .HasColumnName("candidate_id");

                    b.Property<int>("CitizenId")
                        .HasColumnName("citizen_id");

                    b.Property<int>("ElectionId")
                        .HasColumnName("election_id");

                    b.Property<int>("VirtualHouseId")
                        .HasColumnName("virtual_house_id");

                    b.HasKey("VoteId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CitizenId");

                    b.HasIndex("ElectionId");

                    b.HasIndex("VirtualHouseId");

                    b.ToTable("vote");
                });

            modelBuilder.Entity("Reflections.Candidate", b =>
                {
                    b.HasOne("Reflections.Citizen", "Citizen")
                        .WithMany("Candidate")
                        .HasForeignKey("CitizenId")
                        .HasConstraintName("candidate_citizen_id_fkey");
                });

            modelBuilder.Entity("Reflections.ChiefHouseOfficer", b =>
                {
                    b.HasOne("Reflections.Citizen", "Citizen")
                        .WithMany("ChiefHouseOfficer")
                        .HasForeignKey("CitizenId")
                        .HasConstraintName("fk_chief_house_officer_citizen");

                    b.HasOne("Reflections.Election", "Election")
                        .WithMany("ChiefHouseOfficer")
                        .HasForeignKey("ElectionId")
                        .HasConstraintName("fk_chief_house_officer_election");

                    b.HasOne("Reflections.VirtualHouse", "VirtualHouse")
                        .WithMany("ChiefHouseOfficer")
                        .HasForeignKey("VirtualHouseId")
                        .HasConstraintName("fk_chief_house_officer_virtual_house");
                });

            modelBuilder.Entity("Reflections.ChiefRegionOfficer", b =>
                {
                    b.HasOne("Reflections.Citizen", "Citizen")
                        .WithMany("ChiefRegionOfficer")
                        .HasForeignKey("CitizenId")
                        .HasConstraintName("fk_chief_region_officer_citizen");

                    b.HasOne("Reflections.Election", "Election")
                        .WithMany("ChiefRegionOfficer")
                        .HasForeignKey("ElectionId")
                        .HasConstraintName("fk_chief_region_officer_election");

                    b.HasOne("Reflections.VirtualRegion", "VirtulRegion")
                        .WithMany("ChiefRegionOfficer")
                        .HasForeignKey("VirtulRegionId")
                        .HasConstraintName("fk_chief_region_officer_virtual_region");
                });

            modelBuilder.Entity("Reflections.CitizenFeedback", b =>
                {
                    b.HasOne("Reflections.Citizen", "Citizen")
                        .WithMany("CitizenFeedback")
                        .HasForeignKey("CitizenId")
                        .HasConstraintName("fk_citizen_feedback_citizen");

                    b.HasOne("Reflections.Election", "Election")
                        .WithMany("CitizenFeedback")
                        .HasForeignKey("ElectionId")
                        .HasConstraintName("fk_citizen_feedback_election");

                    b.HasOne("Reflections.VirtualHouse", "VirtualHouse")
                        .WithMany("CitizenFeedback")
                        .HasForeignKey("VirtualHouseId")
                        .HasConstraintName("fk_citizen_feedback_virtual_house");
                });

            modelBuilder.Entity("Reflections.CitizenVirtualHouse", b =>
                {
                    b.HasOne("Reflections.Citizen", "Citizen")
                        .WithMany("CitizenVirtualHouse")
                        .HasForeignKey("CitizenId")
                        .HasConstraintName("citizen_virtual_house_citizen_id_fkey");

                    b.HasOne("Reflections.VirtualHouse", "VirtualHouse")
                        .WithMany("CitizenVirtualHouse")
                        .HasForeignKey("VirtualHouseId")
                        .HasConstraintName("citizen_virtual_house_virtual_house_id_fkey");
                });

            modelBuilder.Entity("Reflections.Observer", b =>
                {
                    b.HasOne("Reflections.Citizen", "Citizen")
                        .WithMany("Observer")
                        .HasForeignKey("CitizenId")
                        .HasConstraintName("observer_citizen_id_fkey");
                });

            modelBuilder.Entity("Reflections.ObserverFeedback", b =>
                {
                    b.HasOne("Reflections.Candidate", "Candidate")
                        .WithMany("ObserverFeedback")
                        .HasForeignKey("CandidateId")
                        .HasConstraintName("observer_feedback_candidate_id_fkey");

                    b.HasOne("Reflections.Election", "Election")
                        .WithMany("ObserverFeedback")
                        .HasForeignKey("ElectionId")
                        .HasConstraintName("fk_observer_feeedback_election");

                    b.HasOne("Reflections.Observer", "Observer")
                        .WithMany("ObserverFeedback")
                        .HasForeignKey("ObserverId")
                        .HasConstraintName("fk_observer_feeedback_observer");

                    b.HasOne("Reflections.VirtualHouse", "VirtualHouse")
                        .WithMany("ObserverFeedback")
                        .HasForeignKey("VirtualHouseId")
                        .HasConstraintName("fk_observer_feeedback_virtual_house");
                });

            modelBuilder.Entity("Reflections.Vote", b =>
                {
                    b.HasOne("Reflections.Candidate", "Candidate")
                        .WithMany("Vote")
                        .HasForeignKey("CandidateId")
                        .HasConstraintName("fk_vote_candidate");

                    b.HasOne("Reflections.Citizen", "Citizen")
                        .WithMany("Vote")
                        .HasForeignKey("CitizenId")
                        .HasConstraintName("fk_vote_citizen");

                    b.HasOne("Reflections.Election", "Election")
                        .WithMany("Vote")
                        .HasForeignKey("ElectionId")
                        .HasConstraintName("fk_vote_election");

                    b.HasOne("Reflections.VirtualHouse", "VirtualHouse")
                        .WithMany("Vote")
                        .HasForeignKey("VirtualHouseId")
                        .HasConstraintName("fk_vote_virtual_house");
                });
#pragma warning restore 612, 618
        }
    }
}