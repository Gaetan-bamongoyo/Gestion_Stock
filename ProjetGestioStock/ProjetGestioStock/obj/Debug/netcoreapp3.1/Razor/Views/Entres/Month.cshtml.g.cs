#pragma checksum "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b7cab3a9034d299e47cfe411e3c1e22afcf3a3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Entres_Month), @"mvc.1.0.view", @"/Views/Entres/Month.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\_ViewImports.cshtml"
using ProjetGestioStock;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\_ViewImports.cshtml"
using ProjetGestioStock.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b7cab3a9034d299e47cfe411e3c1e22afcf3a3c", @"/Views/Entres/Month.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21d80ca1efa1bf7ff91262e6d33f5ee7c23dddaf", @"/Views/_ViewImports.cshtml")]
    public class Views_Entres_Month : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProjetGestioStock.Models.TblEntre>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml"
  
    ViewData["Title"] = "Month";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<header class=""mb-3"">
    <a href=""#"" class=""burger-btn d-block d-xl-none"">
        <i class=""bi bi-justify fs-3""></i>
    </a>
</header>

<div class=""page-heading"">

    <!-- Basic Tables start -->
    <section class=""section"">
        <div class=""card"">
            <div class=""card-header"">
                Jquery Datatable
            </div>
            <div class=""card-body"">
                <table class=""table"" id=""table1"">
                    <thead>
                        <tr>
                            <th>Produit</th>
                            <th>Quantite</th>
                            <th>Prix achat</th>
                            <th>Date expiration</th>
                            <th>Date achat</th>
                            <th>Fournisseur</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 34 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 39 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Designation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 42 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Qte));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 45 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Pu));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 48 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Dateexpiration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 51 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Dateday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 54 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml"
                               Write(Html.DisplayFor(modelItem => item.NomFournisseur));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Gabin\OneDrive\Images\ProjetGestioStock\ProjetGestioStock\Views\Entres\Month.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n\r\n    </section>\r\n    <!-- Basic Tables end -->\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProjetGestioStock.Models.TblEntre>> Html { get; private set; }
    }
}
#pragma warning restore 1591
