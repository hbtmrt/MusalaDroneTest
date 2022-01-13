using MusalaDrones.Core.Statics.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusalaDrones.Core.Models
{
    public class Drone
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string SerialNumber { get; set; }

        public DroneModel Model { get; set; }

        /// <summary>
        /// Weights are in grams.
        /// </summary>
        [Range(0, 500)]
        public decimal WeightLimit { get; set; }

        public decimal BatteryCapacity { get; set; }

        public DroneState State { get; set; }

        public virtual ICollection<MedicationItem> MedicationItems { get; set; }
    }
}