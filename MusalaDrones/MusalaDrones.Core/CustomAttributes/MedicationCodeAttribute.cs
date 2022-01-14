using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MusalaDrones.Core.CustomAttributes
{
    /// <summary>
    /// Validates wheather the string has only upper case letters, underscore and numbers.
    /// </summary>
    public class MedicationCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string code = value as string;

            if (string.IsNullOrWhiteSpace(code))
            {
                return false;
            }

            return IsValidCharacters(code);
        }

        private bool IsValidCharacters(string code)
        {
            Regex rg = new Regex(@"^[A-Z_0-9]+$");
            return rg.IsMatch(code);
        }
    }
}