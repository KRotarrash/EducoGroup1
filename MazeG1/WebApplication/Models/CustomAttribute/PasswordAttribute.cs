using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Repository;
using System.Text.RegularExpressions;

namespace WebApplication.Models.CustomAttribute
{
    public class PasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            return true;
            //Regex rgx = new Regex(@"/\d{6}$/");

            //return rgx.IsMatch(str);
        }
    }
}
