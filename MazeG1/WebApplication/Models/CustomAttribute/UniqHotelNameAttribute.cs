using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IHotels;

namespace WebApplication.Models.CustomAttribute
{
    public class UniqHotelNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var viewModel = validationContext.ObjectInstance as HotelViewModel;
            if (viewModel == null)
            {
                throw new ArgumentException("Не тот класс");
            }

            var hotelRepository = validationContext.GetService<IHotelRepository>();
            var hotel = hotelRepository.GetHotelByName(viewModel.Name);
            if (hotel != null)
            {
                if (viewModel.Id != hotel.Id)
                {
                    return new ValidationResult("Отель с таким наименование уже есть");
                }
            }

            return ValidationResult.Success;
        }
    }
}
