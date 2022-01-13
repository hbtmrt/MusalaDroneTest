using MusalaDrones.Core.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace MusalaDrones.Core.Models
{
    public class MedicationItem
    {
        [Key]
        public int Id { get; set; }

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