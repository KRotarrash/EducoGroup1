using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using WebApplication.Models;
using WebApplication.Models.CustomHelpers;
using WebApplication.Models.Reflection;


namespace WebApplication.Presentation
{
    public class ReflectionPresentation
    {
        private Assembly AssemblyInfo => Assembly.GetExecutingAssembly();
        public ReflectionViewModel GetViewModelIndex()
        {
            var model = new ReflectionViewModel();

            model.ClassesInfo = new List<ReflectionClassInfo>();
            model.EnumsInfo = new List<ReflectionEnumInfoViewModel>();
            model.Namespaces = new List<string>();

            var classesInfo = AssemblyInfo.GetTypes().Where(t => t.IsClass);
            foreach (Type classInfo in classesInfo)
            {
                var currClass = new ReflectionClassInfo { Namespace = classInfo.Namespace, Name = classInfo.Name };
                var currType = classInfo.GetType();

                var bf = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

                currClass.Properties = GetProperties(currType, bf);
                currClass.Fields = GetFields(currType, bf);
                currClass.Methods = GetMethods(currType, bf);

                model.ClassesInfo.Add(currClass);
            }

            var enumsInfo = AssemblyInfo.GetTypes().Where(t => t.IsEnum);
            foreach (var enumInfo in enumsInfo)
            {
                var currEnum = new ReflectionEnumInfoViewModel { Namespace = enumInfo.Namespace, Name = enumInfo.Name };
                GetEnum(currEnum, enumInfo);
                model.EnumsInfo.Add(currEnum);
            }

            model.Namespaces = GetNamespaces(model);

            return model;
        }

        private List<ReflectionMemberClassInfo> GetProperties(Type currType, BindingFlags bf)
        {
            var result = new List<ReflectionMemberClassInfo>();
            var properties = currType.GetProperties(bf);
            foreach (var property in properties)
            {
                result.Add(new ReflectionMemberClassInfo
                {
                    Name = property.Name,
                    Type = property.PropertyType.ToString(),
                    AccessModifier = GetModifier(property)
                });
            }
            return result;
        }

        private List<ReflectionMemberClassInfo> GetFields(Type currType, BindingFlags bf)
        {
            var result = new List<ReflectionMemberClassInfo>();
            var fields = currType.GetFields(bf);
            foreach (var field in fields)
            {
                result.Add(new ReflectionMemberClassInfo
                {
                    Name = field.Name,
                    Type = field.FieldType.ToString(),
                    AccessModifier = GetModifier(field)
                });
            }
            return result;
        }

        private List<ReflectionMemberClassInfo> GetMethods(Type currType, BindingFlags bf)
        {
            var result = new List<ReflectionMemberClassInfo>();
            var methods = currType.GetMethods(bf);
            foreach (var method in methods)
            {
                result.Add(
                    new ReflectionMemberClassInfo
                    {
                        Name = method.Name,
                        Type = method.ReturnType.Name,
                        AccessModifier = GetModifier(method)
                    });
            }
            return result;
        }

        private void GetEnum(ReflectionEnumInfoViewModel currEnum, Type e)
        {
            currEnum.Fields = new List<ReflectionMemberClassInfo> { };
            var fields = e.GetFields();
            for (int i = 1; i < fields.Count(); i++)
            {
                currEnum.Fields.Add(
                    new ReflectionMemberClassInfo
                    {
                        Name = fields[i].Name,
                        Type = fields[i].FieldType.ToString(),
                        AccessModifier = EnumHelper.GetEnumDescription(AccessIdentifier.Identpublic)
                    });
            }
        }

        private List<string> GetNamespaces(ReflectionViewModel model)
        {
            var result = new List<string>();
            result = model.ClassesInfo.Select(c => c.Namespace)
                .Distinct()
                .Where(n => n != null)
                .ToList();
            return result;
        }

        private string GetModifier(MemberInfo memberInfo)
        {
            string result;          
            if (memberInfo is MethodInfo)
            {
                result = (memberInfo as MethodInfo).IsPublic ?
                string.Format("{0} {1}", " ", EnumHelper.GetEnumDescription(AccessIdentifier.Identpublic))
                : string.Format("{0} {1}", " ", EnumHelper.GetEnumDescription(AccessIdentifier.Identprivate));
            }
            else
            {
                result = memberInfo.IsPublic() ?
                string.Format("{0} {1}", " ", EnumHelper.GetEnumDescription(AccessIdentifier.Identpublic))
                : string.Format("{0} {1}", " ", EnumHelper.GetEnumDescription(AccessIdentifier.Identprivate));
            }
            if (memberInfo.IsStatic()) { result += EnumHelper.GetEnumDescription(AccessIdentifier.Identstatic); };
            return result;
        }
    }
}
