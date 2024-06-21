using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Instructions;
using SharedKernel;

namespace Application.Instructions.Update;
internal sealed class UpdateInstructionCommandHandler(
    IInstructionRepository instructionRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateInstructionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(UpdateInstructionCommand request, CancellationToken cancellationToken)
    {
        Instruction? instruction = await instructionRepository.GetByIdAsync(request.InstructionId, cancellationToken);

        if (instruction is null)
        {
            return Result.Failure<Guid>(InstructionErrors.NotFound(request.InstructionId));
        }
        var description = new Description(request.Description);

        instruction.Update(request.StepNumber, description);

        instructionRepository.Update(instruction);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return instruction.Id;
    }
}
