using MusalaDrones.Core.CustomAttributes;
using MusalaDrones.Core.Statics;
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
        [EnumValidateExists(EnumType =typeof(DroneModel),ErrorMessage =Constants.ErrorMessage.InvalidDroneModel)]
        public DroneModel Model { get; set; }

        /// <summary>
        /// Weights are in grams.
        /// </summary>
        [Required]
        [Range(0, 500)]
        public decimal WeightLimit { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal BatteryCapacity { get; set; }

        [Required]
        [EnumValidateExists(EnumType = typeof(DroneState), ErrorMessage = Constants.ErrorMessage.InvalidDroneState)]
        public DroneState State { get; set; }

        public ICollection<MedicationItem> MedicationItems { get; set; }
    }
}