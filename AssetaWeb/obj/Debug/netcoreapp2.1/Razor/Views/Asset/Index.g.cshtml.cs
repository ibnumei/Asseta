#pragma checksum "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Asset\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9c766c88cf18fc54d1965324a9b4eddaab39faa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Asset_Index), @"mvc.1.0.view", @"/Views/Asset/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Asset/Index.cshtml", typeof(AspNetCore.Views_Asset_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9c766c88cf18fc54d1965324a9b4eddaab39faa", @"/Views/Asset/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c003fc5d1c1c2ab41db4b531a739c8e31f8346", @"/Views/_ViewImports.cshtml")]
    public class Views_Asset_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AssetaWeb.Models.AssetTbl>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugin/components/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugin/components/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Asset\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(90, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(92, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccb95c778e5341f8abd539541a67c9a6", async() => {
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
            BeginContext(161, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(163, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f13c6b4946fd47a7a3c554f740a30594", async() => {
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
            BeginContext(250, 661, true);
            WriteLiteral(@"

<link href=""https://cdn.datatables.net/1.10.15/css/dataTables.bootstrap.min.css"" rel=""stylesheet"" />
<link href=""https://cdn.datatables.net/responsive/2.1.1/css/responsive.bootstrap.min.css"" rel=""stylesheet"" />

<script src=""https://cdn.datatables.net/1.10.15/js/jquery.dataTables.min.js""></script>
<script src=""https://cdn.datatables.net/1.10.15/js/dataTables.bootstrap4.min.js ""></script>

<section class=""content-header"">
    <h1>
        Asset Master
        <small></small>
    </h1>
    <ol class=""breadcrumb"">
        <li><a href=""#""> Master</a></li>
        <li class=""active"">Asset Master</li>
    </ol>
    <br />
    <p>
        ");
            EndContext();
            BeginContext(911, 155, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff98f56fd0f04ba4a53f671a97d53c4e", async() => {
                BeginContext(958, 104, true);
                WriteLiteral("\r\n            <i class=\"fa fa-plus-square\"></i>\r\n            <span>&nbsp;  Add New Data</span>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1066, 4671, true);
            WriteLiteral(@"
    </p>
</section>
<!-- Content Header (Page header) -->
<!-- Main content -->
<section class=""content container-fluid"">
    <div class=""box"">
        <div class=""box-header"">
            <h3 class=""box-title"">All of Data in Asset Master</h3>
        </div>
        <!-- /.box-header -->
        <div class=""box-body"">
            <table id=""example"" class=""table table-striped"" width=""100%"">
                <thead>
                    <tr>
                        <th>Asset Id</th>
                        <th>Asset Code</th>
                        <th>Asset Group</th>
                        <th>Asset Name</th>
                        <th>Serial Number</th>
                        <th>Validity date</th>
                        <th>Entity Name</th>
                        <th>Site Name</th>
                        <th>Location</th>
                        <th>Valuation</th>
                        <th></th>
                        <th></th>
                    </tr>
                ");
            WriteLiteral(@"</thead>

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
                    ""url"": ""/Asset/LoadData"",
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },
                ""columnDefs"":
                [{
                    ""targets"": [0],
                    ""visible"": false,
                    ""searchable"": false
                }],

                ""columns"": [
                    { ""data"": ""AssetId"", ""name"": ""AssetId"", ""autoWidth"": true },
                    { ""data""");
            WriteLiteral(@": ""AssetCode"", ""name"": ""AssetCode"", ""autoWidth"": true },
                    { ""data"": ""AssetGroupName"", ""name"": ""AssetGroupName"", ""autoWidth"": true },
                    { ""data"": ""AssetName"", ""name"": ""AssetName"", ""autoWidth"": true },
                    { ""data"": ""SerialNumber"", ""name"": ""SerialNumber"", ""autoWidth"": true },
                    {
                        ""data"": ""ValidityDate"", ""name"": ""ValidityDate"", ""autoWidth"": true, ""render"": function (data) {
                            var date = new Date(data);
                            var month = date.getMonth() + 1;
                            return (month.length > 1 ? month :  month) + ""-"" + date.getDate() + ""-"" + date.getFullYear();
                        }},
                    { ""data"": ""EntityName"", ""name"": ""EntityName"", ""autoWidth"": true },
                    { ""data"": ""SiteName"", ""name"": ""SiteName"", ""Contact"": true },
                    { ""data"": ""Location"", ""name"": ""Pic"", ""Location"": true },
                    { ""data"": """);
            WriteLiteral(@"Valuation"", ""name"": ""Valuation"", ""autoWidth"": true },
                    {
                        ""render"": function (data, type, full, meta)
                        //{ return '<a class=""btn btn-info"" href=""/DemoGrid/Edit/' + full.CustomerID + '"">Edit</a>'; }
                        { return ' <a href=""/Asset/Edit/' + full.AssetId + '"" class=""btn  btn-default""><i class=""fa fa-edit""></i><span>&nbsp;Edit</span></a>'; }
                    },
                    {
                        //data: null, render: function (data, type, row) {
                        //    return ""<a href='#' class='btn btn-default' onclick=DeleteData('"" + row.CustomerID + ""');>""Delete</a>"";
                        //}

                        ""render"": function (data, type, full, meta) {
                            return '<button type=""submit"" value=""Delete"" class=""btn btn-default"" onclick=""remove(' + full.AssetId + ')"" id=""aidi""><i class=""fas fa-trash-alt""></i> Delete </button>';
                        }
         ");
            WriteLiteral(@"           },
                ]

            });
    });

    function remove(aids) {

        //var myId = $('#TechnicianId').val();
        var myId = aids;

        swal({
            title: ""Are you sure?"",
            text: ""Once deleted, you will not be able to recover your data!"",
            icon: ""warning"",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        type: ""POST"",
                        url: '");
            EndContext();
            BeginContext(5738, 20, false);
#line 140 "C:\Users\ibnumei\Documents\Project\Asseta\AssetaWeb\Views\Asset\Index.cshtml"
                         Write(Url.Action("Delete"));

#line default
#line hidden
            EndContext();
            BeginContext(5758, 811, true);
            WriteLiteral(@"',
                        data: { id: myId},
                        dataType: ""json"",
                      // success: window.location.reload(),
                        success: function (response) {
                            swal(""Poof! Your data has been deleted!"", {
                                icon: ""success"",
                            }).then(function() {
                              //  window.location.href = ""/Technician/Index""
                                window.location.reload()
                            });
                           
                        }
                        
                    });

                }
                else {
                    swal(""Your data is safe!"");
                }
            });
        }
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AssetaWeb.Models.AssetTbl>> Html { get; private set; }
    }
}
#pragma warning restore 1591
