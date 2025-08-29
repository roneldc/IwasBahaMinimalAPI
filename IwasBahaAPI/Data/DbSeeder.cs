using IwasBahaAPI.Models;

namespace IwasBahaAPI.Data
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (db.RoadStatusUpdates.Any()) return; // already seeded

            var update = new RoadStatusUpdate
            {
                City = "Quezon City",
                ReportedAt = new DateTime(2025, 8, 28, 17, 1, 0),
                Statuses = new List<RoadStatus>
            {
                new RoadStatus
                {
                    Condition = "Flood Subsided",
                    Barangay = "Brgy. Del Monte",
                    Roads = new List<Road>
                    {
                        new Road { Name = "A Bonifacio Sgt. Pineda" },
                        new Road { Name = "A Bonifacio Sgt. Rivera" }
                    }
                },
                new RoadStatus
                {
                    Condition = "Flood Subsided",
                    Barangay = "Brgy. Pinyahan",
                    Roads = new List<Road>
                    {
                        new Road { Name = "Elliptical Road, Diliman" }
                    }
                },
                new RoadStatus
                {
                    Condition = "Gutter Deep",
                    Barangay = "Brgy. Sienna",
                    Roads = new List<Road>
                    {
                        new Road { Name = "NS Amoranto Cor. Don Jose" }
                    }
                }
            }
            };

            db.RoadStatusUpdates.Add(update);
            db.SaveChanges();
        }
    }
}
