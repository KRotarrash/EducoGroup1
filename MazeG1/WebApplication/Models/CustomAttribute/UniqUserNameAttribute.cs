using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Repository;

namespace WebApplication.Models.CustomAttribute
{
    public class UniqUserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var viewModel = validationContext.ObjectInstance as UserViewModel;
            if (viewModel == null)
            {
                throw new ArgumentException("Не тот класс");
            }

            var specialUserRepository = validationContext.GetService<ISpecialUserRepository>();
            var specialUser = specialUserRepository.GetUserByName(viewModel.UserName);
            if (specialUser != null)
            {
                if (viewModel.Id != specialUser.Id)
                {
                    return new ValidationResult("Пользователь с таким именем уже есть");
                }
            }

            return ValidationResult.Success;
        }
    }
}
