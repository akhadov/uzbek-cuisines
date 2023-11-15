using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Domain.Entities.Orders;

namespace UzbekCuisines.Application.Orders.Create;

public record OrderCreatedEvent(OrderId OrderId) : INotification;
