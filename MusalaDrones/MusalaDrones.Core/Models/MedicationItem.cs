using System.ComponentModel.DataAnnotations;

namespace MusalaDrones.Core.Models
{
    public class MedicationItem
    {
        [Key]
        public int Id { get; set; }

        // TODO: Add a custom data annotation to validate allowed only letters, numbers, ‘-‘, ‘_’
        public string Name { get; set; }

        public decimal Weight { get; set; }

        // TODO: Add a custom data annotation to validate allowed only letters, numbers, ‘-‘, ‘_’
        public string Code { get; set; }

        /// <summary>
        /// picture of the medication case
        /// </summary>
        public byte[] Image { get; set; }
    }
}