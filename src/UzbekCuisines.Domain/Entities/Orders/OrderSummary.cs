namespace UzbekCuisines.Domain.Entities.Orders;

public record OrderSummary(Guid Id, Guid CustomerId, decimal totalPrice);
