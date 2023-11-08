namespace UzbekCuisines.Application.Orders.GetOrder;

public record OrderResponce(Guid Id, Guid CustomerId, List<LineItemResponce> LineItems);
