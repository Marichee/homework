#pragma checksum "C:\Users\T\source\repos\MovieStore\MovieStore\Views\MovieOrder\OrderDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ca0b7ad9987ddca847978f79ed0028acde425c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MovieOrder_OrderDetails), @"mvc.1.0.view", @"/Views/MovieOrder/OrderDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MovieOrder/OrderDetails.cshtml", typeof(AspNetCore.Views_MovieOrder_OrderDetails))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ca0b7ad9987ddca847978f79ed0028acde425c0", @"/Views/MovieOrder/OrderDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a8c2dc702b202c6daeaeb5df09bdab9162bf52c", @"/Views/_ViewImports.cshtml")]
    public class Views_MovieOrder_OrderDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieOrderModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\MovieOrder\OrderDetails.cshtml"
  
    ViewData["Title"] = "OrderDetails";

#line default
#line hidden
            BeginContext(73, 4, true);
            WriteLiteral("<h3>");
            EndContext();
            BeginContext(78, 32, false);
#line 5 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\MovieOrder\OrderDetails.cshtml"
Write(Html.ActionLink("Back", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(110, 45, true);
            WriteLiteral("</h3>\r\n<div>\r\n    <strong>Order Id</strong>: ");
            EndContext();
            BeginContext(156, 13, false);
#line 7 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\MovieOrder\OrderDetails.cshtml"
                          Write(Model.OrderID);

#line default
#line hidden
            EndContext();
            BeginContext(169, 36, true);
            WriteLiteral("<br />\r\n    <strong>Movie</strong>: ");
            EndContext();
            BeginContext(206, 11, false);
#line 8 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\MovieOrder\OrderDetails.cshtml"
                       Write(Model.Movie);

#line default
#line hidden
            EndContext();
            BeginContext(217, 39, true);
            WriteLiteral("<br />\r\n    <strong>Quantity</strong>: ");
            EndContext();
            BeginContext(257, 14, false);
#line 9 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\MovieOrder\OrderDetails.cshtml"
                          Write(Model.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(271, 36, true);
            WriteLiteral("<br />\r\n    <strong>Price</strong>: ");
            EndContext();
            BeginContext(308, 11, false);
#line 10 "C:\Users\T\source\repos\MovieStore\MovieStore\Views\MovieOrder\OrderDetails.cshtml"
                       Write(Model.Price);

#line default
#line hidden
            EndContext();
            BeginContext(319, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieOrderModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
