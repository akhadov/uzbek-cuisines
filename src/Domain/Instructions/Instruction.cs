using Domain.Instructions.Events;
using SharedKernel;

namespace Domain.Instructions;
public sealed class Instruction : Entity
{
    private Instruction(Guid id, int stepNumber, Description description)
        : base(id)
    {
        StepNumber = stepNumber;
        Description = description;
    }

    private Instruction() { }

    public int StepNumber { get; private set; }
    public Description Description { get; private set; }

    public static Instruction Create(int stepNumber, Description description)
    {
        var instruction = new Instruction(Guid.NewGuid(), stepNumber, description);

        instruction.Raise(new InstructionCreatedDomainEvent(instruction.Id));

        return instruction;
    }
}
