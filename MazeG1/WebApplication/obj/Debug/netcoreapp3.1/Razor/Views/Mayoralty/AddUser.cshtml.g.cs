#pragma checksum "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ef9af09acb92a5730de50793a115cecf01e1301"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mayoralty_AddUser), @"mvc.1.0.view", @"/Views/Mayoralty/AddUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ef9af09acb92a5730de50793a115cecf01e1301", @"/Views/Mayoralty/AddUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea7069f4d9b26b9cc12f9c9c6ca44dbeaa31e7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Mayoralty_AddUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/createUser.js?v=2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/showMessage.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ef9af09acb92a5730de50793a115cecf01e13014193", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ef9af09acb92a5730de50793a115cecf01e13015290", async() => {
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
            WriteLiteral(@"
<a class=""back-link"" href=""/Mayoralty/Index"">Вернутся назад</a>

<div class=""user-event-container"">
    <div class=""user-event"">
        <div class=""event-container"">
            <span class=""message"">

            </span>
            <a class=""icon bad close-message""></a>
        </div>
    </div>
</div>

<div class=""form-user-create"">
    <div class=""main"">
        <h1>Registration User</h1>
        <div class=""wrapper-row"">
            <div class=""field"">
                ");
#nullable restore
#line 29 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.LabelFor(x => x.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 30 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.TextBoxFor(x => x.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""field-error user-name-block "">
                <span class=""icon question""></span>
                <span class=""icon wait""></span>
                <span class=""icon check""></span>
                <span class=""icon bad""></span>
                ");
#nullable restore
#line 37 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.ValidationMessageFor(x => x.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <span class=\"error-message error-forbidden-symbol\">Запрещенные символы: \'?\', \'/\', \'*\'</span>\n            </div>\n        </div>\n        <div class=\"wrapper-row\">\n            <div class=\"field\">\n                ");
#nullable restore
#line 43 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.LabelFor(x => x.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 44 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.TextBoxFor(x => x.Age, new { @type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n            <div class=\"field-error\">\n                ");
#nullable restore
#line 47 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.ValidationMessageFor(x => x.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <span class=\"error-message error-age-yang\">Наш сайт предназначен только для лиц старше 18</span>\n            </div>\n        </div>\n        <div class=\"wrapper-row\">\n            <div class=\"field\">\n                ");
#nullable restore
#line 53 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.LabelFor(x => x.Height));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 54 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.TextBoxFor(x => x.Height, new { @type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n            <div class=\"field-error\">\n                ");
#nullable restore
#line 57 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.ValidationMessageFor(x => x.Height));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n        <div class=\"wrapper-row\">\n            <div class=\"field\">\n                ");
#nullable restore
#line 62 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.LabelFor(x => x.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 63 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.PasswordFor(x => x.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""field-error"">
                <span class=""error-message error-short-password"">Пароль должен содержать не менее 6 символов</span>
            </div>
        </div>
        <div class=""wrapper-row"">
            <div class=""field"">
                ");
#nullable restore
#line 71 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.LabelFor(x => x.PasswordRepeat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 72 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Mayoralty\AddUser.cshtml"
           Write(Html.PasswordFor(x => x.PasswordRepeat));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
            <div class=""field-error"">
                <span class=""error-message error-short-password-repeat"">Пароль должен содержать не менее 6 символов</span>
                <span class=""error-message not-equal-password"">Значение отличается от введенного ранее</span>
            </div>
        </div>

        <input class=""button-user-create"" type=""submit"" value=""Создать"" />
    </div>
</div>
");
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
