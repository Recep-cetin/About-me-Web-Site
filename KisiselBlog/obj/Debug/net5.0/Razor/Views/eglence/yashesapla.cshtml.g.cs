#pragma checksum "C:\Users\MONSTER\Desktop\KisiselBlog\KisiselBlog\Views\eglence\yashesapla.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b53580b23919949f9468f89dc8ac9b4204a55fe4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_eglence_yashesapla), @"mvc.1.0.view", @"/Views/eglence/yashesapla.cshtml")]
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
#line 1 "C:\Users\MONSTER\Desktop\KisiselBlog\KisiselBlog\Views\_ViewImports.cshtml"
using KisiselBlog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MONSTER\Desktop\KisiselBlog\KisiselBlog\Views\_ViewImports.cshtml"
using KisiselBlog.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b53580b23919949f9468f89dc8ac9b4204a55fe4", @"/Views/eglence/yashesapla.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59e44facd34fc26581da87c2067e0d6074402084", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_eglence_yashesapla : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KisiselBlog.Models.yashesaplama>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>bilgi ekle</h1>\r\n\r\n<h4>kisi</h4>\r\n\r\n\r\n<hr />\r\n \r\n");
#nullable restore
#line 10 "C:\Users\MONSTER\Desktop\KisiselBlog\KisiselBlog\Views\eglence\yashesapla.cshtml"
         using (Html.BeginForm("yashesapla"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <table>\r\n            <tr>\r\n                <td>Ad??: </td>\r\n                <td><input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 262, "\"", 270, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"adi\" id=\"adi\" /></td>\r\n            </tr>\r\n            <tr>\r\n                <td>Soyad??: </td>\r\n                <td><input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 411, "\"", 419, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"soyadi\" id=\"soyadi\" /></td>\r\n            </tr>\r\n            <tr>\r\n                <td>meslek: </td>\r\n                <td><input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 566, "\"", 574, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"meslek\" id=\"meslek\" /></td>\r\n            </tr>\r\n                        <tr>\r\n                <td>E posta: </td>\r\n                <td><input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 734, "\"", 742, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"email\" id=\"email\" /></td>\r\n            </tr>\r\n            <tr>\r\n                <td>Dohum tarihiniz : </td>\r\n                <td><input type=\"datetime\"");
            BeginWriteAttribute("value", " value=\"", 901, "\"", 909, 0);
            EndWriteAttribute();
            WriteLiteral(" name=\"dogum_tarihi\" id=\"dogum_tarihi\" /></td>\r\n            </tr>\r\n            <tr>\r\n                \r\n                <td colspan=\"2\"><input type=\"submit\" value=\"Kaydet\" /></td>\r\n            </tr>\r\n        </table>\r\n");
#nullable restore
#line 38 "C:\Users\MONSTER\Desktop\KisiselBlog\KisiselBlog\Views\eglence\yashesapla.cshtml"
            }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KisiselBlog.Models.yashesaplama> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
