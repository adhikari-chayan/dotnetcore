#pragma checksum "C:\MyStuff\Practice Projects\dotnetcore\DISample\TennisBookingsComplete\src\TennisBookings.Web\Areas\Admin\Views\Courts\CancelBooking.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d65b86920dee6ab421729d513162499e663444ea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TennisBookings.Web.Areas.Admin.Views.Courts.Areas_Admin_Views_Courts_CancelBooking), @"mvc.1.0.view", @"/Areas/Admin/Views/Courts/CancelBooking.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Courts/CancelBooking.cshtml", typeof(TennisBookings.Web.Areas.Admin.Views.Courts.Areas_Admin_Views_Courts_CancelBooking))]
namespace TennisBookings.Web.Areas.Admin.Views.Courts
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d65b86920dee6ab421729d513162499e663444ea", @"/Areas/Admin/Views/Courts/CancelBooking.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37e0016e8b767a9347cbf147cbfe9aa5d7846eff", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Courts_CancelBooking : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TennisBookings.Web.Areas.Admin.ViewModels.CancelBookingConfirmationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\MyStuff\Practice Projects\dotnetcore\DISample\TennisBookingsComplete\src\TennisBookings.Web\Areas\Admin\Views\Courts\CancelBooking.cshtml"
  
    ViewData["Title"] = "Confirm Booking Cancellation";

#line default
#line hidden
            BeginContext(149, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(156, 17, false);
#line 6 "C:\MyStuff\Practice Projects\dotnetcore\DISample\TennisBookingsComplete\src\TennisBookings.Web\Areas\Admin\Views\Courts\CancelBooking.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(173, 212, true);
            WriteLiteral("</h1>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h2>Are you sure you wish to delete the following booking?</h2>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h3>");
            EndContext();
            BeginContext(386, 24, false);
#line 16 "C:\MyStuff\Practice Projects\dotnetcore\DISample\TennisBookingsComplete\src\TennisBookings.Web\Areas\Admin\Views\Courts\CancelBooking.cshtml"
       Write(Model.Date.ToString("D"));

#line default
#line hidden
            EndContext();
            BeginContext(410, 26, true);
            WriteLiteral("</h3>\r\n        <p><strong>");
            EndContext();
            BeginContext(437, 15, false);
#line 17 "C:\MyStuff\Practice Projects\dotnetcore\DISample\TennisBookingsComplete\src\TennisBookings.Web\Areas\Admin\Views\Courts\CancelBooking.cshtml"
              Write(Model.CourtName);

#line default
#line hidden
            EndContext();
            BeginContext(452, 11, true);
            WriteLiteral("</strong>: ");
            EndContext();
            BeginContext(464, 15, false);
#line 17 "C:\MyStuff\Practice Projects\dotnetcore\DISample\TennisBookingsComplete\src\TennisBookings.Web\Areas\Admin\Views\Courts\CancelBooking.cshtml"
                                         Write(Model.StartTime);

#line default
#line hidden
            EndContext();
            BeginContext(479, 4, true);
            WriteLiteral(" to ");
            EndContext();
            BeginContext(484, 13, false);
#line 17 "C:\MyStuff\Practice Projects\dotnetcore\DISample\TennisBookingsComplete\src\TennisBookings.Web\Areas\Admin\Views\Courts\CancelBooking.cshtml"
                                                             Write(Model.EndTime);

#line default
#line hidden
            EndContext();
            BeginContext(497, 84, true);
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            EndContext();
            BeginContext(581, 454, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d65b86920dee6ab421729d513162499e663444ea6782", async() => {
                BeginContext(601, 121, true);
                WriteLiteral("\r\n            <div class=\"row\">\r\n                <div class=\"col-md-2\">\r\n                    <br />\r\n                    ");
                EndContext();
                BeginContext(722, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d65b86920dee6ab421729d513162499e663444ea7294", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 27 "C:\MyStuff\Practice Projects\dotnetcore\DISample\TennisBookingsComplete\src\TennisBookings.Web\Areas\Admin\Views\Courts\CancelBooking.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BookingId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(765, 263, true);
                WriteLiteral(@"
                    <input type=""submit"" name=""submitButton"" value=""Confirm"" class=""btn btn-success"" />
                    <input type=""submit"" name=""submitButton"" value=""Cancel"" class=""btn btn-warning"" />
                </div>
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1035, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TennisBookings.Web.Areas.Admin.ViewModels.CancelBookingConfirmationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
