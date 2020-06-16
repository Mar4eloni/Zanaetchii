using Microsoft.EntityFrameworkCore.Migrations;

namespace Zanaetcii.Entities.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    BankAcc = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WorkeFields",
                columns: table => new
                {
                    WorkFieldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkeFields", x => x.WorkFieldId);
                });

            migrationBuilder.CreateTable(
                name: "WorkGivers",
                columns: table => new
                {
                    WorkGiverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkGivers", x => x.WorkGiverId);
                    table.ForeignKey(
                        name: "FK_WorkGivers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    WorkfieldId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_Workers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workers_WorkeFields_WorkfieldId",
                        column: x => x.WorkfieldId,
                        principalTable: "WorkeFields",
                        principalColumn: "WorkFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    WorkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkFieldId = table.Column<int>(nullable: true),
                    WorkGiverId = table.Column<int>(nullable: true),
                    WorkerId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.WorkId);
                    table.ForeignKey(
                        name: "FK_Jobs_WorkeFields_WorkFieldId",
                        column: x => x.WorkFieldId,
                        principalTable: "WorkeFields",
                        principalColumn: "WorkFieldId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_WorkGivers_WorkGiverId",
                        column: x => x.WorkGiverId,
                        principalTable: "WorkGivers",
                        principalColumn: "WorkGiverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkId = table.Column<int>(nullable: true),
                    WorkerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Jobs_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Jobs",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(nullable: false),
                    WorkGiverId = table.Column<int>(nullable: false),
                    WorkId = table.Column<int>(nullable: false),
                    CommentContent = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Jobs_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Jobs",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_WorkGivers_WorkGiverId",
                        column: x => x.WorkGiverId,
                        principalTable: "WorkGivers",
                        principalColumn: "WorkGiverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Jobs_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Jobs",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(nullable: true),
                    WorkGiverId = table.Column<int>(nullable: true),
                    WorkId = table.Column<int>(nullable: true),
                    RatingAmmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_WorkGivers_WorkGiverId",
                        column: x => x.WorkGiverId,
                        principalTable: "WorkGivers",
                        principalColumn: "WorkGiverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Jobs_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Jobs",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_WorkId",
                table: "Applications",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_WorkerId",
                table: "Applications",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WorkGiverId",
                table: "Comments",
                column: "WorkGiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WorkId",
                table: "Comments",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_WorkerId",
                table: "Comments",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkFieldId",
                table: "Jobs",
                column: "WorkFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkGiverId",
                table: "Jobs",
                column: "WorkGiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_WorkerId",
                table: "Jobs",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_WorkGiverId",
                table: "Ratings",
                column: "WorkGiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_WorkId",
                table: "Ratings",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_WorkerId",
                table: "Ratings",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkfieldId",
                table: "Workers",
                column: "WorkfieldId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkGivers_UserId",
                table: "WorkGivers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "WorkGivers");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkeFields");
        }
    }
}
