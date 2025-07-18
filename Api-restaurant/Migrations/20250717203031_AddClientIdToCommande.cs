using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_restaurant.Migrations
{
    /// <inheritdoc />
    public partial class AddClientIdToCommande : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Commandes_CommandeId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Clients_clientsId",
                table: "Commandes");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CommandeId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CommandeId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "clientsId",
                table: "Commandes",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "DateCommande",
                table: "Commandes",
                newName: "StatutLivraison");

            migrationBuilder.RenameIndex(
                name: "IX_Commandes_clientsId",
                table: "Commandes",
                newName: "IX_Commandes_ClientId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Commandes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "MontantTotal",
                table: "Commandes",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDeRue",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodePostal",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Clients_ClientId",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "MontantTotal",
                table: "Commandes");

            migrationBuilder.RenameColumn(
                name: "StatutLivraison",
                table: "Commandes",
                newName: "DateCommande");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Commandes",
                newName: "clientsId");

            migrationBuilder.RenameIndex(
                name: "IX_Commandes_ClientId",
                table: "Commandes",
                newName: "IX_Commandes_clientsId");

            migrationBuilder.AlterColumn<int>(
                name: "Telephone",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "NumeroDeRue",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CodePostal",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "CommandeId",
                table: "Articles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CommandeId",
                table: "Articles",
                column: "CommandeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Commandes_CommandeId",
                table: "Articles",
                column: "CommandeId",
                principalTable: "Commandes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Clients_clientsId",
                table: "Commandes",
                column: "clientsId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
