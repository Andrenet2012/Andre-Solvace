
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.Domain.Entities.ActionPlan;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;
using Solvace.TechCase.Repository.Interface;
using Solvace.TechCase.Repository.Utilities;
using Solvace.TechCase.Services;
using System.Numerics;

namespace Solvace.TechCase.API.Controllers;


#region QUESTION 1
// TYPE YOUR RESPONSE HERE: Foi resolvido utilizando o princípio (Interface Segregation Principle)
#endregion


[ApiController]
[Route("api/v1/[controller]")]
public class PlanController : ControllerBase
{
    private readonly IActionPlanService _actionPlanService;
    public PlanController(IActionPlanService actionPlanService)
    {
        _actionPlanService = actionPlanService;
    }

    // POST: api/ActionPlan
   // <snippet_Create>
    [HttpPost("create")]
    public async Task<ActionResult<ActionPlanDto>> Create([FromBody] CreateActionPlan actionPlan)
    {
        var result = await _actionPlanService.Create(actionPlan);
        return Created($"/api/actionplans/{result.Id}", result);
    }

    [HttpPost("Encerrar/{id}")]
    public async Task<ActionResult<ActionPlanDto>> EncerrarPlan(int id)
    {
        var result = await _actionPlanService.EncerrarPlan(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<ActionResult<ActionPlanDto>> Update(int id, ActionPlanUpdate actionPlan)
    {

        if (actionPlan.Name == null || actionPlan.Description == null)
        {
            return BadRequest();
        }

        var action = await _actionPlanService.ObterPorIdAsync(id);
        if (action == null)
        {
            return NotFound();
        }

        await _actionPlanService.Update(action, actionPlan);
        return NoContent();
    }

    // GET: api/ActionPlan/1
    // <snippet_GetByID>
    [HttpGet("{id}")]
    public async Task<ActionResult<ActionPlan>> ObterPorId(long id)
    {
        var actionPlan = await _actionPlanService.ObterPorIdAsync(id);

        if (actionPlan == null)
            return NotFound("Pedido não encontrado.");

        return Ok(actionPlan);
    }

    // DELETE: api/ActionPlan/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActionPlan(long id)
    {
        var actionPlan = await _actionPlanService.ObterPorIdAsync(id);
        if (actionPlan == null)
        {
            return NotFound();
        }

        await _actionPlanService.delete(actionPlan);

        return NoContent();
    }    

    [HttpGet("Todos")]
    public async Task<ActionResult<PaginatedList<ActionPlanDto>>> GetListaPaginada([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _actionPlanService.ListaPaginada(pageNumber, pageSize);
        return Ok(result);
    }

}
