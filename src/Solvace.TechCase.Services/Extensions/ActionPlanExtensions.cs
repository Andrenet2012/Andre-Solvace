using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;

namespace Solvace.TechCase.Services.Extensions;

public static class ActionPlanExtensions
{
    public static ActionPlanDto AsActionPlanDto(this ActionPlan plan) => new ActionPlanDto
    {
        Name = plan.Name,
        Description = plan.Description,
        EndedAt = plan.EndedAt,
        Id = plan.Id,
        Status = plan.ActionPlanStatusId,
        TypeName = plan.TypeName
    };

}
