using System.Collections.Generic;

namespace WebApplication.Models.Reflection
{
    public class ReflectionClassInfo
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public List<ReflectionMemberClassInfo> Properties { get; set; }
        public List<ReflectionMemberClassInfo> Fields { get; set; }
        public List<ReflectionMemberClassInfo> Methods { get; set; }
    }
}
