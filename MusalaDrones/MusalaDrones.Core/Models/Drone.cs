using MusalaDrones.Core.Statics.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusalaDrones.Core.Models
{
    public class Drone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string SerialNumber { get; set; }

        [Required]
        public DroneModel Model { get; set; }

        /// <summary>
        /// Weights are in grams.
        /// </summary>
        [Required]
        [Range(0, 500)]
        public decimal WeightLimit { get; set; }

        [Required]
        public decimal BatteryCapacity { get; set; }

        [Required]
        public DroneState State { get; set; }

        public ICollection<MedicationItem> MedicationItems { get; set; }
    }
}