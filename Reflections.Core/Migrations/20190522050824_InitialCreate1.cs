using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Reflections.Core.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "observer_feeedback_observer_feeedback_id_seq");

            migrationBuilder.CreateTable(
                name: "citizen",
                columns: table => new
                {
                    citizen_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    first_name = table.Column<string>(maxLength: 100, nullable: false),
                    last_name = table.Column<string>(maxLength: 100, nullable: false),
                    patronymic = table.Column<string>(maxLength: 100, nullable: false),
                    ipn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citizen", x => x.citizen_id);
                });

            migrationBuilder.CreateTable(
                name: "election",
                columns: table => new
                {
                    election_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    election_name = table.Column<string>(maxLength: 100, nullable: false),
                    election_year = table.Column<DateTime>(type: "date", nullable: false),
                    tur = table.Column<int>(nullable: false),
                    beginning_time = table.Column<DateTime>(nullable: false),
                    ending_time = table.Column<DateTime>(nullable: false),
                    chief_officer_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_election", x => x.election_id);
                });

            migrationBuilder.CreateTable(
                name: "virtual_house",
                columns: table => new
                {
                    virtual_house_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    virtual_house_number = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    address = table.Column<string>(maxLength: 100, nullable: false),
                    virtual_region_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_virtual_house", x => x.virtual_house_id);
                });

            migrationBuilder.CreateTable(
                name: "virtual_region",
                columns: table => new
                {
                    virtual_region_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    virtual_region_number = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    center = table.Column<string>(maxLength: 100, nullable: false),
                    address = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_virtual_region", x => x.virtual_region_id);
                });

            migrationBuilder.CreateTable(
                name: "candidate",
                columns: table => new
                {
                    candidate_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ballot_number = table.Column<int>(nullable: false),
                    election_id = table.Column<int>(nullable: false),
                    citizen_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidate", x => x.candidate_id);
                    table.ForeignKey(
                        name: "candidate_citizen_id_fkey",
                        column: x => x.citizen_id,
                        principalTable: "citizen",
                        principalColumn: "citizen_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "observer",
                columns: table => new
                {
                    observer_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    election_id = table.Column<int>(nullable: false),
                    virtual_house_id = table.Column<int>(nullable: false),
                    citizen_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_observer", x => x.observer_id);
                    table.ForeignKey(
                        name: "observer_citizen_id_fkey",
                        column: x => x.citizen_id,
                        principalTable: "citizen",
                        principalColumn: "citizen_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chief_house_officer",
                columns: table => new
                {
                    chief_house_officer_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    election_id = table.Column<int>(nullable: false),
                    virtual_house_id = table.Column<int>(nullable: false),
                    citizen_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chief_house_officer", x => x.chief_house_officer_id);
                    table.ForeignKey(
                        name: "fk_chief_house_officer_citizen",
                        column: x => x.citizen_id,
                        principalTable: "citizen",
                        principalColumn: "citizen_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_chief_house_officer_election",
                        column: x => x.election_id,
                        principalTable: "election",
                        principalColumn: "election_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_chief_house_officer_virtual_house",
                        column: x => x.virtual_house_id,
                        principalTable: "virtual_house",
                        principalColumn: "virtual_house_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "citizen_feedback",
                columns: table => new
                {
                    citizen_feedback_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    election_id = table.Column<int>(nullable: false),
                    virtual_house_id = table.Column<int>(nullable: false),
                    citizen_id = table.Column<int>(nullable: false),
                    citizen_feedback_text = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citizen_feedback", x => x.citizen_feedback_id);
                    table.ForeignKey(
                        name: "fk_citizen_feedback_citizen",
                        column: x => x.citizen_id,
                        principalTable: "citizen",
                        principalColumn: "citizen_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_citizen_feedback_election",
                        column: x => x.election_id,
                        principalTable: "election",
                        principalColumn: "election_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_citizen_feedback_virtual_house",
                        column: x => x.virtual_house_id,
                        principalTable: "virtual_house",
                        principalColumn: "virtual_house_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "citizen_virtual_house",
                columns: table => new
                {
                    citizen_virtual_house_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    citizen_id = table.Column<int>(nullable: false),
                    virtual_house_id = table.Column<int>(nullable: false),
                    registration_time = table.Column<DateTime>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citizen_virtual_house", x => x.citizen_virtual_house_id);
                    table.ForeignKey(
                        name: "citizen_virtual_house_citizen_id_fkey",
                        column: x => x.citizen_id,
                        principalTable: "citizen",
                        principalColumn: "citizen_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "citizen_virtual_house_virtual_house_id_fkey",
                        column: x => x.virtual_house_id,
                        principalTable: "virtual_house",
                        principalColumn: "virtual_house_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chief_region_officer",
                columns: table => new
                {
                    chief_region_officer_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    election_id = table.Column<int>(nullable: false),
                    virtul_region_id = table.Column<int>(nullable: false),
                    citizen_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chief_region_officer", x => x.chief_region_officer_id);
                    table.ForeignKey(
                        name: "fk_chief_region_officer_citizen",
                        column: x => x.citizen_id,
                        principalTable: "citizen",
                        principalColumn: "citizen_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_chief_region_officer_election",
                        column: x => x.election_id,
                        principalTable: "election",
                        principalColumn: "election_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_chief_region_officer_virtual_region",
                        column: x => x.virtul_region_id,
                        principalTable: "virtual_region",
                        principalColumn: "virtual_region_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vote",
                columns: table => new
                {
                    vote_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    election_id = table.Column<int>(nullable: false),
                    virtual_house_id = table.Column<int>(nullable: false),
                    citizen_id = table.Column<int>(nullable: false),
                    candidate_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote", x => x.vote_id);
                    table.ForeignKey(
                        name: "fk_vote_candidate",
                        column: x => x.candidate_id,
                        principalTable: "candidate",
                        principalColumn: "candidate_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vote_citizen",
                        column: x => x.citizen_id,
                        principalTable: "citizen",
                        principalColumn: "citizen_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vote_election",
                        column: x => x.election_id,
                        principalTable: "election",
                        principalColumn: "election_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vote_virtual_house",
                        column: x => x.virtual_house_id,
                        principalTable: "virtual_house",
                        principalColumn: "virtual_house_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "observer_feedback",
                columns: table => new
                {
                    observer_feeedback_id = table.Column<int>(nullable: false, defaultValueSql: "nextval('observer_feeedback_observer_feeedback_id_seq'::regclass)"),
                    election_id = table.Column<int>(nullable: false),
                    virtual_house_id = table.Column<int>(nullable: false),
                    observer_id = table.Column<int>(nullable: false),
                    feedback_text = table.Column<string>(maxLength: 500, nullable: true),
                    candidate_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("observer_feeedback_pkey", x => x.observer_feeedback_id);
                    table.ForeignKey(
                        name: "observer_feedback_candidate_id_fkey",
                        column: x => x.candidate_id,
                        principalTable: "candidate",
                        principalColumn: "candidate_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_observer_feeedback_election",
                        column: x => x.election_id,
                        principalTable: "election",
                        principalColumn: "election_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_observer_feeedback_observer",
                        column: x => x.observer_id,
                        principalTable: "observer",
                        principalColumn: "observer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_observer_feeedback_virtual_house",
                        column: x => x.virtual_house_id,
                        principalTable: "virtual_house",
                        principalColumn: "virtual_house_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidate_citizen_id",
                table: "candidate",
                column: "citizen_id");

            migrationBuilder.CreateIndex(
                name: "IX_chief_house_officer_citizen_id",
                table: "chief_house_officer",
                column: "citizen_id");

            migrationBuilder.CreateIndex(
                name: "IX_chief_house_officer_election_id",
                table: "chief_house_officer",
                column: "election_id");

            migrationBuilder.CreateIndex(
                name: "IX_chief_house_officer_virtual_house_id",
                table: "chief_house_officer",
                column: "virtual_house_id");

            migrationBuilder.CreateIndex(
                name: "IX_chief_region_officer_citizen_id",
                table: "chief_region_officer",
                column: "citizen_id");

            migrationBuilder.CreateIndex(
                name: "IX_chief_region_officer_election_id",
                table: "chief_region_officer",
                column: "election_id");

            migrationBuilder.CreateIndex(
                name: "IX_chief_region_officer_virtul_region_id",
                table: "chief_region_officer",
                column: "virtul_region_id");

            migrationBuilder.CreateIndex(
                name: "IX_citizen_feedback_citizen_id",
                table: "citizen_feedback",
                column: "citizen_id");

            migrationBuilder.CreateIndex(
                name: "IX_citizen_feedback_election_id",
                table: "citizen_feedback",
                column: "election_id");

            migrationBuilder.CreateIndex(
                name: "IX_citizen_feedback_virtual_house_id",
                table: "citizen_feedback",
                column: "virtual_house_id");

            migrationBuilder.CreateIndex(
                name: "IX_citizen_virtual_house_citizen_id",
                table: "citizen_virtual_house",
                column: "citizen_id");

            migrationBuilder.CreateIndex(
                name: "IX_citizen_virtual_house_virtual_house_id",
                table: "citizen_virtual_house",
                column: "virtual_house_id");

            migrationBuilder.CreateIndex(
                name: "IX_observer_citizen_id",
                table: "observer",
                column: "citizen_id");

            migrationBuilder.CreateIndex(
                name: "IX_observer_feedback_candidate_id",
                table: "observer_feedback",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "IX_observer_feedback_election_id",
                table: "observer_feedback",
                column: "election_id");

            migrationBuilder.CreateIndex(
                name: "IX_observer_feedback_observer_id",
                table: "observer_feedback",
                column: "observer_id");

            migrationBuilder.CreateIndex(
                name: "IX_observer_feedback_virtual_house_id",
                table: "observer_feedback",
                column: "virtual_house_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_candidate_id",
                table: "vote",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_citizen_id",
                table: "vote",
                column: "citizen_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_election_id",
                table: "vote",
                column: "election_id");

            migrationBuilder.CreateIndex(
                name: "IX_vote_virtual_house_id",
                table: "vote",
                column: "virtual_house_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chief_house_officer");

            migrationBuilder.DropTable(
                name: "chief_region_officer");

            migrationBuilder.DropTable(
                name: "citizen_feedback");

            migrationBuilder.DropTable(
                name: "citizen_virtual_house");

            migrationBuilder.DropTable(
                name: "observer_feedback");

            migrationBuilder.DropTable(
                name: "vote");

            migrationBuilder.DropTable(
                name: "virtual_region");

            migrationBuilder.DropTable(
                name: "observer");

            migrationBuilder.DropTable(
                name: "candidate");

            migrationBuilder.DropTable(
                name: "election");

            migrationBuilder.DropTable(
                name: "virtual_house");

            migrationBuilder.DropTable(
                name: "citizen");

            migrationBuilder.DropSequence(
                name: "observer_feeedback_observer_feeedback_id_seq");
        }
    }
}
