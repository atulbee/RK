#pragma checksum "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Shared\_Footer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c00b69c1c35f82eed86f5d160da2570a22621439"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Footer), @"mvc.1.0.view", @"/Views/Shared/_Footer.cshtml")]
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
#line 1 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\_ViewImports.cshtml"
using CreativeTim.Argon.DotNetCore.Free;

#line default
#line hidden
#line 2 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\_ViewImports.cshtml"
using CreativeTim.Argon.DotNetCore.Free.Infrastructure.ApplicationUserClaims;

#line default
#line hidden
#line 3 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\_ViewImports.cshtml"
using CreativeTim.Argon.DotNetCore.Free.Models;

#line default
#line hidden
#line 4 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\_ViewImports.cshtml"
using CreativeTim.Argon.DotNetCore.Free.Models.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c00b69c1c35f82eed86f5d160da2570a22621439", @"/Views/Shared/_Footer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abb5183b2aa582624ec1158b663a4393e8deee55", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Footer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<input type=\"hidden\" id=\"RequestVerificationToken\"\n       name=\"RequestVerificationToken\"");
            BeginWriteAttribute("value", " value=\"", 280, "\"", 314, 1);
#line 10 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Shared\_Footer.cshtml"
WriteAttributeValue("", 288, GetAntiXsrfRequestToken(), 288, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(">\n\n<footer class=\"footer\">\n    <div class=\"row align-items-center justify-content-xl-between\">\n        <div class=\"col-xl-6\">\n        \n        </div>\n        <div class=\"col-xl-6\">\n           \n        </div>\n    </div>\n</footer>\n");
        }
        #pragma warning restore 1998
#line 2 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Shared\_Footer.cshtml"
           
    public string GetAntiXsrfRequestToken()
    {
        return Xsrf.GetAndStoreTokens(Context).RequestToken;
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf { get; private set; }
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
