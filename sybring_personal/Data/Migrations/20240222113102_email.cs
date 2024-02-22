using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sybring_personal.Data.Migrations
{
    /// <inheritdoc />
    public partial class email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_billings_BillingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_projects_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_timeHistories_TimeHistoryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_consultants_AspNetUsers_UserId",
                table: "consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_consultants_projects_ProjectId",
                table: "consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_billings_BillingId",
                table: "projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTimeHistory_projects_ProjectIdId",
                table: "ProjectTimeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTimeHistory_timeHistories_TimeIdId",
                table: "ProjectTimeHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_timeHistories",
                table: "timeHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projects",
                table: "projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_consultants",
                table: "consultants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_billings",
                table: "billings");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "timeHistories",
                newName: "TimeHistories");

            migrationBuilder.RenameTable(
                name: "projects",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "consultants",
                newName: "Consultants");

            migrationBuilder.RenameTable(
                name: "billings",
                newName: "Billings");

            migrationBuilder.RenameIndex(
                name: "IX_projects_BillingId",
                table: "Projects",
                newName: "IX_Projects_BillingId");

            migrationBuilder.RenameIndex(
                name: "IX_consultants_UserId",
                table: "Consultants",
                newName: "IX_Consultants_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_consultants_ProjectId",
                table: "Consultants",
                newName: "IX_Consultants_ProjectId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Consultants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeHistories",
                table: "TimeHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultants",
                table: "Consultants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billings",
                table: "Billings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Billings_BillingId",
                table: "AspNetUsers",
                column: "BillingId",
                principalTable: "Billings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TimeHistories_TimeHistoryId",
                table: "AspNetUsers",
                column: "TimeHistoryId",
                principalTable: "TimeHistories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_AspNetUsers_UserId",
                table: "Consultants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultants_Projects_ProjectId",
                table: "Consultants",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Billings_BillingId",
                table: "Projects",
                column: "BillingId",
                principalTable: "Billings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTimeHistory_Projects_ProjectIdId",
                table: "ProjectTimeHistory",
                column: "ProjectIdId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTimeHistory_TimeHistories_TimeIdId",
                table: "ProjectTimeHistory",
                column: "TimeIdId",
                principalTable: "TimeHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Billings_BillingId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TimeHistories_TimeHistoryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_AspNetUsers_UserId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultants_Projects_ProjectId",
                table: "Consultants");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Billings_BillingId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTimeHistory_Projects_ProjectIdId",
                table: "ProjectTimeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTimeHistory_TimeHistories_TimeIdId",
                table: "ProjectTimeHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeHistories",
                table: "TimeHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultants",
                table: "Consultants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billings",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Consultants");

            migrationBuilder.RenameTable(
                name: "TimeHistories",
                newName: "timeHistories");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "projects");

            migrationBuilder.RenameTable(
                name: "Consultants",
                newName: "consultants");

            migrationBuilder.RenameTable(
                name: "Billings",
                newName: "billings");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_BillingId",
                table: "projects",
                newName: "IX_projects_BillingId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultants_UserId",
                table: "consultants",
                newName: "IX_consultants_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultants_ProjectId",
                table: "consultants",
                newName: "IX_consultants_ProjectId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_timeHistories",
                table: "timeHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projects",
                table: "projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_consultants",
                table: "consultants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_billings",
                table: "billings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_billings_BillingId",
                table: "AspNetUsers",
                column: "BillingId",
                principalTable: "billings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_projects_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_timeHistories_TimeHistoryId",
                table: "AspNetUsers",
                column: "TimeHistoryId",
                principalTable: "timeHistories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_consultants_AspNetUsers_UserId",
                table: "consultants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_consultants_projects_ProjectId",
                table: "consultants",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_billings_BillingId",
                table: "projects",
                column: "BillingId",
                principalTable: "billings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTimeHistory_projects_ProjectIdId",
                table: "ProjectTimeHistory",
                column: "ProjectIdId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTimeHistory_timeHistories_TimeIdId",
                table: "ProjectTimeHistory",
                column: "TimeIdId",
                principalTable: "timeHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
