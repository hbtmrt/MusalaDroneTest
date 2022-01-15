using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusalaDrones.Core.Models
{
    public class BatteryLevelHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DroneId { get; set; }
        public decimal BatteryLevel { get; set; }
        public DateTime CheckedOn { get; set; }
    }
}