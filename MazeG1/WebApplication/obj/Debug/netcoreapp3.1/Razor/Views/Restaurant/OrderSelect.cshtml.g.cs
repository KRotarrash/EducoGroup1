#pragma checksum "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f2656fdef12278ff7c07f6f0564ee4c5d154964"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurant_OrderSelect), @"mvc.1.0.view", @"/Views/Restaurant/OrderSelect.cshtml")]
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
#line 3 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
using WebApplication.Models.Restaurant;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f2656fdef12278ff7c07f6f0564ee4c5d154964", @"/Views/Restaurant/OrderSelect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ea7069f4d9b26b9cc12f9c9c6ca44dbeaa31e7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurant_OrderSelect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Restaurant.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 5 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4f2656fdef12278ff7c07f6f0564ee4c5d1549644409", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div class=""wrapper"">
    <div class=""rest-panel"">

        <div class=""header-rest"">
            Заказы Ресторана ""restname""!
        </div>

        <div class=""menu-table-result"">
            <table class=""menuTable"">
                <tbody>
                    <tr class=""tableHeader"">
                        <td colspan=""6"">Новые заказы</td>
                    </tr>
                    <tr class=""tableHeader2"">
                        <td>Номер</td>
                        <td>Дата</td>
                        <td>Пользователь</td>
                        <td>Блюдо</td>
                        <td>Итого</td>
                        <td>Действия</td>
                    </tr>
");
#nullable restore
#line 32 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
                     foreach (var order in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\n                            <td>");
#nullable restore
#line 35 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
                           Write(order.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 36 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
                           Write(order.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 37 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
                           Write(order.Customer.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>\n");
#nullable restore
#line 39 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
                                 foreach (var dish in order.Dishes)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p>");
#nullable restore
#line 41 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
                                  Write(dish.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 42 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\n                            <td>");
#nullable restore
#line 44 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
                           Write(order.TotalCost);

#line default
#line hidden
#nullable disable
            WriteLiteral(" р.</td>\n                            <td>\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1507, "\"", 1584, 1);
#nullable restore
#line 46 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
WriteAttributeValue("", 1514, Url.Action("ConfirmOrder", "Restaurant", new { @orderId = order.Id }), 1514, 70, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                    <span class=\"icon check\" title=\"Подтвердить заказ\"></span>\n                                </a>\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1753, "\"", 1860, 1);
#nullable restore
#line 49 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
WriteAttributeValue("", 1760, Url.Action("CancelOrder", "Restaurant", new { @orderId = order.Id, @redirectPage = "OrderSelect" }), 1760, 100, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                                    <span class=\"icon bad\" title=\"Отменить заказ\"></span>\n                                </a>\n                            </td>\n                        </tr>\n");
#nullable restore
#line 54 "C:\Users\Pasha\Source\Repos\EducoGroup1\MazeG1\WebApplication\Views\Restaurant\OrderSelect.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\n\n            </table>\n        </div>\n    </div>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591