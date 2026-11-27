using MVC02.Entities;
using System.Linq.Expressions;

namespace MVC02.Repositories.Interfaces
{
    public interface IMembershipRepository
    {
        Task<bool> AnyAsync(Expression<Func<Membership, bool>> Predicate, CancellationToken ct = default);
    }
}
