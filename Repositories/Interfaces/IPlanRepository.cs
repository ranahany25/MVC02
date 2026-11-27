using MVC02.Entities;

namespace MVC02.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetllAsync(CancellationToken ct = default);
        Task<Plan?> GetPlanByIdAsync( int id ,CancellationToken ct = default);
        Task<int> UpdateAsync(CancellationToken ct = default);
    }
}
