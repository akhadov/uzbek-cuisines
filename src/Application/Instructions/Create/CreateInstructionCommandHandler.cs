using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Instructions;
using Domain.Recipes;
using SharedKernel;
using Description = Domain.Instructions.Description;

namespace Application.Instructions.Create;
internal sealed class CreateInstructionCommandHandler(
    IRecipeRepository recipeRepository,
    IInstructionRepository instructionRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateInstructionCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateInstructionCommand request, CancellationToken cancellationToken)
    {
        Recipe? recipe = await recipeRepository.GetByIdAsync(request.RecipeId, cancellationToken);
        if (recipe is null)
        {
            return Result.Failure<Guid>(RecipeErrors.NotFound(request.RecipeId));
        }

        var description = new Description(request.Description);
        var instruction = Instruction.Create(request.RecipeId, request.StepNumber, description);

        instructionRepository.Insert(instruction);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return instruction.Id;
    }
}
