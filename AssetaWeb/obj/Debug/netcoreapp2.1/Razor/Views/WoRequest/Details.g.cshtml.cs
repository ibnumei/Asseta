#pragma checksum "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b701e4dcc8ac94bf4af37e6b937ae31365fd3a19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WoRequest_Details), @"mvc.1.0.view", @"/Views/WoRequest/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/WoRequest/Details.cshtml", typeof(AspNetCore.Views_WoRequest_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b701e4dcc8ac94bf4af37e6b937ae31365fd3a19", @"/Views/WoRequest/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c003fc5d1c1c2ab41db4b531a739c8e31f8346", @"/Views/_ViewImports.cshtml")]
    public class Views_WoRequest_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AssetaWeb.Models.WoRequestTbl>
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
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(83, 126, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>WoRequestTbl</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(210, 45, false);
#line 14 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RequestId));

#line default
#line hidden
            EndContext();
            BeginContext(255, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(299, 41, false);
#line 17 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.RequestId));

#line default
#line hidden
            EndContext();
            BeginContext(340, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(384, 47, false);
#line 20 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RequestDesc));

#line default
#line hidden
            EndContext();
            BeginContext(431, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(475, 43, false);
#line 23 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.RequestDesc));

#line default
#line hidden
            EndContext();
            BeginContext(518, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(562, 42, false);
#line 26 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SiteId));

#line default
#line hidden
            EndContext();
            BeginContext(604, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(648, 38, false);
#line 29 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.SiteId));

#line default
#line hidden
            EndContext();
            BeginContext(686, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(730, 46, false);
#line 32 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LocationId));

#line default
#line hidden
            EndContext();
            BeginContext(776, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(820, 42, false);
#line 35 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.LocationId));

#line default
#line hidden
            EndContext();
            BeginContext(862, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(906, 43, false);
#line 38 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetId));

#line default
#line hidden
            EndContext();
            BeginContext(949, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(993, 39, false);
#line 41 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.AssetId));

#line default
#line hidden
            EndContext();
            BeginContext(1032, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1076, 45, false);
#line 44 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetDesc));

#line default
#line hidden
            EndContext();
            BeginContext(1121, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1165, 41, false);
#line 47 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.AssetDesc));

#line default
#line hidden
            EndContext();
            BeginContext(1206, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1250, 40, false);
#line 50 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1290, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1334, 36, false);
#line 53 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1370, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1417, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d20fc98db8624002a314615f1b753ba1", async() => {
                BeginContext(1463, 4, true);
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
#line 58 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Details.cshtml"
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
            BeginContext(1471, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1479, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e65c159a610446a685551d61804541bd", async() => {
                BeginContext(1501, 12, true);
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
            BeginContext(1517, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AssetaWeb.Models.WoRequestTbl> Html { get; private set; }
    }
}
#pragma warning restore 1591
