using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MusalaDrones.Core.CustomAttributes
{
    /// <summary>
    /// Validates wheather a string has only letters, numbers, '_' and '-'.
    /// </summary>
    public class MedicationNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string name = value as string;

            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            return IsValidCharacters(name);
        }

        private bool IsValidCharacters(string name)
        {
            Regex rg = new Regex(@"^[a-zA-Z_-]+$");
            return rg.IsMatch(name);
        }
    }
}