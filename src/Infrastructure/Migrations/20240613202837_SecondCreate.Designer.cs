﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240613202837_SecondCreate")]
    partial class SecondCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.ComplexProperty<Dictionary<string, object>>("Name", "Domain.Categories.Category.Name#Name", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("name");
                        });

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", "public");
                });

            modelBuilder.Entity("Domain.Dishes.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_dishes");

                    b.ToTable("dishes", "public");
                });

            modelBuilder.Entity("Domain.Instructions.Instruction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_id");

                    b.Property<int>("StepNumber")
                        .HasColumnType("integer")
                        .HasColumnName("step_number");

                    b.ComplexProperty<Dictionary<string, object>>("Description", "Domain.Instructions.Instruction.Description#Description", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("description");
                        });

                    b.HasKey("Id")
                        .HasName("pk_instructions");

                    b.HasIndex("RecipeId")
                        .HasDatabaseName("ix_instructions_recipe_id");

                    b.ToTable("instructions", "public");
                });

            modelBuilder.Entity("Domain.RecipeIngredients.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("RecipeIngredientId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_ingredient_id");

                    b.ComplexProperty<Dictionary<string, object>>("Name", "Domain.RecipeIngredients.Ingredient.Name#Name", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("name");
                        });

                    b.HasKey("Id")
                        .HasName("pk_ingredients");

                    b.HasIndex("RecipeIngredientId")
                        .HasDatabaseName("ix_ingredients_recipe_ingredient_id");

                    b.ToTable("ingredients", "public");
                });

            modelBuilder.Entity("Domain.RecipeIngredients.RecipeIngredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_id");

                    b.ComplexProperty<Dictionary<string, object>>("Unit", "Domain.RecipeIngredients.RecipeIngredient.Unit#Unit", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("unit");
                        });

                    b.HasKey("Id")
                        .HasName("pk_recipe_ingredients");

                    b.HasIndex("RecipeId")
                        .HasDatabaseName("ix_recipe_ingredients_recipe_id");

                    b.ToTable("recipe_ingredients", "public");
                });

            modelBuilder.Entity("Domain.Recipes.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<TimeSpan>("CookTime")
                        .HasColumnType("interval")
                        .HasColumnName("cook_time");

                    b.Property<Guid>("DishId")
                        .HasColumnType("uuid")
                        .HasColumnName("dish_id");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_path");

                    b.Property<TimeSpan>("PrepTime")
                        .HasColumnType("interval")
                        .HasColumnName("prep_time");

                    b.Property<Guid>("RecipeIngredientId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_ingredient_id");

                    b.Property<int>("Servings")
                        .HasColumnType("integer")
                        .HasColumnName("servings");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.ComplexProperty<Dictionary<string, object>>("Description", "Domain.Recipes.Recipe.Description#Description", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("description");
                        });

                    b.HasKey("Id")
                        .HasName("pk_recipes");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_recipes_category_id");

                    b.HasIndex("DishId")
                        .HasDatabaseName("ix_recipes_dish_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_recipes_user_id");

                    b.ToTable("recipes", "public");
                });

            modelBuilder.Entity("Domain.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on_utc");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid")
                        .HasColumnName("recipe_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_reviews");

                    b.HasIndex("RecipeId")
                        .HasDatabaseName("ix_reviews_recipe_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_reviews_user_id");

                    b.ToTable("reviews", "public");
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("HasPublicProfile")
                        .HasColumnType("boolean")
                        .HasColumnName("has_public_profile");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "Domain.Users.User.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("email");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Name", "Domain.Users.User.Name#Name", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("name");
                        });

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", "public");
                });

            modelBuilder.Entity("Domain.Instructions.Instruction", b =>
                {
                    b.HasOne("Domain.Recipes.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_instructions_recipes_recipe_id");
                });

            modelBuilder.Entity("Domain.RecipeIngredients.Ingredient", b =>
                {
                    b.HasOne("Domain.RecipeIngredients.RecipeIngredient", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_ingredients_recipe_ingredients_recipe_ingredient_id");
                });

            modelBuilder.Entity("Domain.RecipeIngredients.RecipeIngredient", b =>
                {
                    b.HasOne("Domain.Recipes.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_recipe_ingredients_recipes_recipe_id");
                });

            modelBuilder.Entity("Domain.Recipes.Recipe", b =>
                {
                    b.HasOne("Domain.Categories.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_recipes_categories_category_id");

                    b.HasOne("Domain.Dishes.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_recipes_dishes_dish_id");

                    b.HasOne("Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_recipes_users_user_id");
                });

            modelBuilder.Entity("Domain.Reviews.Review", b =>
                {
                    b.HasOne("Domain.Recipes.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_recipes_recipe_id");

                    b.HasOne("Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_users_user_id");
                });

            modelBuilder.Entity("Domain.RecipeIngredients.RecipeIngredient", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
