using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Instructions;
using SharedKernel;

namespace Application.Instructions.Remove;
internal sealed class RemoveInstructionCommandHandler(
    IInstructionRepository instructionRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RemoveInstructionCommand>
{
    public async Task<Result> Handle(RemoveInstructionCommand request, CancellationToken cancellationToken)
    {
        Instruction? instruction = await instructionRepository.GetByIdAsync(request.InstructionId, cancellationToken);

        if (instruction is null)
        {
            return Result.Failure(InstructionErrors.NotFound(request.InstructionId));
        }

        instructionRepository.Remove(instruction);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
