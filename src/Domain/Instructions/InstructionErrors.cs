using SharedKernel;

namespace Domain.Instructions;
public static class InstructionErrors
{
    public static Error NotFound(Guid instructionId) => Error.NotFound(
        "Instructions.NotFound",
        $"The instruction with the Id = '{instructionId}' was not found");
}
