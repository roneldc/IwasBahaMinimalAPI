namespace IwasBahaAPI.Models
{
    public class RoadStatusUpdate
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public DateTime ReportedAt { get; set; }

        // Navigation property
        public List<RoadStatus> Statuses { get; set; } = new();
    }

    public class RoadStatus
    {
        public int Id { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string Barangay { get; set; } = string.Empty;

        // Navigation property
        public List<Road> Roads { get; set; } = new();

        // Foreign key back to RoadStatusUpdate
        public int RoadStatusUpdateId { get; set; }
    }

    public class Road
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Foreign key back to RoadStatus
        public int RoadStatusId { get; set; }
    }
}
