using MediatR;
using System.Transactions;
using System.Windows.Input;

namespace UzbekCuisines.Application.Common.Behaviours;

public class UnitOfWorkBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICommand
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehaviour(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled))
        {
            var response = await next();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            transaction.Complete();

            return response;
        }
    }


}
