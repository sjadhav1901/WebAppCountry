#pragma checksum "F:\CountryWebApp\WebApp.Country\Views\Authentication\ResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "222e485811f95fc994f82fe719de49c1c4f72604"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Authentication_ResetPassword), @"mvc.1.0.view", @"/Views/Authentication/ResetPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Authentication/ResetPassword.cshtml", typeof(AspNetCore.Views_Authentication_ResetPassword))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"222e485811f95fc994f82fe719de49c1c4f72604", @"/Views/Authentication/ResetPassword.cshtml")]
    public class Views_Authentication_ResetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/Authentication/reset-password.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "F:\CountryWebApp\WebApp.Country\Views\Authentication\ResetPassword.cshtml"
  
    ViewData["Title"] = "Reset Password";
    Layout = "~/Views/Shared/_Authentication.cshtml";

#line default
#line hidden
            BeginContext(107, 1250, true);
            WriteLiteral(@"<form class=""form-signin"">
    <div class=""text-center mb-2"">
        <h1 class=""h3 mb-3"">My Country</h1>
    </div>
    <div id=""auth-forgot"">
        <div class=""form-signin-body"">
            <p><b>Reset your password</b></p>
            <div class=""form-label-group"">
                <input type=""password"" id=""input-password"" class=""form-control"" placeholder=""Password"" required autofocus>
                <label for=""input-password"">Password</label>
            </div>
            <div class=""form-label-group"">
                <input type=""password"" id=""input-confirm-password"" class=""form-control"" placeholder=""Confirm Password"" required autofocus>
                <label for=""input-confirm-password"">Confirm Password</label>
            </div>
            <div class=""alert alert-success"" role=""alert"" id=""alert-error"" style=""display:none;"">
            </div>
            <button class=""btn btn-lg btn-success btn-block"" id=""btn-reset-pwd"" data-loading-text=""<i class='fa fa-spinner fa-spin'></i> ");
            WriteLiteral("Reset Password...\" type=\"submit\">Reset Password</button>\r\n        </div>\r\n        <p class=\"create-account-body mt-3\">\r\n            Remembered password?\r\n            <a href=\"/\">Sign In</a>\r\n        </p>\r\n    </div>\r\n</form>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1375, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1381, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62b58b52428243a3be70d5665a997c5e", async() => {
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
                BeginContext(1447, 2, true);
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
