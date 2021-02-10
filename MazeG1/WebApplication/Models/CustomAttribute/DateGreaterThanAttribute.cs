using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.CustomAttribute
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private string DateToCompareToFieldName { get; set; }

        public DateGreaterThanAttribute(string dateToCompareToFieldName)
        {
            DateToCompareToFieldName = dateToCompareToFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var earlierDate = (DateTime)value;

            var laterDate = (DateTime)validationContext
                .ObjectType
                .GetProperty(DateToCompareToFieldName)
                .GetValue(validationContext.ObjectInstance, null);

            return laterDate > earlierDate
                ? ValidationResult.Success
                : new ValidationResult("Дата окончания меньше даты начала");
        }
    }
}
