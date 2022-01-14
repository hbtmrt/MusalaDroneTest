using MusalaDrones.Core.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusalaDrones.Core.Models
{
    public class MedicationItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DroneId { get; set; }

        [MedicationName]
        public string Name { get; set; }

        public decimal Weight { get; set; }

        [MedicationCode]
        public string Code { get; set; }

        /// <summary>
        /// picture of the medication case
        /// </summary>
        public byte[] Image { get; set; }
    }
}