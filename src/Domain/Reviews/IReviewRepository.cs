namespace Domain.Reviews;
public interface IReviewRepository
{
    public Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Review review);

    void Update(Review review);

    void Remove(Review review);

}
