#pragma checksum "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b0ab19600736e02350aba75a689d9f4f9ae7e90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Police_ProfileRead), @"mvc.1.0.view", @"/Views/Police/ProfileRead.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
using WebApplication.DbStuff;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b0ab19600736e02350aba75a689d9f4f9ae7e90", @"/Views/Police/ProfileRead.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea7069f4d9b26b9cc12f9c9c6ca44dbeaa31e7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Police_ProfileRead : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n\n    <a class=\"back-link\" href=\"/Police/Users\">Вернутся к списку пользователей</a>\n\n    <div>\n        <img class=\"avatar\"");
            BeginWriteAttribute("src", " src=\"", 232, "\"", 268, 3);
            WriteAttributeValue("", 238, "/avatar/avatar-", 238, 15, true);
#nullable restore
#line 13 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
WriteAttributeValue("", 253, Model.Id, 253, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 264, ".jpg", 264, 4, true);
            EndWriteAttribute();
            WriteLiteral(" />\n    </div>\n\n    <div>Имя пользователя: ");
#nullable restore
#line 16 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                      Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n    <div>Возраст пользователя: ");
#nullable restore
#line 17 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                          Write(Model.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n    <div>Рост пользователя: ");
#nullable restore
#line 18 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                       Write(Model.Height);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
#nullable restore
#line 20 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
     if (@Model.Аddress.FlatNumber > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\n            Адресс пользователя:\n            <span>город: ");
#nullable restore
#line 24 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                    Write(Model.Аddress.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            <span>, улица/проспект: ");
#nullable restore
#line 25 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                               Write(Model.Аddress.Street);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            <span>, номер дома: ");
#nullable restore
#line 26 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                           Write(Model.Аddress.Floor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            <span>, этаж: ");
#nullable restore
#line 27 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                     Write(Model.Аddress.Floor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            <span>, номер квартиры/офиса: ");
#nullable restore
#line 28 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                                     Write(Model.Аddress.FlatNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>.\n        </div>\n");
#nullable restore
#line 30 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div>Название организации: ");
#nullable restore
#line 32 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                          Write(Model.OrganizationPosition.Organization.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
#nullable restore
#line 33 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
     if (@Model.OrganizationPosition.Organization.Name != HostSeed.OrganizationDefault)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>Дата выплаты ЗП: ");
#nullable restore
#line 35 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                         Write(Model.OrganizationPosition.Organization.SalaryDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n        <div>Занимаемая должность: ");
#nullable restore
#line 36 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                              Write(Model.OrganizationPosition.Position.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
#nullable restore
#line 37 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 39 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
     if (Model.EndBlocked > DateTime.Now)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>Время начала блокировки: ");
#nullable restore
#line 41 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                                 Write(Model.DateBlocked);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n        <div>Время окончания блокировки: ");
#nullable restore
#line 42 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
                                    Write(Model.EndBlocked);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
#nullable restore
#line 43 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Police\ProfileRead.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591