#pragma checksum "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38c07bb560689ab449b81a88450aa8395b4a21fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Job_AddOffice), @"mvc.1.0.view", @"/Views/Job/AddOffice.cshtml")]
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
#line 2 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
using WebApplication.Models.Job;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38c07bb560689ab449b81a88450aa8395b4a21fa", @"/Views/Job/AddOffice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea7069f4d9b26b9cc12f9c9c6ca44dbeaa31e7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Job_AddOffice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OfficeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("new-office"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Job/AddOffice"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 8 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
 if (!Model.IsAnyAddress)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>Извините в данный момент, вы не можете добавить офис.</span>\n    <span>Нет адресов.</span>\n");
#nullable restore
#line 12 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\n\n        <div class=\"header-office-add\">\n            <h1>Создание офиса</h1>\n        </div>\n\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38c07bb560689ab449b81a88450aa8395b4a21fa5377", async() => {
                WriteLiteral("\n\n            <div class=\"wrapper-row\">\n                <div>\n                    ");
#nullable restore
#line 25 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
               Write(Html.LabelFor(x => x.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    ");
#nullable restore
#line 26 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
               Write(Html.TextBoxFor(x => x.Name, new { placeholder = "Название офиса" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n                <div class=\"field-error\">\n                    ");
#nullable restore
#line 29 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
               Write(Html.ValidationMessageFor(x => x.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n            </div>\n\n            <div class=\"wrapper-row\">\n                <div>\n                    ");
#nullable restore
#line 35 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
               Write(Html.LabelFor(x => x.Address));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    ");
#nullable restore
#line 36 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
               Write(Html.DropDownListFor(
                        m => m.CurrentAdressId,
                            new SelectList(Model.Addresses,
                                $"{nameof(AdressViewModel.Id)}",
                                $"{nameof(AdressViewModel.FullName)}")));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n                <div class=\"field-error\">\n                    ");
#nullable restore
#line 43 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
               Write(Html.ValidationMessageFor(x => x.Address));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n            </div>\n\n            <div class=\"wrapper-row\">\n                <div>\n                    Организация :\n                    ");
#nullable restore
#line 50 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"
               Write(Html.DropDownListFor(
                        m => m.CurrentOrganizationId,
                            new SelectList(Model.Organizations,
                                $"{nameof(OrganizationViewModel.Id)}",
                                $"{nameof(OrganizationViewModel.Name)}")));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </div>\n                <div class=\"field-error\">\n                </div>\n            </div>\n\n            <input class=\"submitBatton\" type=\"submit\" value=\"Создать\" />\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n");
#nullable restore
#line 63 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Job\AddOffice.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OfficeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
