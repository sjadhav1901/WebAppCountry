#pragma checksum "F:\CountryWebApp\WebApp.Country\Views\CMS\ManageCountry.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "136c345fe3e3d9427375d8ad3d6b12ea0073e073"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CMS_ManageCountry), @"mvc.1.0.view", @"/Views/CMS/ManageCountry.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CMS/ManageCountry.cshtml", typeof(AspNetCore.Views_CMS_ManageCountry))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"136c345fe3e3d9427375d8ad3d6b12ea0073e073", @"/Views/CMS/ManageCountry.cshtml")]
    public class Views_CMS_ManageCountry : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/scripts/cms/country-manager.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "F:\CountryWebApp\WebApp.Country\Views\CMS\ManageCountry.cshtml"
  
    ViewData["Title"] = "ManageCountry";
    Layout = "~/Views/Shared/_AppLayout.cshtml";

#line default
#line hidden
            BeginContext(101, 1051, true);
            WriteLiteral(@"<div class=""jumbotron text-center"" style=""padding: 6px;background: linear-gradient(180deg,#f2f2f2 0,#fff);border-bottom: 2px solid lightgray;"">
    <h2>Country Management</h2>
</div>
<table id=""example"" class=""table table-bordered"" style=""font-size:13px;width:100%"">
    <thead>
        <tr>
            <th>Name</th>
            <th>Alpha Two Code</th>
            <th>Alpha Three Code</th>
            <th>Capital</th>
            <th>Languages</th>
            <th>Currencies</th>
            <th>Flag</th>
            <th>Time Zone</th>
            <th style=""min-width: 120px !important;"">Action</th>
        </tr>
    </thead>
    <tbody id=""table-body""></tbody>
    <tfoot>
        <tr>
            <th>Name</th>
            <th>Alpha Two Code</th>
            <th>Alpha Three Code</th>
            <th>Capital</th>
            <th>Languages</th>
            <th>Currency</th>
            <th>Flag</th>
            <th>Time Zone</th>
            <th>Action</th>
        </tr>
    </tfoot");
            WriteLiteral(">\r\n</table>\r\n<br /><br />\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(1169, 525, true);
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css"" />
    <style>
        .table th {
            font-weight: 500;
            height: 40px;
        }

        .table td, .table th {
            padding: 8px 11px;
        }

        .table tr th {
            background: linear-gradient(180deg,#f2f2f2 0,#fff);
            color: #337ab7;
        }

        table.dataTable {
            border-collapse: collapse !important;
        }
    </style>
");
                EndContext();
            }
            );
            DefineSection("scripts", async() => {
                BeginContext(1715, 263, true);
                WriteLiteral(@"
    <script src=""https://code.jquery.com/jquery-3.3.1.js""></script>
    <script src=""https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js""></script>
    ");
                EndContext();
                BeginContext(1978, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b11f44a56d8043d1a06a7fcc04402407", async() => {
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
                BeginContext(2034, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(2039, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
