#pragma checksum "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b11f3e6ddab171493a9a419eccd8c675231cb3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 4 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b11f3e6ddab171493a9a419eccd8c675231cb3a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46c003fc5d1c1c2ab41db4b531a739c8e31f8346", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(80, 114, true);
            WriteLiteral("\r\n<section class=\"content-header\">\r\n    <h1>\r\n        Dashboard\r\n        <small>Control panel</small>\r\n        <p>");
            EndContext();
            BeginContext(195, 37, false);
#line 10 "C:\Users\ibnumei\Documents\Project\Asseta\Asseta\AssetaWeb\Views\Home\Index.cshtml"
      Write(Context.Session.GetString("Username"));

#line default
#line hidden
            EndContext();
            BeginContext(232, 2581, true);
            WriteLiteral(@"</p>
    </h1>
    <ol class=""breadcrumb"">
        <li><a href=""#""> Home</a></li>
        <li class=""active"">Dashboard</li>

    </ol>
</section>
<!-- Content Header (Page header) -->
<!-- Main content -->
<section class=""content container-fluid"">
    <div class=""row"">
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-aqua"">
                <div class=""inner"">
                    

                    <h3>45</h3>

                    <p>Total Asset</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-folder""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-green"">
                <div class=""inner"">
                    <!-- <h");
            WriteLiteral(@"3>53<sup style=""font-size: 20px"">%</sup></h3> -->
                    <h3>20</h3>

                    <p>Total Entity</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-stats-bars""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-yellow"">
                <div class=""inner"">
                    <h3>43</h3>

                    <p>Total Schedule Maintenance</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-settings""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
        <div class=""col-lg-3 col-x");
            WriteLiteral(@"s-6"">
            <!-- small box -->
            <div class=""small-box bg-red"">
                <div class=""inner"">
                    <h3>5</h3>

                    <p>Work Order Request</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-clipboard""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
            </div>
        </div>
        <!-- ./col -->
    </div>
</section>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
