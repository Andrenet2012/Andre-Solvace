using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvace.TechCase.Repository.Interface
{
    public interface IActionPlanService
    {
        Task<ActionPlanDto> Create(CreateActionPlan plan);
        Task<ActionPlanDto> EncerrarPlan(int id);
        Task Update(ActionPlan action, ActionPlanUpdate plan);
        Task<ActionPlan?> ObterPorIdAsync(long id);
        Task delete(ActionPlan actionPlan);
        Task<PaginationDto<ActionPlanDto>> ListaPaginada(int pageNumber, int pageSize);
        Task<ActionPlan> ObterPorNameAsync(string name);
    }
}
