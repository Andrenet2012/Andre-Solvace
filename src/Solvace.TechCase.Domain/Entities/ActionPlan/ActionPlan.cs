
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text.Json.Serialization;
using Solvace.TechCase.Domain.Entities.ActionPlan.Enums;

namespace Solvace.TechCase.Domain.Entities.ActionPlan;

/// <summary>
/// Represents a ActionPlan entity.
/// </summary>
public class ActionPlan : EntityBase
{

    
    [MaxLength(50)]
    public required string Name { get; set; }
    
    [MaxLength(4000)]
    public required string Description { get; set; }

    public required long ActionPlanStatusId { get; set; }
    public ActionPlanStatus ActionPlanStatus { get; set; }
    public DateTimeOffset? EndedAt { get; set; }

    [MaxLength(30)]
    public required string TypeName { get; set; }

    public static class Factories
        {
            public static ActionPlan Create(string name, string description, EActionPlanStatus status, string typeName)
            {
                return new ActionPlan
                {
                    Name = name,
                    Description = description,
                    ActionPlanStatusId = (long)status,
                    TypeName = typeName,
                    ExternalId = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    EndedAt = DateTimeOffset.UtcNow,
                };
            }            

    }
}
