using System;
using System.Collections.Generic;
using System.Reflection;
using WebApplication.Models;
using WebApplication.Models.KeyClasses;

namespace WebApplication.Sevrice.Helper
{
    public interface IKeyClassesPresentationHelper
    {
        List<Type> HelperGetKeyClasses();
        KeyClassViewModel HelperGetKeyClassViewModel();
        MemberViewModel HelperGetMemberViewModel(MemberInfo memberInfo);
    }
}