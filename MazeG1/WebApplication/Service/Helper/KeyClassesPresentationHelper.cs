using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.KeyClasses;

namespace WebApplication.Sevrice.Helper
{
    public class KeyClassesPresentationHelper : IKeyClassesPresentationHelper
    {
        public KeyClassViewModel HelperGetKeyClassViewModel()
        {
            var modelView = new KeyClassViewModel();
            var types = HelperGetKeyClasses();
            modelView.KeyClasses = new List<KeyClassViewModel>();
            foreach (Type type in types)
            {
                var model = new KeyClassViewModel();
                model.ClassName = type.Name;
                model.IsEnum = type.IsEnum;

                var bindingFlagsAll =
                   BindingFlags.Public | BindingFlags.NonPublic
                   | BindingFlags.Static | BindingFlags.Instance;

                if (type.IsEnum)
                {
                    var enamFields = type.GetFields(bindingFlagsAll);
                    var enamViewFields = new List<EnamViewModel>();
                    foreach (var field in enamFields)
                    {
                        var enamViewFild = new EnamViewModel()
                        {
                            Name = field.Name,
                            //Value = Convert.ToInt32(field.GetValue(field.Name))
                        };
                    }
                }

                var methods = type.IsEnum
                    ? type.GetMethods(BindingFlags.Instance)
                    : type.GetMethods(bindingFlagsAll);
                var constuctors = type.IsEnum
                    ? type.GetConstructors(BindingFlags.Instance)
                    : type.GetConstructors(bindingFlagsAll);
                var fields = type.GetFields(bindingFlagsAll);
                model.Members = new List<MemberViewModel>();

                var allElements = new List<MemberInfo>();
                allElements.AddRange(fields);
                allElements.AddRange(constuctors);
                allElements.AddRange(methods);

                foreach (var elem in allElements)
                {
                    model.Members.Add(HelperGetMemberViewModel(elem));
                }
                modelView.KeyClasses.Add(model);

            }

            return modelView;

        }
        public List<Type> HelperGetKeyClasses()
        {
            var typeList = Assembly.GetExecutingAssembly().GetTypes();
            var result = new List<Type>();

            foreach (var type in typeList)
            {
                var heirs = new List<Type>();

                if (type.IsInterface)
                {
                    foreach (var realizeInterface in type.GetInterfaces())
                    {
                        if (typeList.Contains(realizeInterface)
                            && realizeInterface.BaseType?.IsGenericType == true
                            && realizeInterface.BaseType.GetGenericTypeDefinition() == type
                            || realizeInterface.BaseType == type)
                        {
                            heirs.Add(realizeInterface);
                        }
                    }
                }
                else
                {
                    foreach (var realizeClass in typeList)
                    {
                        if (typeList.Contains(realizeClass)
                            && realizeClass.BaseType?.IsGenericType == true
                            && realizeClass.BaseType.GetGenericTypeDefinition() == type
                            || realizeClass.BaseType == type)
                        {
                            heirs.Add(realizeClass);
                        }
                    }
                }

                if (heirs.ToList().Count > 1)
                {
                    result.Add(type);
                }
            }
            return result;
        }
        public MemberViewModel HelperGetMemberViewModel(MemberInfo memberInfo)
        {
            var modelMethod = new MemberViewModel();
            modelMethod.MemberName = memberInfo.Name;
            modelMethod.IsPublic = memberInfo.IsPublic();
            modelMethod.IsStatic = memberInfo.IsStatic();

            var methodBase = memberInfo as MethodBase;
            if (methodBase != null)
            {
                var inputParams = methodBase.GetParameters();
                var inputParamsStr = inputParams
                    .Select(x => $"{x.Name} ({x.ParameterType.Name})");
                var strMethod = string.Join(", ", inputParamsStr);
                modelMethod.InputParams = strMethod;

                var methodInfo = memberInfo as MethodInfo;
                if (methodInfo != null)
                {
                    modelMethod.ReturnType = methodInfo.ReturnType;
                    modelMethod.TypeElement = TypeElement.Method;
                }
                else
                {
                    modelMethod.TypeElement = TypeElement.Contrsuctor;
                }
            }

            var fieldInfo = memberInfo as FieldInfo;
            if (fieldInfo != null)
            {
                modelMethod.ReturnType = fieldInfo.FieldType;
                modelMethod.TypeElement = TypeElement.Attribute;
            }
            return modelMethod;
        }
    }
}
