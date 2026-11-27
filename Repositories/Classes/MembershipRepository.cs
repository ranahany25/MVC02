using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVC02.Contexts;
using MVC02.Entities;
using MVC02.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MVC02.Repositories.Classes
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly GymDbContext _dbContext;
        public MembershipRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AnyAsync(Expression<Func<Membership, bool>> Predicate, CancellationToken ct = default)
        {
            return await _dbContext.Memberships.AnyAsync(Predicate, ct);
        }
    }
}
