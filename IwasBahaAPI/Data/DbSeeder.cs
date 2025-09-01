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
                ReportedAt = new DateTime(2025, 8, 30, 19, 24, 0),
                Statuses = new List<RoadStatus>
                {
                    new RoadStatus
                    {
                        Condition = "Ankle Deep",
                        Barangay = "Brgy. Amihan",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Patino St. Cor. Palosapis" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Ankle Deep",
                        Barangay = "Brgy. Bagong Silangan",
                        Roads = new List<Road>
                        {
                            new Road { Name = "203 Ermin Garcia" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Gutter Deep",
                        Barangay = "Brgy. Ramon Magsaysay",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Edsa cor. Corregidor" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Gutter Deep",
                        Barangay = "Brgy. Sto. Domingo - Matalahib",
                        Roads = new List<Road>
                        {
                            new Road { Name = "P. Florentino St." },
                            new Road { Name = "Sto. Domingo cor. Maria Clara" },
                            new Road { Name = "Sto. Domingo cor. Tirad Pass" },
                            new Road { Name = "Biak na Bato cor. Calamba" },
                            new Road { Name = "Biak na Bato cor. Retiro" },
                            new Road { Name = "Biak na Bato cor. Samat" },
                            new Road { Name = "Sto Domingo cor. Simoun" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Knee Deep",
                        Barangay = "Brgy. Central",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Outer lane Q. Ave Elliptical Road" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Knee Deep",
                        Barangay = "Brgy. Apolonio Samson",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Antoinette St. Parkway Village" },
                            new Road { Name = "Christine St. Parkway Village" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Knee Deep",
                        Barangay = "Brgy. Masambong",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Toctocan St. cor. Capoas St." },
                            new Road { Name = "Masambong Elementary School" },
                            new Road { Name = "Lower Mangga St." }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Knee Deep",
                        Barangay = "Brgy. Culiat",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Visayas Central Ave." }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Knee Deep",
                        Barangay = "Brgy. Del Monte",
                        Roads = new List<Road>
                        {
                            new Road { Name = "G. Araneta from Victory to E. Rodriguez" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Knee Deep",
                        Barangay = "Brgy. Sto. Domingo - Matalahib",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Araneta Alleys" },
                            new Road { Name = "Biak na Bato cor. Don Manuel" },
                            new Road { Name = "P. Florentino Talipapa" },
                            new Road { Name = "Araneta cor. Calamba" },
                            new Road { Name = "Infront of Barangay Hall" },
                            new Road { Name = "Banawe cor. NS Amoranto" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Leg Deep",
                        Barangay = "Brgy. Sienna",
                        Roads = new List<Road>
                        {
                            new Road { Name = "NS Amoranto cor. Don Jose St." }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Leg Deep",
                        Barangay = "Brgy. Payatas",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Sapphire St." }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Leg Deep",
                        Barangay = "Brgy. Matandang Balara",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Kilusan St." }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Waist Deep",
                        Barangay = "Brgy. San Vicente",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Riverside St. and Alley 1 pook 2" },
                            new Road { Name = "Fatima Street" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Waist Deep",
                        Barangay = "Brgy. South Triangle",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Mother Ignacia cor. Madriñan" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Waist Deep",
                        Barangay = "Brgy. Masambong",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Capoas St. Masambong High School" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Waist Deep",
                        Barangay = "Brgy. Damayan",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Del Monte West Riverside" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Waist Deep",
                        Barangay = "Brgy. Quirino 2-A",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Pajo St. Interior Q2A" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Waist Deep",
                        Barangay = "Brgy. Del Monte",
                        Roads = new List<Road>
                        {
                            new Road { Name = "G. Araneta from Del Monte to Sto. Domingo" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Waist Deep",
                        Barangay = "Brgy. Tatalon",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Araneta cor. Victory" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Waist Deep",
                        Barangay = "Brgy. West Kamias",
                        Roads = new List<Road>
                        {
                            new Road { Name = "K1, K7, & K8th St." }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Waist Deep",
                        Barangay = "Brgy. Sto. Domingo - Matalahib",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Don Manuel cor. Don Jose" },
                            new Road { Name = "Araneta cor. Ma. Clara" },
                            new Road { Name = "Calamba cor. Sto Domingo" },
                            new Road { Name = "Araneta cor. NS Amoranto" },
                            new Road { Name = "AIB cor. Ma. Clara" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Chest Deep",
                        Barangay = "Brgy. Katipunan",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Lower Mangga" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Chest Deep",
                        Barangay = "Brgy. Phil-Am",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Legaspi cor. North Lawin" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Chest Deep",
                        Barangay = "Brgy. Sto. Domingo - Matalahib",
                        Roads = new List<Road>
                        {
                            new Road { Name = "NS Amoranto cor Don Jose" },
                            new Road { Name = "Ma. Clara cor. Don Pepe" },
                            new Road { Name = "Don Pepe (baba)" },
                            new Road { Name = "Don Pepe cor. Calamba" },
                            new Road { Name = "Calamba cor. Sto Domingo" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Chest Deep",
                        Barangay = "Brgy. Roxas",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Waling-waling St." }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Chest Deep",
                        Barangay = "Brgy. NS Amoranto (Gintong Silahis)",
                        Roads = new List<Road>
                        {
                            new Road { Name = "G. Araneta from NS Amoranto to Maria" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Chest Deep",
                        Barangay = "Brgy. North Fairview",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Habagat Area along Commonwealth Ave." }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Chest Deep",
                        Barangay = "Brgy. Matandang Balara",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Laura St." }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Neck Deep",
                        Barangay = "Brgy. Pinyahan",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Post Office NIA Road" }
                        }
                    },
                    new RoadStatus
                    {
                        Condition = "Head Deep",
                        Barangay = "Brgy. Apolonio Samson",
                        Roads = new List<Road>
                        {
                            new Road { Name = "Tabing Ilog St. Kaingin Bukid" }
                        }
                    }
                }
            };


            db.RoadStatusUpdates.Add(update);
            db.SaveChanges();
        }
    }
}
