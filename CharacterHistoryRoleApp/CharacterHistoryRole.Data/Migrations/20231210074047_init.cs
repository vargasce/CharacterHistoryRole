using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharacterHistoryRole.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterBioDetail",
                columns: table => new
                {
                    CharacterBioDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassRaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CharacterBioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Force = table.Column<int>(type: "int", nullable: true),
                    Destress = table.Column<int>(type: "int", nullable: true),
                    Intelligence = table.Column<int>(type: "int", nullable: true),
                    Wisdom = table.Column<int>(type: "int", nullable: true),
                    Perception = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    LifePoints = table.Column<int>(type: "int", nullable: true),
                    PowerPoints = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterBioDetail", x => x.CharacterBioDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Permmission",
                columns: table => new
                {
                    PermmissionId = table.Column<int>(type: "int", nullable: false),
                    PermmissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permmission", x => x.PermmissionId);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AtributesAbilities",
                columns: table => new
                {
                    CharacterBioDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtributesAbilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributesAbilities", x => x.CharacterBioDetailId);
                    table.ForeignKey(
                        name: "FK_Atributies_CharacterBioDetail",
                        column: x => x.CharacterBioDetailId,
                        principalTable: "CharacterBioDetail",
                        principalColumn: "CharacterBioDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRace",
                columns: table => new
                {
                    ClassRaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassRaceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRace", x => x.ClassRaceId);
                    table.ForeignKey(
                        name: "FK_ClassRace_CharacterBioDetail_ClassRaceId",
                        column: x => x.ClassRaceId,
                        principalTable: "CharacterBioDetail",
                        principalColumn: "CharacterBioDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    RaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.RaceId);
                    table.ForeignKey(
                        name: "FK_Race_CharacterBioDetail_RaceId",
                        column: x => x.RaceId,
                        principalTable: "CharacterBioDetail",
                        principalColumn: "CharacterBioDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RacialBackground",
                columns: table => new
                {
                    RacialBackgroundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacterBioDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacialBackground", x => x.RacialBackgroundId);
                    table.ForeignKey(
                        name: "FK_RacilBackGroud_CharacterBioDetail",
                        column: x => x.CharacterBioDetailId,
                        principalTable: "CharacterBioDetail",
                        principalColumn: "CharacterBioDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterBio",
                columns: table => new
                {
                    CharacterBioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BioInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTimestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bio_User_Group", x => x.CharacterBioId);
                    table.ForeignKey(
                        name: "FK_CharacterBio_CharacterBioDetail_CharacterBioId",
                        column: x => x.CharacterBioId,
                        principalTable: "CharacterBioDetail",
                        principalColumn: "CharacterBioDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Character_Bio",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePermmission",
                columns: table => new
                {
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermmissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePermmissions", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_ProfilePermmisions_Permmissions",
                        column: x => x.PermmissionId,
                        principalTable: "Permmission",
                        principalColumn: "PermmissionId");
                    table.ForeignKey(
                        name: "FK_ProfilePermmissions_Profile",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK_User_ProfilePermmissions",
                        column: x => x.ProfileId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackPack",
                columns: table => new
                {
                    BackPackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacterBioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackPack_CharacterBio", x => x.BackPackId);
                    table.ForeignKey(
                        name: "FK_BackPack_CharacterBio_CharacterBioId",
                        column: x => x.CharacterBioId,
                        principalTable: "CharacterBio",
                        principalColumn: "CharacterBioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserGroup_CharacterBio",
                        column: x => x.GroupId,
                        principalTable: "CharacterBio",
                        principalColumn: "CharacterBioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Group",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackPackItem",
                columns: table => new
                {
                    BackPackItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BackPackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackPackItem", x => x.BackPackItemId);
                    table.ForeignKey(
                        name: "FK_BackPackItem_BackPack",
                        column: x => x.BackPackId,
                        principalTable: "BackPack",
                        principalColumn: "BackPackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackPack_CharacterBioId",
                table: "BackPack",
                column: "CharacterBioId");

            migrationBuilder.CreateIndex(
                name: "IX_BackPackItem_BackPackId",
                table: "BackPackItem",
                column: "BackPackId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterBio_UserId",
                table: "CharacterBio",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePermmission_PermmissionId",
                table: "ProfilePermmission",
                column: "PermmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RacialBackground_CharacterBioDetailId",
                table: "RacialBackground",
                column: "CharacterBioDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                table: "UserGroup",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtributesAbilities");

            migrationBuilder.DropTable(
                name: "BackPackItem");

            migrationBuilder.DropTable(
                name: "ClassRace");

            migrationBuilder.DropTable(
                name: "ProfilePermmission");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "RacialBackground");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "BackPack");

            migrationBuilder.DropTable(
                name: "Permmission");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "CharacterBio");

            migrationBuilder.DropTable(
                name: "CharacterBioDetail");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
