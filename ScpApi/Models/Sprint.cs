using System;
using System.Collections.Generic;

namespace ScpApi.Models
{
    public class Sprint
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FeatureFreezeDate { get; set; }
        public decimal BufferPercent { get; set; }
        public int ActualPointsCompleted { get; set; }
        public List<Breakdown> Breakdowns { get; } = new List<Breakdown>();
        public List<TeamMemberSprint> TeamMemberSprints { get; } = new List<TeamMemberSprint>();
    }
}