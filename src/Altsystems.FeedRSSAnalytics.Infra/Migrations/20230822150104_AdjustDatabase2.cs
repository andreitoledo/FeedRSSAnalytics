using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Altsystems.FeedRSSAnalytics.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdjustDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "ArticleMatrices",
                newName: "CategoryDTO");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PubDate",
                table: "ArticleMatrices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryDTO",
                table: "ArticleMatrices",
                newName: "Category");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PubDate",
                table: "ArticleMatrices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
