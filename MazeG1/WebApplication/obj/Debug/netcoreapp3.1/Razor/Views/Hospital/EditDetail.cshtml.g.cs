#pragma checksum "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21794e5e4a89ed83f342471539b900157cd8488d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hospital_EditDetail), @"mvc.1.0.view", @"/Views/Hospital/EditDetail.cshtml")]
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
#line 2 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
using WebApplication.DbStuff.Model.Job;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21794e5e4a89ed83f342471539b900157cd8488d", @"/Views/Hospital/EditDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea7069f4d9b26b9cc12f9c9c6ca44dbeaa31e7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Hospital_EditDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MedicalRecordDetailViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Hospital/EditDetail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
      
        Layout = "~/Views/Shared/_Layout.cshtml";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div>\n        <div class=\"header-job-add\">\n            <h1>Осмотр</h1>\n        </div>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21794e5e4a89ed83f342471539b900157cd8488d4554", async() => {
                WriteLiteral("\n            ");
#nullable restore
#line 13 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
       Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            <div class=\"wrapper-row\">\n                <div class=\"field\">\n                    ");
#nullable restore
#line 16 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
               Write(Html.DisplayNameFor(x => x.PatientId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    ");
#nullable restore
#line 17 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
               Write(Html.DropDownListFor(
                    m => m.PatientId,
                        new SelectList(Model.Users,
                            $"{nameof(UserViewModel.Id)}",
                            $"{nameof(UserViewModel.UserName)}")));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n                    <div class=\"field-error\">\n                        ");
#nullable restore
#line 24 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
                   Write(Html.ValidationMessageFor(x => x.PatientId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </div>\n                </div>\n            </div>\n\n            <div class=\"wrapper-row\">\n                <div class=\"field\">\n                    ");
#nullable restore
#line 31 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
               Write(Html.DisplayNameFor(x => x.DateOfExamination));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    : ");
#nullable restore
#line 32 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
                 Write(Html.TextBoxFor(x => x.DateOfExamination, "{0:yyyy-MM-dd}",
new { @class = "form-control", placeholder = "DateEvent", min = "2000/01/01", type = "date" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n                    <div class=\"field-error\">\n                        ");
#nullable restore
#line 36 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
                   Write(Html.ValidationMessageFor(x => x.DateOfExamination));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </div>\n                </div>\n            </div>\n\n            <div class=\"wrapper-row\">\n                <div class=\"field-area\">\n                    ");
#nullable restore
#line 43 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
               Write(Html.LabelFor(x => x.ResultOfExamination,
                         string.Format("{0}:", Html.DisplayNameFor(m => m.ResultOfExamination))));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n                    ");
#nullable restore
#line 46 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
               Write(Html.TextAreaFor(x => x.ResultOfExamination));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n                    <div class=\"field-error\">\n                        ");
#nullable restore
#line 49 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Hospital\EditDetail.cshtml"
                   Write(Html.ValidationMessageFor(x => x.ResultOfExamination));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </div>\n                </div>\n            </div>\n\n            <input type=\"submit\" value=\"Создать\" />\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MedicalRecordDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
