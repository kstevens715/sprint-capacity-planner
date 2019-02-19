using System;

namespace ScpApi.Models
{
    public class Breakdown
    {
        public string Id { get; }
        public string Name { get; set; }
        public decimal TargetPercent { get; set; }
        public decimal ActualPoints { get; set; }

        // Will return the number of points for this breakdown that should be budgeted.
        public decimal TargetPoints
        {
            get
            {
                return 0.0m;
            }
        }

        // Will return the actual percent of a sprint spent on this breakdown
        public decimal ActualPercent
        {
            get
            {
                return 0.0m;
            }
        }
    }
}