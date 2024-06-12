using Domain.Instructions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal sealed class InstructionRepository(ApplicationDbContext context) : IInstructionRepository
{
    public Task<Instruction?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Instructions.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public void Insert(Instruction instruction)
    {
        context.Instructions.Add(instruction);
    }
}
