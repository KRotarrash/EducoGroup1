using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;

namespace WebApplication.Models.CustomAttribute
{
    public class StreetRuleAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var viewModel = validationContext.ObjectInstance as AdressViewModel;
            if (viewModel == null)
            {
                throw new ArgumentException("Не тот класс");
            }

            if (viewModel.OwnerId == 1)
            {
                return ValidationResult.Success;
            }

            if (viewModel.Street.ToLower().IndexOf("минск") < 0)
            {
                return new ValidationResult("Только в Минске");
            }

            return ValidationResult.Success;
        }
    }
}
