using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TurtlePizzaria.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INGREDIENT",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PIZZA",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIZZA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PIZZA_INGREDIENT",
                columns: table => new
                {
                    PizzaId = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIZZA_INGREDIENT", x => new { x.PizzaId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_PIZZA_INGREDIENT_INGREDIENT_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "INGREDIENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PIZZA_INGREDIENT_PIZZA_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "PIZZA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    Comment = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDER_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PIZZA_ORDER",
                columns: table => new
                {
                    PizzaId = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PIZZA_ORDER", x => new { x.PizzaId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_PIZZA_ORDER_ORDER_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PIZZA_ORDER_PIZZA_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "PIZZA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_UserId",
                table: "ORDER",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PIZZA_INGREDIENT_IngredientId",
                table: "PIZZA_INGREDIENT",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PIZZA_ORDER_OrderId",
                table: "PIZZA_ORDER",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PIZZA_INGREDIENT");

            migrationBuilder.DropTable(
                name: "PIZZA_ORDER");

            migrationBuilder.DropTable(
                name: "INGREDIENT");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "PIZZA");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
