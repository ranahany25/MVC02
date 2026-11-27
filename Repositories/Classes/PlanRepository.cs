using Microsoft.EntityFrameworkCore;
using MVC02.Contexts;
using MVC02.Entities;
using MVC02.Repositories.Interfaces;

namespace MVC02.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext _dbContext;

        public PlanRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Plan>> GetllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Plans.AsNoTracking().ToListAsync();
        }

        public async Task<Plan?> GetPlanByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.Plans.FindAsync([id], cancellationToken: ct);
        }

        public async Task<int> UpdateAsync(CancellationToken ct = default)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(ct);
            }

            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }

        }
    }
}
