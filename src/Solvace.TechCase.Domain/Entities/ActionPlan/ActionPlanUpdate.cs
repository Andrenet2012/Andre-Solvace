
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;

namespace Solvace.TechCase.Domain.Entities.ActionPlan;

/// <summary>
/// Represents a ActionPlan entity.
/// </summary>
public class ActionPlanUpdate : EntityBase
{

    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(4000)]
    public required string Description { get; set; }
   

    public static class Factories
        {
        public static ActionPlanUpdate Update(string name, string description)
        {
            return new ActionPlanUpdate
            {
                Name = name,
                Description = description,
                ExternalId = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
        }

    }
}
