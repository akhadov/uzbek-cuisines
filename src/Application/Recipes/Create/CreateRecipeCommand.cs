﻿using Application.Abstractions.Messaging;

namespace Application.Recipes.Create;
public sealed record CreateRecipeCommand(
    Guid UserId,
    Guid DishId,
    Guid CategoryId,
    Guid RecipeIngredientId,
    string Description,
    TimeSpan PrepTime,
    TimeSpan CookTime,
    int Servings,
    string ImagePath) : ICommand<Guid>;
