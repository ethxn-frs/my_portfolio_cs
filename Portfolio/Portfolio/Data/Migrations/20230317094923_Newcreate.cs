using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Data.Migrations
{
    public partial class Newcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Project_ProjectId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_School_SchoolId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Skill_SkillId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ProjectId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_SchoolId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_SkillId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certification",
                table: "Certification");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "School",
                newName: "Schools");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "Certification",
                newName: "Certifications");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProjectId",
                table: "Image",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_SchoolId",
                table: "Image",
                column: "SchoolId",
                unique: true,
                filter: "[SchoolId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_SkillId",
                table: "Image",
                column: "SkillId",
                unique: true,
                filter: "[SkillId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Projects_ProjectId",
                table: "Image",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Schools_SchoolId",
                table: "Image",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Skills_SkillId",
                table: "Image",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Projects_ProjectId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Schools_SchoolId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Skills_SkillId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ProjectId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_SchoolId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_SkillId",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "School");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "Certifications",
                newName: "Certification");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School",
                table: "School",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certification",
                table: "Certification",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProjectId",
                table: "Image",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_SchoolId",
                table: "Image",
                column: "SchoolId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_SkillId",
                table: "Image",
                column: "SkillId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Project_ProjectId",
                table: "Image",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_School_SchoolId",
                table: "Image",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Skill_SkillId",
                table: "Image",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
