#pragma checksum "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9505b20e709a4f01ce462e3e380aed8b504ae848"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SparepartRequest_Details), @"mvc.1.0.view", @"/Views/SparepartRequest/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/SparepartRequest/Details.cshtml", typeof(AspNetCore.Views_SparepartRequest_Details))]
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
#line 1 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\_ViewImports.cshtml"
using AssetaWeb;

#line default
#line hidden
#line 2 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\_ViewImports.cshtml"
using AssetaWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9505b20e709a4f01ce462e3e380aed8b504ae848", @"/Views/SparepartRequest/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c003fc5d1c1c2ab41db4b531a739c8e31f8346", @"/Views/_ViewImports.cshtml")]
    public class Views_SparepartRequest_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AssetaWeb.Models.SparepartRequestTbl>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(90, 133, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>SparepartRequestTbl</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(224, 48, false);
#line 14 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Availability));

#line default
#line hidden
            EndContext();
            BeginContext(272, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(316, 44, false);
#line 17 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.Availability));

#line default
#line hidden
            EndContext();
            BeginContext(360, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(404, 54, false);
#line 20 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SparepartRequestId));

#line default
#line hidden
            EndContext();
            BeginContext(458, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(502, 50, false);
#line 23 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.SparepartRequestId));

#line default
#line hidden
            EndContext();
            BeginContext(552, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(596, 40, false);
#line 26 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.WoId));

#line default
#line hidden
            EndContext();
            BeginContext(636, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(680, 36, false);
#line 29 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.WoId));

#line default
#line hidden
            EndContext();
            BeginContext(716, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(760, 42, false);
#line 32 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.WoDesc));

#line default
#line hidden
            EndContext();
            BeginContext(802, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(846, 38, false);
#line 35 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.WoDesc));

#line default
#line hidden
            EndContext();
            BeginContext(884, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(928, 40, false);
#line 38 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(968, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1012, 36, false);
#line 41 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1048, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1092, 42, false);
#line 44 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(1134, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1178, 38, false);
#line 47 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(1216, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1260, 42, false);
#line 50 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SiteId));

#line default
#line hidden
            EndContext();
            BeginContext(1302, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1346, 38, false);
#line 53 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.SiteId));

#line default
#line hidden
            EndContext();
            BeginContext(1384, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1428, 39, false);
#line 56 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Qty));

#line default
#line hidden
            EndContext();
            BeginContext(1467, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1511, 35, false);
#line 59 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.Qty));

#line default
#line hidden
            EndContext();
            BeginContext(1546, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1590, 41, false);
#line 62 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Notes));

#line default
#line hidden
            EndContext();
            BeginContext(1631, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1675, 37, false);
#line 65 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.Notes));

#line default
#line hidden
            EndContext();
            BeginContext(1712, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1759, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51b10e885f79444788a758158a85d20b", async() => {
                BeginContext(1805, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 70 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\SparepartRequest\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1813, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1821, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12b66978ce864e0eb2252ee9d42d0e53", async() => {
                BeginContext(1843, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1859, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AssetaWeb.Models.SparepartRequestTbl> Html { get; private set; }
    }
}
#pragma warning restore 1591
