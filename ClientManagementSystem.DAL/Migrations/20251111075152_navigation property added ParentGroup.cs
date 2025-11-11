using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class navigationpropertyaddedParentGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClientGroups_ParentGroupId",
                table: "ClientGroups",
                column: "ParentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientGroups_ClientGroups_ParentGroupId",
                table: "ClientGroups",
                column: "ParentGroupId",
                principalTable: "ClientGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientGroups_ClientGroups_ParentGroupId",
                table: "ClientGroups");

            migrationBuilder.DropIndex(
                name: "IX_ClientGroups_ParentGroupId",
                table: "ClientGroups");
        }
    }
}
