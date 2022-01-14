using System;
using System.ComponentModel.DataAnnotations;

namespace MusalaDrones.Core.CustomAttributes
{
    public class EnumValidateExistsAttribute : ValidationAttribute
    {
        public Type EnumType { get; set; }

        public override bool IsValid(object value)
        {
            int.TryParse(value.ToString(), out int intValue);

            return Enum.IsDefined(EnumType, value);
        }
    }
}