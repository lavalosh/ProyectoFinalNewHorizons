using Muchik.Market.Security.Domain.Entities;
using Muchik.Market.Security.Domain.Interfaces;
using Muchik.Market.Security.Infrastructure.Context;

namespace Muchik.Market.Security.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(SecurityContext context) : base(context) { }
}