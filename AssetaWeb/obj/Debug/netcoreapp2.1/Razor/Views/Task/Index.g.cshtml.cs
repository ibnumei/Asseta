#pragma checksum "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22dcb66b3fd7b96d78e943bfeb0e92e991311310"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Task_Index), @"mvc.1.0.view", @"/Views/Task/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Task/Index.cshtml", typeof(AspNetCore.Views_Task_Index))]
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
#line 1 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\_ViewImports.cshtml"
using AssetaWeb;

#line default
#line hidden
#line 2 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\_ViewImports.cshtml"
using AssetaWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22dcb66b3fd7b96d78e943bfeb0e92e991311310", @"/Views/Task/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c003fc5d1c1c2ab41db4b531a739c8e31f8346", @"/Views/_ViewImports.cshtml")]
    public class Views_Task_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AssetaWeb.Models.TaskTbl>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn  btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Site", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(87, 242, true);
            WriteLiteral("\r\n<section class=\"content-header\">\r\n    <h1>\r\n        Task Master\r\n        <small></small>\r\n    </h1>\r\n    <ol class=\"breadcrumb\">\r\n        <li>Master</li>\r\n        <li class=\"active\">Task Master</li>\r\n    </ol>\r\n    <br />\r\n    <p>\r\n        ");
            EndContext();
            BeginContext(329, 155, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e190357cdbab4414b2e1b874c8e09eca", async() => {
                BeginContext(376, 104, true);
                WriteLiteral("\r\n            <i class=\"fa fa-plus-square\"></i>\r\n            <span>&nbsp;  Add New Data</span>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(484, 794, true);
            WriteLiteral(@"
    </p>
</section>
<!-- Content Header (Page header) -->
<!-- Main content -->
<section class=""content container-fluid"">
    <div class=""box"">
        <div class=""box-header"">
            <h3 class=""box-title"">All of Data in Task Master</h3>
        </div>
        <!-- /.box-header -->
        <div class=""box-body"">
            <table id=""DataTableSite"" class=""table table-bordered table-striped"" width=""100%"">
                <thead>
                    <tr>
                        <th>Task Id</th>
                        <th>Task Code</th>
                        <th>Task Detail</th>
                        <th>Asset Group </th>
                        <th>Time Estimate</th>
                        <th></th>
                    </tr>
                </thead>
");
            EndContext();
#line 43 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1343, 125, true);
            WriteLiteral("                    <tbody>\r\n                        <tr>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1469, 33, false);
#line 48 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
                           Write(Html.DisplayFor(m => item.TaskId));

#line default
#line hidden
            EndContext();
            BeginContext(1502, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1606, 35, false);
#line 51 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
                           Write(Html.DisplayFor(m => item.TaskCode));

#line default
#line hidden
            EndContext();
            BeginContext(1641, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1745, 37, false);
#line 54 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
                           Write(Html.DisplayFor(m => item.TaskDetail));

#line default
#line hidden
            EndContext();
            BeginContext(1782, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(1886, 52, false);
#line 57 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
                           Write(Html.DisplayFor(m => item.AssetGroup.AssetGroupName));

#line default
#line hidden
            EndContext();
            BeginContext(1938, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2042, 39, false);
#line 60 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
                           Write(Html.DisplayFor(m => item.TimeEstimate));

#line default
#line hidden
            EndContext();
            BeginContext(2081, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2184, 231, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb93d52f8f994799b91aea7d1055c0cc", async() => {
                BeginContext(2258, 153, true);
                WriteLiteral("\r\n                                    <i class=\"fa fa-edit\"></i>\r\n                                    <span>Edit</span>\r\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 63 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
                                                       WriteLiteral(item.TaskId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2415, 42, true);
            WriteLiteral("&nbsp;\r\n\r\n                                ");
            EndContext();
            BeginContext(2457, 373, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37d611860ad54d3aa5216b5e10fd0c8f", async() => {
                BeginContext(2555, 129, true);
                WriteLiteral("\r\n                                    <i class=\"fas fa-trash-alt\"></i>\r\n                                    <span>Delete</span>\r\n");
                EndContext();
                BeginContext(2794, 32, true);
                WriteLiteral("                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 68 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
                                                                               WriteLiteral(item.TaskId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2830, 100, true);
            WriteLiteral("\r\n\r\n                            </td>\r\n                        </tr>\r\n                    </tbody>\r\n");
            EndContext();
#line 77 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Task\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2949, 93, true);
            WriteLiteral("\r\n            </table>\r\n        </div>\r\n        <!-- /.box-body -->\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AssetaWeb.Models.TaskTbl>> Html { get; private set; }
    }
}
#pragma warning restore 1591
