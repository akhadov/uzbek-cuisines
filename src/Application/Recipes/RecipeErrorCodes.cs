namespace Application.Recipes;
public static class RecipeErrorCodes
{
    public static class CreateRecipe
    {
        public const string MissingUserId = nameof(MissingUserId);
    }

    public static class RemoveRecipe
    {
        public const string MissingRecipeId = nameof(MissingRecipeId);
    }

    public static class AddIngredients
    {
        public const string MissingIngredients = nameof(MissingIngredients);
    }
}
