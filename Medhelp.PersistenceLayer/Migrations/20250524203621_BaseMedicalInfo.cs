using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medhelp.PersistenceLayer.Migrations
{
    /// <inheritdoc />
    public partial class BaseMedicalInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveSubstances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveSubstances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSpecialties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSpecialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LaunchYear = table.Column<int>(type: "integer", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineActiveSubstances",
                columns: table => new
                {
                    ActiveSubstancesId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicinesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineActiveSubstances", x => new { x.ActiveSubstancesId, x.MedicinesId });
                    table.ForeignKey(
                        name: "FK_MedicineActiveSubstances_ActiveSubstances_ActiveSubstancesId",
                        column: x => x.ActiveSubstancesId,
                        principalTable: "ActiveSubstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineActiveSubstances_Medicines_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineDrugActions",
                columns: table => new
                {
                    DrugActionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicinesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDrugActions", x => new { x.DrugActionsId, x.MedicinesId });
                    table.ForeignKey(
                        name: "FK_MedicineDrugActions_DrugActions_DrugActionsId",
                        column: x => x.DrugActionsId,
                        principalTable: "DrugActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineDrugActions_Medicines_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineDrugForms",
                columns: table => new
                {
                    DrugFormsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicinesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDrugForms", x => new { x.DrugFormsId, x.MedicinesId });
                    table.ForeignKey(
                        name: "FK_MedicineDrugForms_DrugForms_DrugFormsId",
                        column: x => x.DrugFormsId,
                        principalTable: "DrugForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineDrugForms_Medicines_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineMedicalSpecialties",
                columns: table => new
                {
                    MedicalSpecialtiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicinesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineMedicalSpecialties", x => new { x.MedicalSpecialtiesId, x.MedicinesId });
                    table.ForeignKey(
                        name: "FK_MedicineMedicalSpecialties_MedicalSpecialties_MedicalSpecia~",
                        column: x => x.MedicalSpecialtiesId,
                        principalTable: "MedicalSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineMedicalSpecialties_Medicines_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineOrganSystems",
                columns: table => new
                {
                    MedicinesId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganSystemsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineOrganSystems", x => new { x.MedicinesId, x.OrganSystemsId });
                    table.ForeignKey(
                        name: "FK_MedicineOrganSystems_Medicines_MedicinesId",
                        column: x => x.MedicinesId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineOrganSystems_OrganSystems_OrganSystemsId",
                        column: x => x.OrganSystemsId,
                        principalTable: "OrganSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineActiveSubstances_MedicinesId",
                table: "MedicineActiveSubstances",
                column: "MedicinesId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDrugActions_MedicinesId",
                table: "MedicineDrugActions",
                column: "MedicinesId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDrugForms_MedicinesId",
                table: "MedicineDrugForms",
                column: "MedicinesId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineMedicalSpecialties_MedicinesId",
                table: "MedicineMedicalSpecialties",
                column: "MedicinesId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineOrganSystems_OrganSystemsId",
                table: "MedicineOrganSystems",
                column: "OrganSystemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseaseGroups");

            migrationBuilder.DropTable(
                name: "MedicineActiveSubstances");

            migrationBuilder.DropTable(
                name: "MedicineDrugActions");

            migrationBuilder.DropTable(
                name: "MedicineDrugForms");

            migrationBuilder.DropTable(
                name: "MedicineMedicalSpecialties");

            migrationBuilder.DropTable(
                name: "MedicineOrganSystems");

            migrationBuilder.DropTable(
                name: "ActiveSubstances");

            migrationBuilder.DropTable(
                name: "DrugActions");

            migrationBuilder.DropTable(
                name: "DrugForms");

            migrationBuilder.DropTable(
                name: "MedicalSpecialties");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "OrganSystems");
        }
    }
}
