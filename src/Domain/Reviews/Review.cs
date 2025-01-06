using Domain.Recipes;
using Domain.Reviews.Events;
using SharedKernel;

namespace Domain.Reviews;
public sealed class Review : Entity
{
    private Review(
        Guid id,
        Guid recipeId,
        Guid userId,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
    {
        Id = id;
        RecipeId = recipeId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }

    private Review()
    {
    }

    public Guid Id { get; private set; }

    public Guid RecipeId { get; private set; }

    public Guid UserId { get; private set; }

    public Rating Rating { get; private set; }

    public Comment Comment { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public static Review Create(
        Recipe recipe,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
    {
        var review = new Review(
            Guid.NewGuid(),
            recipe.Id,
            recipe.UserId,
            rating,
            comment,
            createdOnUtc);

        review.Raise(new ReviewCreatedDomainEvent(review.Id));

        return review;
    }

    public void Update(Rating rating, Comment comment)
    {
        Rating = rating;
        Comment = comment;
    }
}
