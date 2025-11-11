using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class clientgrouptableaddedparentGroupId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentGroupId",
                table: "ClientGroups",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentGroupId",
                table: "ClientGroups");
        }
    }
}
