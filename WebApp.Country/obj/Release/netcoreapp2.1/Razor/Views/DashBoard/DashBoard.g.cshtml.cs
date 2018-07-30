#pragma checksum "F:\CountryWebApp\WebApp.Country\Views\DashBoard\DashBoard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04f18530f024489a2330f035d4110256f91c3703"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DashBoard_DashBoard), @"mvc.1.0.view", @"/Views/DashBoard/DashBoard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DashBoard/DashBoard.cshtml", typeof(AspNetCore.Views_DashBoard_DashBoard))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04f18530f024489a2330f035d4110256f91c3703", @"/Views/DashBoard/DashBoard.cshtml")]
    public class Views_DashBoard_DashBoard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/dashbaord.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "F:\CountryWebApp\WebApp.Country\Views\DashBoard\DashBoard.cshtml"
  
    ViewData["Title"] = "DashBoard";
    Layout = "~/Views/Shared/_AppLayout.cshtml";

#line default
#line hidden
            BeginContext(97, 1358, true);
            WriteLiteral(@"<h2 class=""text-center mb-4"">DashBoard</h2>
<div class=""row"">
    <div class=""col-sm-4 sticky"">
        <div class=""box-header mt-3"">
            <h3 class=""box-title"">
                User Profile
            </h3>
        </div>
        <div class=""box mb-3 box-p"" id=""div-user-profile"">
        </div>
    </div>
    <div class=""col-sm-8"">
        <div class=""tab mb-3 border-gray-dark"">
            <nav class=""tab-body"" aria-label=""Navigate your dashboard"">
                <a href=""javascript:void(0);"" id=""anc-activity"" onclick=""ShowHide('div-recent', 'div-favourite'); toggleClass('anc-activity','anc-favourite');"" class=""tab-item selected"" aria-current=""page"">Browse activity</a>
                <a href=""javascript:void(0);"" id=""anc-favourite"" onclick=""ShowHide('div-favourite', 'div-recent');toggleClass('anc-favourite','anc-activity');"" class=""tab-item"" aria-current=""page"">Browse favourites</a>
            </nav>
        </div>
        <div id=""div-recent"" style=""display:none;"">
           ");
            WriteLiteral(@" <h4 class=""mt-3 text-normal"">Recent activity</h4>
            <div id=""div-activity"">
            </div>
        </div>
        <div id=""div-favourite"" style=""display:none;"">
            <h4 class=""mt-3 text-normal"">Favourite List</h4>
            <div id=""div-favour"">
            </div>
        </div>
    </div>
</div>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1473, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1479, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "98c908546b284180817c1bb8437f3939", async() => {
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
                EndContext();
                BeginContext(1525, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
