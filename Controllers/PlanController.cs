using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Contexts;
using MVC02.Repositories.Interfaces;
using MVC02.ViewModels;

namespace MVC02.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanRepository _planRepository;
        private readonly IMembershipRepository _membershipRepository;

        public PlanController(IPlanRepository planRepository, IMembershipRepository membershipRepository)
        {
            _planRepository = planRepository;
            _membershipRepository = membershipRepository;
        }
        public async Task<IActionResult> Index()
        {
            var plans = await _planRepository.GetllAsync();
            var planViewModel = plans.Select(P=>new PlanViewModel
            {
                Id = P.Id,
                Description = P.Description,
                IsActive = P.IsActive,
                Name = P.Name,
                Price = P.Price,
            });
            return View(planViewModel);
        }

        #region Edit
        #region Get
        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken ct)
        {
            var plan = await _planRepository.GetPlanByIdAsync(id, ct);
            if (plan is null || !plan.IsActive)
            {
                TempData["ErrorMessage"] = "This Plan Can not Be Edited";
                return RedirectToAction(nameof(Index));
            }

            var HasCurrentMembershipsAsync =
                await _membershipRepository.AnyAsync(m => m.PlanId == id && m.EndDate > DateTime.Now, ct);

            if (HasCurrentMembershipsAsync)
            {
                TempData["ErrorMessage"] = "This Plan Can not Be Edited";
                return RedirectToAction(nameof(Index));
            }

            var ViewModel = new UpdateViewModel()
            {
                PlanName = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price,

            };
            return View(ViewModel);
#endregion
        #endregion

        }
        #region Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, UpdateViewModel updatedplan, CancellationToken ct)
        {
            if (!ModelState.IsValid) return View(updatedplan);
            var plan = await _planRepository.GetPlanByIdAsync(id, ct);
            if (plan is null || !plan.IsActive)
            {
                TempData["ErrorMessage"] = "This Plan Can not Be Edited";
                return RedirectToAction(nameof(Index));
            }

            var HasCurrentMembershipsAsync =
                await _membershipRepository.AnyAsync(m => m.PlanId == id && m.EndDate > DateTime.Now, ct);

            if (HasCurrentMembershipsAsync)
            {
                TempData["ErrorMessage"] = "This Plan Can not Be Edited";
                return RedirectToAction(nameof(Index));
            }

            plan.Description = updatedplan.Description;
            plan.Price = updatedplan.Price;

            plan.DurationDays = updatedplan.DurationDays;
            plan.UpdatedAt = DateTime.Now;
            var result = await _planRepository.UpdateAsync(ct) > 0;
            if (result)
            {
                TempData["SucessMessage"] = "Plan Updated Sucessfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Plan Failed To Update");
                return View(updatedplan);
            }
        }
        #endregion
    }
}
