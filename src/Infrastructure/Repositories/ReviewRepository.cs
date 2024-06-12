using Domain.Reviews;
using Infrastructure.Database;

namespace Infrastructure.Repositories;
internal sealed class ReviewRepository(ApplicationDbContext context) : IReviewRepository
{
    public void Add(Review review)
    {
        context.Reviews.Add(review);
    }
}
