using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateAuthTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginAttempt",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IpAddress = table.Column<string>(type: "varchar(191)", nullable: false),
                    Login = table.Column<string>(type: "varchar(191)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttempt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordReset",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "varchar(191)", nullable: false),
                    Token = table.Column<string>(type: "varchar(191)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordReset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "varchar(191)", nullable: false),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "varchar(255)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(191)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(191)", nullable: true),
                    Gender = table.Column<string>(type: "varchar(2)", nullable: true),
                    Country = table.Column<string>(type: "varchar(191)", nullable: true),
                    Province = table.Column<string>(type: "varchar(191)", nullable: true),
                    Regency = table.Column<string>(type: "varchar(191)", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(20)", nullable: true),
                    BirthPlace = table.Column<string>(type: "varchar(191)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Twitter = table.Column<string>(type: "varchar(191)", nullable: true),
                    Facebook = table.Column<string>(type: "varchar(191)", nullable: true),
                    Instagram = table.Column<string>(type: "varchar(191)", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    AboutMe = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "varchar(191)", nullable: false),
                    Email = table.Column<string>(type: "varchar(191)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(64)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "varchar(191)", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RolesId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVerification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "varchar(191)", nullable: false),
                    Token = table.Column<string>(type: "varchar(255)", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVerification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVerification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempt_CreatedAt",
                table: "LoginAttempt",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempt_IpAddress",
                table: "LoginAttempt",
                column: "IpAddress");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempt_Login",
                table: "LoginAttempt",
                column: "Login");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempt_UpdatedAt",
                table: "LoginAttempt",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordReset_CreatedAt",
                table: "PasswordReset",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordReset_Email",
                table: "PasswordReset",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordReset_Token",
                table: "PasswordReset",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordReset_UpdatedAt",
                table: "PasswordReset",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Code",
                table: "Role",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreatedAt",
                table: "Role",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Status",
                table: "Role",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UpdatedAt",
                table: "Role",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_User_BirthDate",
                table: "User",
                column: "BirthDate");

            migrationBuilder.CreateIndex(
                name: "IX_User_BirthPlace",
                table: "User",
                column: "BirthPlace");

            migrationBuilder.CreateIndex(
                name: "IX_User_Country",
                table: "User",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedAt",
                table: "User",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Facebook",
                table: "User",
                column: "Facebook");

            migrationBuilder.CreateIndex(
                name: "IX_User_FirstName",
                table: "User",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_User_Gender",
                table: "User",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_User_Image",
                table: "User",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_User_Instagram",
                table: "User",
                column: "Instagram");

            migrationBuilder.CreateIndex(
                name: "IX_User_LastName",
                table: "User",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_User_Password",
                table: "User",
                column: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_User_Phone",
                table: "User",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PostalCode",
                table: "User",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_User_Province",
                table: "User",
                column: "Province");

            migrationBuilder.CreateIndex(
                name: "IX_User_Regency",
                table: "User",
                column: "Regency");

            migrationBuilder.CreateIndex(
                name: "IX_User_Status",
                table: "User",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_User_Twitter",
                table: "User",
                column: "Twitter");

            migrationBuilder.CreateIndex(
                name: "IX_User_UpdatedAt",
                table: "User",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_CreatedAt",
                table: "UserNotification",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_Description",
                table: "UserNotification",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_Status",
                table: "UserNotification",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_Subject",
                table: "UserNotification",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_UpdatedAt",
                table: "UserNotification",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_UserId",
                table: "UserNotification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UsersId",
                table: "UserRoles",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_CreatedAt",
                table: "UserVerification",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_Email",
                table: "UserVerification",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_ExpiredAt",
                table: "UserVerification",
                column: "ExpiredAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_Status",
                table: "UserVerification",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_Token",
                table: "UserVerification",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_UpdatedAt",
                table: "UserVerification",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserVerification_UserId",
                table: "UserVerification",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginAttempt");

            migrationBuilder.DropTable(
                name: "PasswordReset");

            migrationBuilder.DropTable(
                name: "UserNotification");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserVerification");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
