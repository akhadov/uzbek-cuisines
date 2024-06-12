namespace Domain.Instructions;
public interface IInstructionRepository
{
    Task<Instruction?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Instruction instruction);
}
