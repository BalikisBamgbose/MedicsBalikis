using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medics.Migrations
{
    public partial class RENew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MgfDate = table.Column<string>(type: "longtext", nullable: true),
                    ExpDate = table.Column<string>(type: "longtext", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Incomings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    SupplierName = table.Column<string>(type: "longtext", nullable: true),
                    ItemName = table.Column<string>(type: "longtext", nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: true),
                    InvoiceNo = table.Column<string>(type: "longtext", nullable: true),
                    SupplyDate = table.Column<string>(type: "longtext", nullable: true),
                    Bill = table.Column<string>(type: "longtext", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MgfDate = table.Column<string>(type: "longtext", nullable: true),
                    ExpDate = table.Column<string>(type: "longtext", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomings", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleName = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MgfDate = table.Column<string>(type: "longtext", nullable: true),
                    ExpDate = table.Column<string>(type: "longtext", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: true),
                    HashSalt = table.Column<string>(type: "longtext", nullable: true),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MgfDate = table.Column<string>(type: "longtext", nullable: true),
                    ExpDate = table.Column<string>(type: "longtext", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    DrugName = table.Column<string>(type: "longtext", nullable: true),
                    Prices = table.Column<string>(type: "longtext", nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: true),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true),
                    IsClosed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MgfDate = table.Column<string>(type: "longtext", nullable: true),
                    ExpDate = table.Column<string>(type: "longtext", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drugs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DrugCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    DrugId = table.Column<string>(type: "varchar(255)", nullable: true),
                    CategoryId = table.Column<string>(type: "varchar(255)", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MgfDate = table.Column<string>(type: "longtext", nullable: true),
                    ExpDate = table.Column<string>(type: "longtext", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrugCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DrugCategory_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Outgoing",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Item = table.Column<string>(type: "longtext", nullable: true),
                    DrugId = table.Column<string>(type: "varchar(255)", nullable: true),
                    DeliveredTo = table.Column<string>(type: "longtext", nullable: true),
                    Quantity = table.Column<string>(type: "longtext", nullable: true),
                    Purpose = table.Column<int>(type: "int", nullable: false),
                    Sale = table.Column<string>(type: "longtext", nullable: true),
                    InvoiceNo = table.Column<string>(type: "longtext", nullable: true),
                    SupplyDate = table.Column<string>(type: "longtext", nullable: true),
                    BillValue = table.Column<string>(type: "longtext", nullable: true),
                    Bill = table.Column<string>(type: "longtext", nullable: true),
                    DeliveryDate = table.Column<string>(type: "longtext", nullable: true),
                    ReceiptNo = table.Column<string>(type: "longtext", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedBy = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DatePurchased = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MgfDate = table.Column<string>(type: "longtext", nullable: true),
                    ExpDate = table.Column<string>(type: "longtext", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outgoing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outgoing_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DrugCategory_CategoryId",
                table: "DrugCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugCategory_DrugId",
                table: "DrugCategory",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_UserId",
                table: "Drugs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Outgoing_DrugId",
                table: "Outgoing",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugCategory");

            migrationBuilder.DropTable(
                name: "Incomings");

            migrationBuilder.DropTable(
                name: "Outgoing");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
