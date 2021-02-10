using System.Collections.Generic;

namespace WebApplication.Models.Reflection
{
    public class ReflectionEnumInfoViewModel
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public List<ReflectionMemberClassInfo> Fields { get; set; }
    }
}
