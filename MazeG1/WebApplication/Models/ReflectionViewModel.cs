using AutoMapper.Internal;
using System.Collections.Generic;
using System.Reflection;
using WebApplication.Models.Reflection;

namespace WebApplication.Models
{
    public class ReflectionViewModel
    {
        public ReflectionViewModel()
        {
        }
        public List<ReflectionClassInfo> ClassesInfo { get; set; }
        public List<ReflectionEnumInfoViewModel> EnumsInfo { get; set; }
        public List<string> Namespaces { get; set; }
    }
}
