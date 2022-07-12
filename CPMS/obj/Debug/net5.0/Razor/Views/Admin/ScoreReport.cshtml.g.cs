#pragma checksum "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7de8748f3d1be20c662d92218803ad0a853b947f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ScoreReport), @"mvc.1.0.view", @"/Views/Admin/ScoreReport.cshtml")]
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
#line 1 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\_ViewImports.cshtml"
using CPMS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\_ViewImports.cshtml"
using CPMS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7de8748f3d1be20c662d92218803ad0a853b947f", @"/Views/Admin/ScoreReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ac856a900091b3b7cf7c5a3c8bb569354922970", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_ScoreReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ScoreReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AuthorReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReviewerReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CommentReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
  
    Layout = "~/Views/Shared/Admin_Layout.cshtml";
    ViewData["Title"] = "ScoreReport";
    string[] TableHeaders = new string[] {
         "Title"
        ,"AppropriatenessOfTopic"
        ,"TimelinessOfTopic"
        ,"SupportiveEvidence"
        ,"TechnicalQuality"
        ,"ScopeOfCoverage"
        ,"CitationOfPreviousWork"
        ,"Originality"
        ,"OrganizationOfPaper"
        ,"ClarityOfMainMessage"
        ,"Mechanics"
        ,"SuitabilityForPresentation"
        ,"PotentialInterestInTopic"
        ,"OverallRating"
        ,"FileName"
        ,"WeightedScore"
        };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>");
#nullable restore
#line 25 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7de8748f3d1be20c662d92218803ad0a853b947f5677", async() => {
                WriteLiteral("<div class=\"button author-sign-up-button\">Score report</div>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7de8748f3d1be20c662d92218803ad0a853b947f7094", async() => {
                WriteLiteral("<div class=\"button reviewer-sign-up-button\">Author report</div>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7de8748f3d1be20c662d92218803ad0a853b947f8514", async() => {
                WriteLiteral("<div class=\"button author-sign-up-button\">Reviewer report</div>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7de8748f3d1be20c662d92218803ad0a853b947f9934", async() => {
                WriteLiteral("<div class=\"button reviewer-sign-up-button\">Comment report</div>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"table-container\">\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n");
#nullable restore
#line 35 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                  
                    foreach (var head in TableHeaders)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th>\r\n                                ");
#nullable restore
#line 39 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(head);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </th>\r\n");
#nullable restore
#line 41 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tr>\r\n        </thead>\r\n\r\n        <tbody>\r\n");
#nullable restore
#line 47 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
              
                if (Model != null)
                {
                    foreach (var Data in Model)
                    {
                        float avg_score_AppropriatnessOfTopic = @Data.total_score_AppropriatnessOfTopic / @Data.NumReviews;
                        float avg_score_TimelinessOfTopic = Data.total_score_TimelinessOfTopic / @Data.NumReviews;
                        float avg_score_SupportiveEvidence = Data.total_score_SupportiveEvidence / @Data.NumReviews;
                        float avg_score_TechnicalQuality = Data.total_score_TechnicalQuality / @Data.NumReviews;
                        float avg_score_ScopeOfCoverage = Data.total_score_ScopeOfCoverage / @Data.NumReviews;
                        float avg_score_CitationOfPreviousWork = Data.total_score_CitationOfPreviousWork / @Data.NumReviews;
                        float avg_score_Originality = Data.total_score_Originality / @Data.NumReviews;
                        float avg_score_OrganizationOfPaper = Data.total_score_OrganizationOfPaper / @Data.NumReviews;       
                        float avg_score_ClarityOfMainMessage = Data.total_score_ClarityOfMainMessage / @Data.NumReviews;
                        float avg_score_Mechanics = Data.total_score_Mechanics / @Data.NumReviews;
                        float avg_score_SuitabilityForPresentation = Data.total_score_SuitabilityForPresentation / @Data.NumReviews;                   
                        float avg_score_PotentialInterestInTopic = Data.total_score_PotentialInterestInTopic / @Data.NumReviews;
                        float avg_score_OverallRating = Data.total_score_OverallRating / @Data.NumReviews;

                        float sumTopics = avg_score_AppropriatnessOfTopic + 
                        avg_score_TimelinessOfTopic + 
                        avg_score_SupportiveEvidence + 
                        avg_score_TechnicalQuality + 
                        avg_score_ScopeOfCoverage + 
                        avg_score_CitationOfPreviousWork + 
                        avg_score_Originality + 
                        avg_score_OrganizationOfPaper + 
                        avg_score_ClarityOfMainMessage + 
                        avg_score_Mechanics + 
                        avg_score_SuitabilityForPresentation + 
                        avg_score_PotentialInterestInTopic;

                        float weighted_score = ( 0.5f * (sumTopics / 12)) + (avg_score_OverallRating *  0.5f);


                        string filename = @Data.Title + ".pdf";
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\r\n                            <td>");
#nullable restore
#line 84 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(Data.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 85 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_AppropriatnessOfTopic);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 86 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_TimelinessOfTopic);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 87 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_SupportiveEvidence);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 88 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_TechnicalQuality);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 89 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_ScopeOfCoverage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 90 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_CitationOfPreviousWork);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 91 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_Originality);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 92 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_OrganizationOfPaper);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>           \r\n                            <td>");
#nullable restore
#line 93 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_ClarityOfMainMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 94 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_Mechanics);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 95 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_SuitabilityForPresentation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>                      \r\n                            <td>");
#nullable restore
#line 96 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_PotentialInterestInTopic);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 97 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(avg_score_OverallRating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>                       \r\n                            <td>");
#nullable restore
#line 98 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(filename);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 99 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                           Write(weighted_score.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 101 "C:\Users\jayle\OneDrive\Documents\GitHub\CPMS\CPMS\Views\Admin\ScoreReport.cshtml"
                    }
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n\r\n                ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
