#pragma checksum "C:\Users\T\source\repos\MovieStore\MovieStore\Views\Home\Downloads.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "436bfd35e6b22b5a55ab4b7ad17ae58b91bb0274"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Downloads), @"mvc.1.0.view", @"/Views/Home/Downloads.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Downloads.cshtml", typeof(AspNetCore.Views_Home_Downloads))]
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
#line 1 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\_ViewImports.cshtml"
using MovieStore;

#line default
#line hidden
#line 2 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\_ViewImports.cshtml"
using MovieStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"436bfd35e6b22b5a55ab4b7ad17ae58b91bb0274", @"/Views/Home/Downloads.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a8c2dc702b202c6daeaeb5df09bdab9162bf52c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Downloads : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<string>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\Home\Downloads.cshtml"
  
    ViewData["Title"] = "Downloads";

#line default
#line hidden
            BeginContext(66, 26, true);
            WriteLiteral("\r\n<h2>Downloads</h2>\r\n<h3>");
            EndContext();
            BeginContext(93, 31, false);
#line 7 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\Home\Downloads.cshtml"
Write(Html.ActionLink("Back","Index"));

#line default
#line hidden
            EndContext();
            BeginContext(124, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 8 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\Home\Downloads.cshtml"
 using (@Html.BeginRouteForm("DownloadRoute", new { Action = "Downloading" }, FormMethod.Get))
{
    

#line default
#line hidden
#line 10 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\Home\Downloads.cshtml"
     for (var i = 0; i < Model.Count; i++)
    {

#line default
#line hidden
            BeginContext(281, 12, true);
            WriteLiteral("        <li>");
            EndContext();
            BeginContext(294, 19, false);
#line 12 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\Home\Downloads.cshtml"
       Write(Model[i].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(313, 2, true);
            WriteLiteral("  ");
            EndContext();
            BeginContext(316, 80, false);
#line 12 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\Home\Downloads.cshtml"
                             Write(Html.ActionLink("Download", "Download", new { imageName = Model[i].ToString() }));

#line default
#line hidden
            EndContext();
            BeginContext(396, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 13 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\Home\Downloads.cshtml"
    }

#line default
#line hidden
#line 13 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\Home\Downloads.cshtml"
     
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<string>> Html { get; private set; }
    }
}
#pragma warning restore 1591