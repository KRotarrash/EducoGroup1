using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.CustomAttribute
{
    public class MinAttribute : ValidationAttribute
    {
        private int MinValue { get; set; }

        public MinAttribute(int minValue)
        {
            MinValue = minValue;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage) 
                ? $"{name} не может быть меньше {MinValue}"
                : ErrorMessage;
        }

        public override bool IsValid(object value)
        {
            if (value?.GetType() != typeof(int))
            {
                throw new ArgumentException("MinAttribute can be apply only for int");
            }

            var number = value as int?;

            return number >= MinValue;
        }
    }
}
