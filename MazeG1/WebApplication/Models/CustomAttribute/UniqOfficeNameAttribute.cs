using System;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using WebApplication.DbStuff.Repository;
using WebApplication.Models.Job;
using WebApplication.DbStuff.Repository.IRepository.IJob;

namespace WebApplication.Models.CustomAttribute
{
    public class UniqOfficeNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var viewModel = validationContext.ObjectInstance as OfficeViewModel;
            if (viewModel == null)
            {
                throw new ArgumentException("Не тот класс");
            }

            var officeRepository = validationContext.GetService<IOfficeRepository>();
            var office = officeRepository.Get(viewModel.Name);
            if (office?.Id != viewModel.Id)
            {
                    return new ValidationResult("Офис с таким именем уже есть");
            }

            return ValidationResult.Success;
        }
    }
}