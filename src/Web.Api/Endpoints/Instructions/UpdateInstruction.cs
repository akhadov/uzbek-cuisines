using Application.Instructions.Update;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Instructions;

internal sealed class UpdateInstruction : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("instructions/{instructionId}", async (
            Guid instructionId,
            UpdateInstructionRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateInstructionCommand(
                instructionId,
                request.StepNumber,
                request.Description);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Instructions);
    }
}
