#pragma checksum "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f23335289c700db6af9320692911f6028ae8089"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DecksList), @"mvc.1.0.view", @"/Views/Home/DecksList.cshtml")]
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
#line 1 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\_ViewImports.cshtml"
using DeckSorter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\_ViewImports.cshtml"
using DeckSorter.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
using DeckSorter.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f23335289c700db6af9320692911f6028ae8089", @"/Views/Home/DecksList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98733c1fa869b178d9c3259b0cebf31ebf48375b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DecksList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DeckShortViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/deckslist.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/cards/preview.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 3 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
  
	ViewData["Title"] = "Decks List";
	int rows = (Model.Count / 6);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3f23335289c700db6af9320692911f6028ae80894903", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<h4>Доступно ");
#nullable restore
#line 8 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
        Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" колод</h4>\r\n<div class=\"decksregion\">\r\n");
#nullable restore
#line 10 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
     for (int i = 0; i <= rows; i++)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<div class=\"decksrow\">\r\n");
#nullable restore
#line 13 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
         for (int j = 0; j <= 4; j++)
		{
			int index = i * 5 + j;
			if (index >= Model.Count) break;
			string deckPath = "/decks/" + Model[index].Id;

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<a");
            BeginWriteAttribute("href", " href=", 486, "", 501, 1);
#nullable restore
#line 18 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
WriteAttributeValue("", 492, deckPath, 492, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t<div class=\"deckblock\">\r\n\t\t\t\t\t<div class=\"deckimagediv\">\r\n\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3f23335289c700db6af9320692911f6028ae80897358", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<span class=\"name\">");
#nullable restore
#line 23 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
                                  Write(Model[index].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t\t<span class=\"size\">");
#nullable restore
#line 24 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
                                  Write(Model[index].Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t\t\t\t</div>\r\n\t\t\t</a>\r\n");
#nullable restore
#line 27 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</div>\r\n");
#nullable restore
#line 29 "C:\Users\sasha\source\repos\DeckSorter\DeckSorter\Views\Home\DecksList.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DeckShortViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591