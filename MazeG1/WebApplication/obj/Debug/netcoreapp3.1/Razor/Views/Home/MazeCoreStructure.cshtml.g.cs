#pragma checksum "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2f56493f64a44af6ac56a0969a27378d37294c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_MazeCoreStructure), @"mvc.1.0.view", @"/Views/Home/MazeCoreStructure.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2f56493f64a44af6ac56a0969a27378d37294c3", @"/Views/Home/MazeCoreStructure.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea7069f4d9b26b9cc12f9c9c6ca44dbeaa31e7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_MazeCoreStructure : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MazeCoreStructureViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/classInfo.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2f56493f64a44af6ac56a0969a27378d37294c33874", async() => {
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
            WriteLiteral("\n<div>\n    <h1 class=\"page-name\">Структура MazeCore</h1>\n");
#nullable restore
#line 12 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
     foreach (var clas in Model.Classes)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"class-block\">\n            <div class=\"class-list-element\"><a>");
#nullable restore
#line 15 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                                           Write(clas.IsEnum ? "Enum" : "Класс");

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 15 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                                                                            Write(clas.ClassName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></div>\n            <div class=\"class-info\">\n");
#nullable restore
#line 17 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                 foreach (var method in clas.Methods)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                     switch (method.TypeElement)
                    {
                        case TypeElement.Attribute:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div>\n                                ");
#nullable restore
#line 23 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                            Write(clas.IsEnum ? "Элемент" : "Свойство");

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                ");
#nullable restore
#line 24 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                           Write(method.MethodName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 24 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                                                Write(method.IsPublic ? (clas.IsEnum ? "публичный" : "публичное") : "приватное");

#line default
#line hidden
#nullable disable
            WriteLiteral(").\n                                Тип данных ");
#nullable restore
#line 25 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                                      Write(method.ReturnType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            </div>\n");
#nullable restore
#line 27 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                            break;
                        case TypeElement.Contrsuctor:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div>\n                                Конструктор\n                                ");
#nullable restore
#line 31 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                            Write(method.InputParams.Length <= 0
                                    ? "без входных параметров"
                                    : "с входными параметрами:");

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                ");
#nullable restore
#line 34 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                           Write(method.InputParams);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 34 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                                                 Write(method.IsPublic ? "публичный" : "приватный");

#line default
#line hidden
#nullable disable
            WriteLiteral(").\n                                ");
#nullable restore
#line 35 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                            Write(method.IsStatic ? "Статичный." : "");

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            </div>\n");
#nullable restore
#line 37 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                            break;
                        case TypeElement.Method:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div>\n                                Метод ");
#nullable restore
#line 40 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                                 Write(method.MethodName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 40 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                                                      Write(method.IsPublic ? "публичный" : "приватный");

#line default
#line hidden
#nullable disable
            WriteLiteral(").\n                                ");
#nullable restore
#line 41 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                            Write(method.InputParams.Length <= 0 ? "Без входных параметров" : "Входные параметры: ");

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                                                                                                               Write(method.InputParams);

#line default
#line hidden
#nullable disable
            WriteLiteral(".\n                                Возвращаемый тип ");
#nullable restore
#line 42 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                                            Write(method.ReturnType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            </div>\n");
#nullable restore
#line 44 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                            break;
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\n        </div>\n");
#nullable restore
#line 49 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Home\MazeCoreStructure.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MazeCoreStructureViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591