using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateContentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Image = table.Column<string>(type: "varchar(255)", nullable: true),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false),
                    Slug = table.Column<string>(type: "varchar(255)", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Email = table.Column<string>(type: "varchar(191)", nullable: false),
                    Subject = table.Column<string>(type: "varchar(191)", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "varchar(191)", nullable: true),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Email = table.Column<string>(type: "varchar(191)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(191)", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faq",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "varchar(255)", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    Sort = table.Column<int>(type: "int4", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Slug = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "int4", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Icon = table.Column<string>(type: "varchar(64)", nullable: true),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Sort = table.Column<int>(type: "int4", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "varchar(255)", nullable: true),
                    Title = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true),
                    Sort = table.Column<int>(type: "int4", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "varchar(191)", nullable: true),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Email = table.Column<string>(type: "varchar(191)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(191)", nullable: false),
                    PositionName = table.Column<string>(type: "varchar(255)", nullable: false),
                    Twitter = table.Column<string>(type: "varchar(255)", nullable: true),
                    Facebook = table.Column<string>(type: "varchar(255)", nullable: true),
                    Instagram = table.Column<string>(type: "varchar(255)", nullable: true),
                    LinkedIn = table.Column<string>(type: "varchar(255)", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Sort = table.Column<int>(type: "int4", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleComment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleComment_ArticleComment_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ArticleComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleComment_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArticleComment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Testimonial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    Image = table.Column<string>(type: "varchar(191)", nullable: true),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Position = table.Column<string>(type: "varchar(191)", nullable: false),
                    Quote = table.Column<string>(type: "text", nullable: false),
                    Sort = table.Column<int>(type: "int4", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testimonial_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleReference",
                columns: table => new
                {
                    ArticlesId = table.Column<long>(type: "bigint", nullable: false),
                    ReferencesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleReference", x => new { x.ArticlesId, x.ReferencesId });
                    table.ForeignKey(
                        name: "FK_ArticleReference_Article_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleReference_Reference_ReferencesId",
                        column: x => x.ReferencesId,
                        principalTable: "Reference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    ReferenceId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProjectDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProjectUrl = table.Column<string>(type: "varchar(255)", nullable: true),
                    Sort = table.Column<int>(type: "int4", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolio_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Portfolio_Reference_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "Reference",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PortfolioImage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PortfolioId = table.Column<long>(type: "bigint", nullable: false),
                    Image = table.Column<string>(type: "varchar(191)", nullable: false),
                    Status = table.Column<short>(type: "int2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioImage_Portfolio_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_CreatedAt",
                table: "Article",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Slug",
                table: "Article",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Status",
                table: "Article",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Title",
                table: "Article",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Article_UpdatedAt",
                table: "Article",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Article_UserId",
                table: "Article",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_ArticleId",
                table: "ArticleComment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_CreatedAt",
                table: "ArticleComment",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_ParentId",
                table: "ArticleComment",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_Status",
                table: "ArticleComment",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_UpdatedAt",
                table: "ArticleComment",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_UserId",
                table: "ArticleComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleReference_ReferencesId",
                table: "ArticleReference",
                column: "ReferencesId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CreatedAt",
                table: "Contact",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Email",
                table: "Contact",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Name",
                table: "Contact",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Status",
                table: "Contact",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Subject",
                table: "Contact",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UpdatedAt",
                table: "Contact",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Address",
                table: "Customer",
                column: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CreatedAt",
                table: "Customer",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Image",
                table: "Customer",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Name",
                table: "Customer",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Phone",
                table: "Customer",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Status",
                table: "Customer",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UpdatedAt",
                table: "Customer",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_CreatedAt",
                table: "Faq",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_Question",
                table: "Faq",
                column: "Question");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_Sort",
                table: "Faq",
                column: "Sort");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_Status",
                table: "Faq",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_UpdatedAt",
                table: "Faq",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_CreatedAt",
                table: "Portfolio",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_CustomerId",
                table: "Portfolio",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_ProjectDate",
                table: "Portfolio",
                column: "ProjectDate");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_ProjectUrl",
                table: "Portfolio",
                column: "ProjectUrl");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_ReferenceId",
                table: "Portfolio",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_Sort",
                table: "Portfolio",
                column: "Sort");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_Status",
                table: "Portfolio",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_Title",
                table: "Portfolio",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_UpdatedAt",
                table: "Portfolio",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioImage_CreatedAt",
                table: "PortfolioImage",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioImage_Image",
                table: "PortfolioImage",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioImage_PortfolioId",
                table: "PortfolioImage",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioImage_Status",
                table: "PortfolioImage",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioImage_UpdatedAt",
                table: "PortfolioImage",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_CreatedAt",
                table: "Reference",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_Name",
                table: "Reference",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_Slug",
                table: "Reference",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_Status",
                table: "Reference",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_Type",
                table: "Reference",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_UpdatedAt",
                table: "Reference",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CreatedAt",
                table: "Service",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Icon",
                table: "Service",
                column: "Icon");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Sort",
                table: "Service",
                column: "Sort");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Status",
                table: "Service",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Title",
                table: "Service",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Service_UpdatedAt",
                table: "Service",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_CreatedAt",
                table: "Slider",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_Image",
                table: "Slider",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_Link",
                table: "Slider",
                column: "Link");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_Sort",
                table: "Slider",
                column: "Sort");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_Status",
                table: "Slider",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_Title",
                table: "Slider",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_UpdatedAt",
                table: "Slider",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CreatedAt",
                table: "Team",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Email",
                table: "Team",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Facebook",
                table: "Team",
                column: "Facebook");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Image",
                table: "Team",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Instagram",
                table: "Team",
                column: "Instagram");

            migrationBuilder.CreateIndex(
                name: "IX_Team_LinkedIn",
                table: "Team",
                column: "LinkedIn");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Name",
                table: "Team",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Phone",
                table: "Team",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Team_PositionName",
                table: "Team",
                column: "PositionName");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Sort",
                table: "Team",
                column: "Sort");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Status",
                table: "Team",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Twitter",
                table: "Team",
                column: "Twitter");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UpdatedAt",
                table: "Team",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_CreatedAt",
                table: "Testimonial",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_CustomerId",
                table: "Testimonial",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_Image",
                table: "Testimonial",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_Name",
                table: "Testimonial",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_Position",
                table: "Testimonial",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_Sort",
                table: "Testimonial",
                column: "Sort");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_Status",
                table: "Testimonial",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonial_UpdatedAt",
                table: "Testimonial",
                column: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleComment");

            migrationBuilder.DropTable(
                name: "ArticleReference");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Faq");

            migrationBuilder.DropTable(
                name: "PortfolioImage");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Testimonial");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Reference");
        }
    }
}
