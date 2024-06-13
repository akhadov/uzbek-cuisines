using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class SecondCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "dishes",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_dishes", x => x.id));

        migrationBuilder.CreateTable(
            name: "recipes",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                dish_id = table.Column<Guid>(type: "uuid", nullable: false),
                category_id = table.Column<Guid>(type: "uuid", nullable: false),
                recipe_ingredient_id = table.Column<Guid>(type: "uuid", nullable: false),
                prep_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                cook_time = table.Column<TimeSpan>(type: "interval", nullable: false),
                servings = table.Column<int>(type: "integer", nullable: false),
                image_path = table.Column<string>(type: "text", nullable: false),
                description = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_recipes", x => x.id);
                table.ForeignKey(
                    name: "fk_recipes_categories_category_id",
                    column: x => x.category_id,
                    principalSchema: "public",
                    principalTable: "categories",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_recipes_dishes_dish_id",
                    column: x => x.dish_id,
                    principalSchema: "public",
                    principalTable: "dishes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_recipes_users_user_id",
                    column: x => x.user_id,
                    principalSchema: "public",
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "instructions",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                recipe_id = table.Column<Guid>(type: "uuid", nullable: false),
                step_number = table.Column<int>(type: "integer", nullable: false),
                description = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_instructions", x => x.id);
                table.ForeignKey(
                    name: "fk_instructions_recipes_recipe_id",
                    column: x => x.recipe_id,
                    principalSchema: "public",
                    principalTable: "recipes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "recipe_ingredients",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                recipe_id = table.Column<Guid>(type: "uuid", nullable: false),
                amount = table.Column<decimal>(type: "numeric", nullable: false),
                unit = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_recipe_ingredients", x => x.id);
                table.ForeignKey(
                    name: "fk_recipe_ingredients_recipes_recipe_id",
                    column: x => x.recipe_id,
                    principalSchema: "public",
                    principalTable: "recipes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "reviews",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                recipe_id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                rating = table.Column<int>(type: "integer", nullable: false),
                comment = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                created_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_reviews", x => x.id);
                table.ForeignKey(
                    name: "fk_reviews_recipes_recipe_id",
                    column: x => x.recipe_id,
                    principalSchema: "public",
                    principalTable: "recipes",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_reviews_users_user_id",
                    column: x => x.user_id,
                    principalSchema: "public",
                    principalTable: "users",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ingredients",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                recipe_ingredient_id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_ingredients", x => x.id);
                table.ForeignKey(
                    name: "fk_ingredients_recipe_ingredients_recipe_ingredient_id",
                    column: x => x.recipe_ingredient_id,
                    principalSchema: "public",
                    principalTable: "recipe_ingredients",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "ix_ingredients_recipe_ingredient_id",
            schema: "public",
            table: "ingredients",
            column: "recipe_ingredient_id");

        migrationBuilder.CreateIndex(
            name: "ix_instructions_recipe_id",
            schema: "public",
            table: "instructions",
            column: "recipe_id");

        migrationBuilder.CreateIndex(
            name: "ix_recipe_ingredients_recipe_id",
            schema: "public",
            table: "recipe_ingredients",
            column: "recipe_id");

        migrationBuilder.CreateIndex(
            name: "ix_recipes_category_id",
            schema: "public",
            table: "recipes",
            column: "category_id");

        migrationBuilder.CreateIndex(
            name: "ix_recipes_dish_id",
            schema: "public",
            table: "recipes",
            column: "dish_id");

        migrationBuilder.CreateIndex(
            name: "ix_recipes_user_id",
            schema: "public",
            table: "recipes",
            column: "user_id");

        migrationBuilder.CreateIndex(
            name: "ix_reviews_recipe_id",
            schema: "public",
            table: "reviews",
            column: "recipe_id");

        migrationBuilder.CreateIndex(
            name: "ix_reviews_user_id",
            schema: "public",
            table: "reviews",
            column: "user_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ingredients",
            schema: "public");

        migrationBuilder.DropTable(
            name: "instructions",
            schema: "public");

        migrationBuilder.DropTable(
            name: "reviews",
            schema: "public");

        migrationBuilder.DropTable(
            name: "recipe_ingredients",
            schema: "public");

        migrationBuilder.DropTable(
            name: "recipes",
            schema: "public");

        migrationBuilder.DropTable(
            name: "dishes",
            schema: "public");
    }
}
