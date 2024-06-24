using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class Create_Database : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "public");

        migrationBuilder.CreateTable(
            name: "categories",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_categories", x => x.id));

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
            name: "permission",
            schema: "public",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_permission", x => x.id));

        migrationBuilder.CreateTable(
            name: "role",
            schema: "public",
            columns: table => new
            {
                id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_role", x => x.id));

        migrationBuilder.CreateTable(
            name: "users",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                first_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                last_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                email = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                identity_id = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table => table.PrimaryKey("pk_users", x => x.id));

        migrationBuilder.CreateTable(
            name: "role_permission",
            schema: "public",
            columns: table => new
            {
                role_id = table.Column<int>(type: "integer", nullable: false),
                permission_id = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_role_permission", x => new { x.role_id, x.permission_id });
                table.ForeignKey(
                    name: "fk_role_permission_permission_permission_id",
                    column: x => x.permission_id,
                    principalSchema: "public",
                    principalTable: "permission",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_role_permission_role_role_id",
                    column: x => x.role_id,
                    principalSchema: "public",
                    principalTable: "role",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "recipes",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                dish_id = table.Column<Guid>(type: "uuid", nullable: false),
                category_id = table.Column<Guid>(type: "uuid", nullable: false),
                prep_time = table.Column<int>(type: "integer", nullable: false),
                cook_time = table.Column<int>(type: "integer", nullable: false),
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
            name: "role_user",
            schema: "public",
            columns: table => new
            {
                roles_id = table.Column<int>(type: "integer", nullable: false),
                users_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_role_user", x => new { x.roles_id, x.users_id });
                table.ForeignKey(
                    name: "fk_role_user_role_roles_id",
                    column: x => x.roles_id,
                    principalSchema: "public",
                    principalTable: "role",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "fk_role_user_users_users_id",
                    column: x => x.users_id,
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
                recipe_id = table.Column<Guid>(type: "uuid", nullable: false),
                amount = table.Column<decimal>(type: "numeric", nullable: false),
                name = table.Column<string>(type: "text", nullable: false),
                unit = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_ingredients", x => x.id);
                table.ForeignKey(
                    name: "fk_ingredients_recipes_recipe_id",
                    column: x => x.recipe_id,
                    principalSchema: "public",
                    principalTable: "recipes",
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

        migrationBuilder.InsertData(
            schema: "public",
            table: "permission",
            columns: ["id", "name"],
            values: new object[] { 1, "users:read" });

        migrationBuilder.InsertData(
            schema: "public",
            table: "role",
            columns: ["id", "name"],
            values: new object[] { 1, "Registered" });

        migrationBuilder.InsertData(
            schema: "public",
            table: "role_permission",
            columns: ["permission_id", "role_id"],
            values: new object[] { 1, 1 });

        migrationBuilder.CreateIndex(
            name: "ix_ingredients_recipe_id",
            schema: "public",
            table: "ingredients",
            column: "recipe_id");

        migrationBuilder.CreateIndex(
            name: "ix_instructions_recipe_id",
            schema: "public",
            table: "instructions",
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

        migrationBuilder.CreateIndex(
            name: "ix_role_permission_permission_id",
            schema: "public",
            table: "role_permission",
            column: "permission_id");

        migrationBuilder.CreateIndex(
            name: "ix_role_user_users_id",
            schema: "public",
            table: "role_user",
            column: "users_id");

        migrationBuilder.CreateIndex(
            name: "ix_users_email",
            schema: "public",
            table: "users",
            column: "email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_users_identity_id",
            schema: "public",
            table: "users",
            column: "identity_id",
            unique: true);
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
            name: "role_permission",
            schema: "public");

        migrationBuilder.DropTable(
            name: "role_user",
            schema: "public");

        migrationBuilder.DropTable(
            name: "recipes",
            schema: "public");

        migrationBuilder.DropTable(
            name: "permission",
            schema: "public");

        migrationBuilder.DropTable(
            name: "role",
            schema: "public");

        migrationBuilder.DropTable(
            name: "categories",
            schema: "public");

        migrationBuilder.DropTable(
            name: "dishes",
            schema: "public");

        migrationBuilder.DropTable(
            name: "users",
            schema: "public");
    }
}
