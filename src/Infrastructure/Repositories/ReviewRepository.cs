using Domain.Reviews;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal sealed class ReviewRepository(ApplicationDbContext context) : IReviewRepository
{
    public Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Reviews.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public void Add(Review review)
    {
        context.Reviews.Add(review);
    }


    public void Remove(Review review)
    {
        context.Reviews.Remove(review);
    }

    public void Update(Review review)
    {
        context.Reviews.Update(review);
    }
}
