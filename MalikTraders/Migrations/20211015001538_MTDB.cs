using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MalikTraders.Migrations
{
    public partial class MTDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactLeads",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLeads", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MTServices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MTServices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SystemNotifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiringDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemNotifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNIC = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registration_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isUserDisabled = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDetailid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_userDetails_UserDetailid",
                        column: x => x.UserDetailid,
                        principalTable: "userDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountPayable = table.Column<int>(type: "int", nullable: false),
                    MonthlyInstalment = table.Column<int>(type: "int", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isAccClosed = table.Column<bool>(type: "bit", nullable: false),
                    ClosingDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    MTServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefaulter = table.Column<bool>(type: "bit", nullable: true),
                    CurrentPayment = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopAccount_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payedAmount = table.Column<int>(type: "int", nullable: false),
                    PayingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccId = table.Column<int>(type: "int", nullable: false),
                    PostedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_AccDetails_Accounts_AccId",
                        column: x => x.AccId,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopAccountPaymentHistory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountRecived = table.Column<int>(type: "int", nullable: false),
                    AmountPaid = table.Column<int>(type: "int", nullable: false),
                    PaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopAccountPaymentHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopAccountPaymentHistory_ShopAccount_ShopAccountId",
                        column: x => x.ShopAccountId,
                        principalTable: "ShopAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccDetails_AccId",
                table: "AccDetails",
                column: "AccId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Userid",
                table: "Accounts",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Userid",
                table: "Notifications",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_ShopAccount_UserId",
                table: "ShopAccount",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopAccountPaymentHistory_ShopAccountId",
                table: "ShopAccountPaymentHistory",
                column: "ShopAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_CNIC",
                table: "userDetails",
                column: "CNIC",
                unique: true,
                filter: "[CNIC] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_PhoneNumber",
                table: "userDetails",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDetailid",
                table: "Users",
                column: "UserDetailid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccDetails");

            migrationBuilder.DropTable(
                name: "ContactLeads");

            migrationBuilder.DropTable(
                name: "MTServices");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ShopAccountPaymentHistory");

            migrationBuilder.DropTable(
                name: "SystemNotifications");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ShopAccount");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "userDetails");
        }
    }
}
