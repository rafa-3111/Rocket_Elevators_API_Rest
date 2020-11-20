using System;
using System.Collections.Generic;

namespace RocketApi.Models
{
    public partial class Interventions
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? EmployeeId { get; set; }
        public string BatteryId { get; set; }
        public long? BuildingId { get; set; }
        public long? ElevatorId { get; set; }
        public string ColumnId { get; set; }
        public string AuthorId { get; set; }
        public string Status { get; set; }
        public DateTime? Intervention_Start { get; set; }
        public DateTime? Intervention_Finish { get; set; }
        public string Results { get; set; }
        public string Repport { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
