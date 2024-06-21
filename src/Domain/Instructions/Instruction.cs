using Domain.Instructions.Events;
using SharedKernel;

namespace Domain.Instructions;
public sealed class Instruction : Entity
{
    private Instruction(Guid id, Guid recipeId, int stepNumber, Description description)
        : base(id)
    {
        RecipeId = recipeId;
        StepNumber = stepNumber;
        Description = description;
    }

    private Instruction() { }

    public Guid RecipeId { get; private set; }
    public int StepNumber { get; private set; }
    public Description Description { get; private set; }

    public static Instruction Create(Guid recipeId, int stepNumber, Description description)
    {
        var instruction = new Instruction(Guid.NewGuid(), recipeId, stepNumber, description);

        instruction.Raise(new InstructionCreatedDomainEvent(instruction.Id));

        return instruction;
    }

    public void Update(int stepNumber, Description description)
    {
        StepNumber = stepNumber;
        Description = description;
    }
}
