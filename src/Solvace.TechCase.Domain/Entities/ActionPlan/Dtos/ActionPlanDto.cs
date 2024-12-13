using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvace.TechCase.Domain.Entities.ActionPlan.Dtos
{
    public class ActionPlanDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public long Status { get; set; }
        public DateTimeOffset? EndedAt { get; set; }
        public required string TypeName { get; set; }
    }
}