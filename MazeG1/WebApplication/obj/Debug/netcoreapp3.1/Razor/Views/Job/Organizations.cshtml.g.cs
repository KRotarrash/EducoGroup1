#pragma checksum "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "862a6828f5a4fff0f77b96cb324439c20297c51e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Job_Organizations), @"mvc.1.0.view", @"/Views/Job/Organizations.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"862a6828f5a4fff0f77b96cb324439c20297c51e", @"/Views/Job/Organizations.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea7069f4d9b26b9cc12f9c9c6ca44dbeaa31e7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Job_Organizations : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ManageOrganizationsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/paginator.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    <script>\n        var paginatorUrl = \'/Job/Organizations\';\n    </script>\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "862a6828f5a4fff0f77b96cb324439c20297c51e3927", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            WriteLiteral("\n<div id=\'users\'>\n    <h1>Перечень организаций</h1>\n    <div>\n        <a");
            BeginWriteAttribute("href", " href=\"", 302, "\"", 346, 1);
#nullable restore
#line 16 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
WriteAttributeValue("", 309, Url.Action("NewOrganization", "Job"), 309, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"icon add\" title=\"Добавить работодателя\"></span></a> |\n    </div>\n\n    ");
#nullable restore
#line 19 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
Write(Html.Partial("/Views/Shared/_paginatorInfo.cshtml", Model.PaginatorInfo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n    <table>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 24 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
           Write(Html.ActionLink("Id", "Organizations", "Job",
                    new
                         {
                        page = Model.PaginatorInfo.Page,
                        pageSize = Model.PaginatorInfo.PageSize,
                        sortColumn = SortColumn.Id,
                        sortDirection = Model.SortViewModel.colDirection(SortColumn.Id)
                        }
                ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 35 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
           Write(Html.ActionLink("Наименование организации", "Organizations", "Job",
                    new
                    {
                        page = Model.PaginatorInfo.Page,
                        pageSize = Model.PaginatorInfo.PageSize,
                        sortColumn = SortColumn.OrganizationName,
                        sortDirection = Model.SortViewModel.colDirection(SortColumn.OrganizationName)
                    }
                ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 46 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
           Write(Html.ActionLink("Руководитель", "Organizations", "Job",
                    new
                    {
                        page = Model.PaginatorInfo.Page,
                        pageSize = Model.PaginatorInfo.PageSize,
                        sortColumn = SortColumn.Name,
                        sortDirection = Model.SortViewModel.colDirection(SortColumn.Name)
                    }
                ));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                Действия\n            </th>\n        </tr>\n");
#nullable restore
#line 60 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
         foreach (var organization in Model.Organizations)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
#nullable restore
#line 64 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
               Write(organization.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 67 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
               Write(organization.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 70 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
                Write(organization.Owner == null ? "Нет руководителя" : organization.Owner.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    <a");
            BeginWriteAttribute("href", " href=\"", 2451, "\"", 2527, 1);
#nullable restore
#line 73 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
WriteAttributeValue("", 2458, Url.Action("EditOrganization", "Job", new { @id = organization.Id }), 2458, 69, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <span class=\"icon edit\" title=\"Редактировать данные по организации\"></span>\n                    </a>\n                    <a");
            BeginWriteAttribute("href", " href=\"", 2677, "\"", 2755, 1);
#nullable restore
#line 76 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
WriteAttributeValue("", 2684, Url.Action("RemoveOrganization", "Job", new { @id = organization.Id }), 2684, 71, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <span class=\"icon remove\" title=\"Удалить организацию\"></span>\n                    </a>\n                </td>\n            </tr>\n");
#nullable restore
#line 81 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n\n    ");
#nullable restore
#line 84 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Organizations.cshtml"
Write(Html.Partial("/Views/Shared/_paginatorInfo.cshtml", Model.PaginatorInfo));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ManageOrganizationsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591