#pragma checksum "C:\Project\Asseta\Asseta\AssetaWeb\Views\WorkOrder\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbb88e42eb32dfafef51f15573baa2b4f04058df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkOrder_Index), @"mvc.1.0.view", @"/Views/WorkOrder/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/WorkOrder/Index.cshtml", typeof(AspNetCore.Views_WorkOrder_Index))]
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
#line 1 "C:\Project\Asseta\Asseta\AssetaWeb\Views\_ViewImports.cshtml"
using AssetaWeb;

#line default
#line hidden
#line 2 "C:\Project\Asseta\Asseta\AssetaWeb\Views\_ViewImports.cshtml"
using AssetaWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbb88e42eb32dfafef51f15573baa2b4f04058df", @"/Views/WorkOrder/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c003fc5d1c1c2ab41db4b531a739c8e31f8346", @"/Views/_ViewImports.cshtml")]
    public class Views_WorkOrder_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AssetaWeb.Models.WorkOrderTbl>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugin/components/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugin/components/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Project\Asseta\Asseta\AssetaWeb\Views\WorkOrder\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(92, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(94, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2cd52d9ccf1e434c8f6458bb3d30cee1", async() => {
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
            BeginContext(163, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(165, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a105479d47cd47a086d6aa88c653cd44", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(252, 3835, true);
            WriteLiteral(@"

<link href=""https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css"" rel=""stylesheet"" />
<link href=""https://cdn.datatables.net/responsive/2.1.1/css/responsive.bootstrap.min.css"" rel=""stylesheet"" />

<script src=""https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js""></script>
<script src=""https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap4.min.js ""></script>

<section class=""content-header"">
    <h1>
        Work Order
        <small></small>
    </h1>
    <ol class=""breadcrumb"">
        <li class=""active"">Work Order</li>
    </ol>
    <br />

</section>
<!-- Content Header (Page header) -->
<!-- Main content -->
<section class=""content container-fluid"">
    <div class=""box"">
        <div class=""box-header"">
            <h3 class=""box-title"">All of Data in Work Order</h3>
        </div>
        <!-- /.box-header -->
        <div class=""box-body"">
            <table id=""example"" class=""table table-striped"" width=""100%"">
                <thead>
     ");
            WriteLiteral(@"               <tr>
                        <th style=""width:15%"">WO Id</th>
                        <th style=""width:25%"">Wo Desc</th>
                        <th style=""width:30%"">Status</th>
                        <th style=""width:15%"">Priority</th>
                        <th style=""width:5%""></th>
                        <th style=""width:5%""></th>

                    </tr>
                </thead>
               
            </table>
        </div>
        <!-- /.box-body -->
    </div>
</section>

<script>


        $(document).ready(function ()
        {
            $(""#example"").DataTable({
                ""processing"": true, // for show progress bar
                ""serverSide"": true, // for process server side
                ""filter"": true, // this is for disable filter (search box)
                ""orderMulti"": true, // for disable multiple column at once
                ""ordering"": false,
                ""ajax"": {
                    ""url"": ""/WorkOrder/LoadData"",
 ");
            WriteLiteral(@"                   ""type"": ""POST"",
                    ""datatype"": ""json""
                },

                ""columns"": [
                    { ""data"": ""WoId"", ""name"": ""WoId"", ""autoWidth"": true },
                    { ""data"": ""WoDesc"", ""name"": ""WoDesc"", ""autoWidth"": true },
                    { ""data"": ""Status"", ""name"": ""Status"", ""autoWidth"": true },
                    { ""data"": ""Priority"", ""name"": ""Priority"", ""autoWidth"": true },
                    {
                        ""render"": function (data, type, full, meta)
                        {
                            return '<button type=""submit"" value=""submit"" class=""btn btn-default"" onclick=""remove(' + full.WoId + ')"" id=""aidi""><i class=""fas fa-play""></i> Run </button>';
                        }
                    },
                    {
                        ""render"": function (data, type, full, meta)
                        //{ return '<a class=""btn btn-info"" href=""/DemoGrid/Edit/' + full.CustomerID + '"">Edit</a>'; }
      ");
            WriteLiteral(@"                  { return ' <a href=""/WorkOrder/Edit/' + full.WoId + '"" class=""btn  btn-default""><i class=""fa fa-edit""></i><span>&nbsp;Edit</span></a>'; }
                    },
                    
                ]

            });
        });

   function remove(aids) {

        //var myId = $('#TechnicianId').val();
        var myId = aids;

        swal({
            title: ""Create Work Order Execution"",
            text: ""Are you sure want to Create WO Execution ?"",
            icon: ""info"",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        type: ""POST"",
                        url: '");
            EndContext();
            BeginContext(4088, 17, false);
#line 109 "C:\Project\Asseta\Asseta\AssetaWeb\Views\WorkOrder\Index.cshtml"
                         Write(Url.Action("Run"));

#line default
#line hidden
            EndContext();
            BeginContext(4105, 762, true);
            WriteLiteral(@"',
                        data: { id: myId},
                        dataType: ""json"",
                      // success: window.location.reload(),
                        success: function (response) {
                            swal(""Yeay, you've create WO Execution"", {
                                icon: ""success"",
                            }).then(function() {
                              //  window.location.href = ""/Technician/Index""
                                window.location.reload()
                            });

                        }

                    });

                }
                else {
                    swal(""Comeback later ^_^ ! "");
                }
            });
        }


</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AssetaWeb.Models.WorkOrderTbl>> Html { get; private set; }
    }
}
#pragma warning restore 1591
