using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Users.GetById;
public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserResponse>;
