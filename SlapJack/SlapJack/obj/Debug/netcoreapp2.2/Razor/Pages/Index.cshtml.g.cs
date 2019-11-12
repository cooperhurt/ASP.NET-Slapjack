#pragma checksum "C:\Users\noret\Documents\GitHub\CS3750-GroupAssignment\SlapJack\SlapJack\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcc87ef12a6d00df9b65d3483b357ea176187604"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SlapJack.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(SlapJack.Pages.Pages_Index), null)]
namespace SlapJack.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\noret\Documents\GitHub\CS3750-GroupAssignment\SlapJack\SlapJack\Pages\_ViewImports.cshtml"
using SlapJack;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcc87ef12a6d00df9b65d3483b357ea176187604", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02d9817943eff80f8eb2ee1e95d926ccb04b39c4", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "playgame", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\noret\Documents\GitHub\CS3750-GroupAssignment\SlapJack\SlapJack\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
            BeginContext(71, 2833, true);
            WriteLiteral(@"
    <div class=""text-center"">
        <h1 class=""display-4"">Welcome to Egyptian Rat Screw</h1>
        <div id=""rules"">
            <h3>How to play Egyptian Rat Screw</h3>
            <ul class=""list-group"">
                <li class=""list-group-item active""><b>Home the game Plays:</b></li>
                <li class=""list-group-item"">The game starts by shuffling a deck of 52 cards into two piles of 26 cards, each player having a pile.  The main deck in the middle has 0 cards.</li>
                <li class=""list-group-item list-group-item-secondary"">Each player takes turns playing (usually) one card at a time from his or her hand into the main deck.</li>
                <li class=""list-group-item"">You can slap if two successive cards are the same value (2-10, J, Q, K, A) appear on the main deck stack. Suits don't matter.  The winner of the slap plays the next card.</li>
                <li class=""list-group-item list-group-item-secondary"">Slapping illegally is penalized by losing two cards into the");
            WriteLiteral(@" BOTTOM of the main deck. Turn order resumes as it should.</li>
                <li class=""list-group-item"">Each player takes turns alternating placing a card into the main deck.</li>
                <li class=""list-group-item active""><b>How Face Cards work:</b></li>
                <li class=""list-group-item"">If a player plays a Queen, the other player must play 2 cards. If any of those two cards are a face card (J, Q, K, or A), then the rule restarts for that face card. Note, if the first card was Q, then it's slappable. If that card was 2-10, the person who played the Q gets the main deck.
                <li class=""list-group-item list-group-item-secondary"">If a player plays a Jack, the other player must play 3 cards. If any of those three cards are a face card (J, Q, K, or A), then the rule restarts for that face card. Note, if the first card was K, then it's slappable. If that card was 2-10, the person who played the K  gets the main deck.</li>
                <li class=""list-group-item"">If a playe");
            WriteLiteral(@"r plays a King, the other player must play 4 cards. If any of those four cards are a face card (J, Q, K, or A), then the rule restarts for that face card. Note, if the first card was K, then it's slappable. If that card was 2-10, the person who played the K  gets the main deck.</li>
                <li class=""list-group-item list-group-item-secondary"">If a player plays a Ace, the other player must play 4 cards. If any of those four cards are a face card (J, Q, K, or A), then the rule restarts for that face card. Note, if the first card was K, then it's slappable. If that card was 2-10, the person who played the K  gets the main deck.</li>
            </ul>
        </div>
        <button type=""button"" ID=""ruleShow"" class=""btn btn-secondary"">Show Rules</button>

        ");
            EndContext();
            BeginContext(2904, 119, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fcc87ef12a6d00df9b65d3483b357ea1761876046455", async() => {
                BeginContext(2927, 92, true);
                WriteLiteral("\r\n            <button type=\"button\" class=\"btn btn-primary\">Play the Game</button>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3023, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
