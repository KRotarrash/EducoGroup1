using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.CustomAttribute
{
    public class UserNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value?.GetType() != typeof(string))
            {
                throw new ArgumentException("UserNameAttribute can be apply only for string");
            }

            var str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            var donPosition = str.IndexOf('.');
            return donPosition > 0 && donPosition != str.Length - 1;
        }
    }
}
