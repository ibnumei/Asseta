#pragma checksum "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86c122e2bd6d5ed724e02dac6dca66fde5f5cd74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WoRequest_Delete), @"mvc.1.0.view", @"/Views/WoRequest/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/WoRequest/Delete.cshtml", typeof(AspNetCore.Views_WoRequest_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86c122e2bd6d5ed724e02dac6dca66fde5f5cd74", @"/Views/WoRequest/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c003fc5d1c1c2ab41db4b531a739c8e31f8346", @"/Views/_ViewImports.cshtml")]
    public class Views_WoRequest_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AssetaWeb.Models.WoRequestTbl>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(82, 173, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>WoRequestTbl</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(256, 45, false);
#line 15 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.RequestId));

#line default
#line hidden
            EndContext();
            BeginContext(301, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(345, 41, false);
#line 18 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayFor(model => model.RequestId));

#line default
#line hidden
            EndContext();
            BeginContext(386, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(430, 47, false);
#line 21 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.RequestDesc));

#line default
#line hidden
            EndContext();
            BeginContext(477, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(521, 43, false);
#line 24 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayFor(model => model.RequestDesc));

#line default
#line hidden
            EndContext();
            BeginContext(564, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(608, 42, false);
#line 27 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SiteId));

#line default
#line hidden
            EndContext();
            BeginContext(650, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(694, 38, false);
#line 30 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SiteId));

#line default
#line hidden
            EndContext();
            BeginContext(732, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(776, 46, false);
#line 33 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LocationId));

#line default
#line hidden
            EndContext();
            BeginContext(822, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(866, 42, false);
#line 36 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayFor(model => model.LocationId));

#line default
#line hidden
            EndContext();
            BeginContext(908, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(952, 43, false);
#line 39 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetId));

#line default
#line hidden
            EndContext();
            BeginContext(995, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1039, 39, false);
#line 42 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AssetId));

#line default
#line hidden
            EndContext();
            BeginContext(1078, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1122, 45, false);
#line 45 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AssetDesc));

#line default
#line hidden
            EndContext();
            BeginContext(1167, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1211, 41, false);
#line 48 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AssetDesc));

#line default
#line hidden
            EndContext();
            BeginContext(1252, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1296, 40, false);
#line 51 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1336, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1380, 36, false);
#line 54 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1416, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(1454, 207, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1bbcb224d6a493d805ee0e9fc281815", async() => {
                BeginContext(1480, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1490, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7d2fee0f67c44d76a94820f5581453b5", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 59 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\WoRequest\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1526, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(1610, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "183f12298b234b21b0e324a31ad55e19", async() => {
                    BeginContext(1632, 12, true);
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
                BeginContext(1648, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1661, 10, true);
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
