#pragma checksum "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1405ab0b075fa1cda440f02ac5a69015d1ecdae5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Default__OpenClosePartial), @"mvc.1.0.view", @"/Views/Default/_OpenClosePartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1405ab0b075fa1cda440f02ac5a69015d1ecdae5", @"/Views/Default/_OpenClosePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abb5183b2aa582624ec1158b663a4393e8deee55", @"/Views/_ViewImports.cshtml")]
    public class Views_Default__OpenClosePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OpClPartialViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!--Star Kalyan Result Row-->\r\n<div class=\"container box-border pad-left-rig-0 star-result\">\r\n    <h3>STAR KALYAN RESULT</h3>\r\n    <h4 class=\"banner\">World Me Sabse Fast Satta Matka Result</h4>\r\n");
#line 12 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
      
        var preTimeSlot = "";
        var deviderCount=0;
        foreach (var item in Model.tblOpCls)
        {
            

#line default
#line hidden
#line 17 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
             if ((deviderCount%10)==0)
            {

#line default
#line hidden
            WriteLiteral("                <div class=\"fullwidth\" style=\"background-color:#DFFF00;\">\r\n                   <br />\r\n                </div>\r\n");
#line 22 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
            }

#line default
#line hidden
            WriteLiteral("            <div class=\"fullwidth\">\r\n                <div class=\"col-xs-3\">\r\n                    <a href=\"/jodichart\" class=\"btn_chart\">Jodi</a>\r\n                </div>\r\n                <div class=\"col-xs-6\">\r\n");
#line 28 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
                      
                        var op = @item.op.ToString() == "101010" ? "000" : @item.op.ToString();
                        var jd = @item.jd;
                        var newJodi = jd.ToString();
                        var cl = @item.cl.ToString() == "101010" ? "000" : @item.cl.ToString();
                        if (jd.ToString().Length > 2 || jd.ToString() == "10")
                        {

                            var jodiString = jd.ToString();
                            if (jodiString.Substring(0, 2) == "10")
                            {
                                newJodi = "0" + jodiString.Substring(2);
                            }
                            if (jd.ToString().Length > 3)
                            {
                                if (jodiString.Substring(jodiString.Length - 2, 2) == "10")
                                {
                                    if (jodiString.Substring(0, 2) == "10")
                                        newJodi = "00";
                                    else
                                        newJodi = jodiString.Substring(jodiString.Length - 2, 2) + "0";
                                }
                            }
                            else if (jd.ToString().Length == 3)
                            {
                                if (jodiString.Substring(0, 2) == "10")
                                {
                                    newJodi = "0" + jodiString.Substring(2);
                                }
                                if (jodiString.Substring(jodiString.Length - 2, 2) == "10")
                                {
                                    newJodi = jodiString.Substring(0, 1) + "0";
                                }

                            }

                        }
                    

#line default
#line hidden
            WriteLiteral("                    <h5>");
#line 66 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
                           var o = op == "0" ? "" : op; 

#line default
#line hidden
            WriteLiteral(" ");
#line 66 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
                                                     Write(o);

#line default
#line hidden
            WriteLiteral("-");
#line 66 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
                                                        Write(newJodi);

#line default
#line hidden
#line 66 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
                                                                        var c = cl == "0" ? "" : ("-" + cl); 

#line default
#line hidden
#line 66 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
                                                                                                         Write(c);

#line default
#line hidden
            WriteLiteral("</h5>\r\n                    <h6>");
#line 67 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
                   Write(item.timeslot);

#line default
#line hidden
            WriteLiteral("</h6>\r\n                </div>\r\n                <div class=\"col-xs-3\">\r\n                    <a href=\"/pannelchart\" class=\"btn_chart float-right\">Panel</a>\r\n                </div>\r\n                <div class=\"clearfix\"></div>\r\n\r\n            </div>\r\n");
#line 75 "C:\Users\Atul\OneDrive\Documents\Projects\RKBoss.net\RK\RK\Views\Default\_OpenClosePartial.cshtml"
            deviderCount = deviderCount+1;
        }
    

#line default
#line hidden
            WriteLiteral("\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OpClPartialViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
