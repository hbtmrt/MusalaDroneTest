using Microsoft.EntityFrameworkCore;
using MusalaDrones.Core.Models;

namespace MusalaDrones.Data.DbContexts
{
    public class DroneContext : DbContext
    {
        public DroneContext(DbContextOptions<DroneContext> options)
            : base(options)
        {
        }

        public DbSet<Drone> Drones { get; set; }
        public DbSet<MedicationItem> MedicationItem { get; set; }
    }
}