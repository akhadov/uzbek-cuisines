using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzbekCuisines.Application.Common.Messaging;
using UzbekCuisines.Domain.Repositories;

namespace UzbekCuisines.Application.Foods.Commands.CreateFood;

public sealed record class CreateFoodCommand() : ICommand
{
}
