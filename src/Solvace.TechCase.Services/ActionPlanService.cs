using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;
using Solvace.TechCase.Repository.Contexts;
using Solvace.TechCase.Repository.Interface;
using Solvace.TechCase.Services.Extensions;

namespace Solvace.TechCase.Services
{
    public class ActionPlanService : IActionPlanService
    {
        private readonly DefaultContext _context;

        public ActionPlanService(DefaultContext context)
        {
            _context = context;
        }

        public async Task<ActionPlanDto> Create(CreateActionPlan plan)
        {
            try
            {
                if (StatusExists(plan.StatusId))
                    throw new ArgumentException("O Status informar invalido");

                var newPlan = ActionPlan.Factories.Create(
                name: plan.Name,
                description: plan.Description,
                status: plan.StatusId,
                typeName: plan.TypeName
                 );

                await _context.ActionPlans.AddAsync(newPlan);
                await _context.SaveChangesAsync();

                return newPlan.AsActionPlanDto();
            }
            catch
            {
                throw new ApplicationException("Ocorreu uma Falha na inclusão do produto");
            }
            
        }

        public async Task<ActionPlanDto> EncerrarPlan(int id)
        {
            try
            {
                var actionPlan = await _context.ActionPlans.FindAsync(long.Parse(id.ToString()));

                if (actionPlan == null)
                    throw new KeyNotFoundException("Não foi encontrado.");

                actionPlan.ActionPlanStatusId = (int)EActionPlanStatus.COMPLETED;
                actionPlan.EndedAt = DateTime.UtcNow;
                _context.ActionPlans.Update(actionPlan);
                await _context.SaveChangesAsync();

                return actionPlan.AsActionPlanDto();
            }
            catch
            {
                throw new ApplicationException("Application failed to create product, try later or contact administrator");
            }
        }

        public async Task Update(ActionPlan action, ActionPlanUpdate plan)
        {
            try
            {
                action.Name = plan.Name;
                action.Description = plan.Description;

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ApplicationException("Ocorreu um problema na atualização");
            }
            
        }

        public async Task<ActionPlan?> ObterPorIdAsync(long id)
        {
            var result = await _context.ActionPlans.FindAsync(id);

            if (result == null)
                return null;        

            return result;
        }

        public async Task delete(ActionPlan actionPlan)
        {
            _context.ActionPlans.Remove(actionPlan);
            await _context.SaveChangesAsync();
        }
        
        public async Task<PaginationDto<ActionPlanDto>> ListaPaginada(int pageNumber, int pageSize)
        {
            try
            {
                var (actionPlans, totalCount) = await _context.ActionPlans.AsNoTracking()
                                                                    .PaginateAsync(pageNumber, pageSize);

                return actionPlans.Select(x => x.AsActionPlanDto())
                                  .AsPaginationDto(totalCount, pageNumber, pageSize);
            }
            catch
            {
                throw new ApplicationException("Ocorreu um erro inesperado");
            }
        }

        public async Task<ActionPlan?> ObterPorNameAsync(string name)
        {
            return await _context.ActionPlans.FindAsync(name);
        }

        private bool StatusExists(EActionPlanStatus id)
        {
            return !Enum.IsDefined(typeof(EActionPlanStatus), id);
        }

    }
}