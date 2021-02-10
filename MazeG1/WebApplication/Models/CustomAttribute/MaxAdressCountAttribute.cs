using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Repository;

namespace WebApplication.Models.CustomAttribute
{
    public class MaxAdressCountAttribute : ValidationAttribute
    {
        private int MaxAdressCount { get; set; }
        public MaxAdressCountAttribute(int maxAdressCount)
        {
            MaxAdressCount = maxAdressCount;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                return ValidationResult.Success;
            }

            var viewModel = validationContext.ObjectInstance as AdressViewModel;
            if (viewModel == null)
            {
                throw new ArgumentException("Не тот класс");

            }
            var user = validationContext.GetService<ISpecialUserRepository>().Get(viewModel.OwnerId);
            if (user != null && user.Adresses.Count() + 1 > MaxAdressCount)
            {
                return new ValidationResult($"У пользователя не может быть более {MaxAdressCount} адрессов");
            }

            return ValidationResult.Success;
        }
    }
}
