#pragma checksum "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89887dffe5ab153cc8fc16f1d4d679ce0d6eefd6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Job_Index), @"mvc.1.0.view", @"/Views/Job/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89887dffe5ab153cc8fc16f1d4d679ce0d6eefd6", @"/Views/Job/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea7069f4d9b26b9cc12f9c9c6ca44dbeaa31e7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Job_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JobViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/chart-2.8.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/orgs-job-chart.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89887dffe5ab153cc8fc16f1d4d679ce0d6eefd64146", async() => {
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
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89887dffe5ab153cc8fc16f1d4d679ce0d6eefd65243", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
            WriteLiteral("\n<div>\n    <div class=\"header-table-job\">\n        <h1>Список должностей</h1>\n    </div>\n\n    <div class=\"char-container\">\n        <canvas id=\"myChart\"></canvas>\n    </div>\n\n    <div class=\"btn-table-job\">\n        <a");
            BeginWriteAttribute("href", " href=\"", 408, "\"", 443, 1);
#nullable restore
#line 21 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
WriteAttributeValue("", 415, Url.Action("NewJob", "Job"), 415, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><span class=""icon add"" title=""Создать вакансию""></span></a>
    </div>
    <div class=""table-calc"">
        <table>
            <tbody>
                <tr class=""tableHeader"">
                    <td>Номер</td>
                    <td>Организация</td>
                    <td>Должность</td>
                    <td>Дата з/п</td>
                    <td>З/п, BYN</td>
                    <td>Сотрудник</td>
                    <td>Действия</td>
                </tr>
");
#nullable restore
#line 35 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
                  var counter = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
                 foreach (var job in Model.JobViewModels)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td><p>");
#nullable restore
#line 39 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
                          Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\n                        <td><p>");
#nullable restore
#line 40 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
                          Write(job.Organization.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\n                        <td><p>");
#nullable restore
#line 41 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
                          Write(job.Position.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\n                        <td><p>");
#nullable restore
#line 42 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
                          Write(job.Organization.SalaryDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\n                        <td><p>");
#nullable restore
#line 43 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
                          Write(job.Position.Salary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\n                        <td><p>");
#nullable restore
#line 44 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
                           Write(job.User == null ? "" : job.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p></td>\n                        <td>\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1495, "\"", 1556, 1);
#nullable restore
#line 46 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
WriteAttributeValue("", 1502, Url.Action("EditJob", "Job", new { @jobId = job.Id }), 1502, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                <span class=\"icon edit\" title=\"Редактировать данные должности\"></span>\n                            </a>\n                        </td>\n                    </tr>\n");
#nullable restore
#line 51 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\Index.cshtml"
                    counter += 1;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n\n    </div>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JobViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591