#pragma checksum "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06997f74ad7b4550e0996cc066eba6f0063979ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TennisBookings.Web.Areas.Admin.Views.Staff.Areas_Admin_Views_Staff_AddStaffMember), @"mvc.1.0.view", @"/Areas/Admin/Views/Staff/AddStaffMember.cshtml")]
namespace TennisBookings.Web.Areas.Admin.Views.Staff
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml"
using Microsoft.AspNetCore.Mvc.Rendering;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06997f74ad7b4550e0996cc066eba6f0063979ac", @"/Areas/Admin/Views/Staff/AddStaffMember.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37e0016e8b767a9347cbf147cbfe9aa5d7846eff", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Staff_AddStaffMember : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Areas.Admin.ViewModels.AddStaffMemberViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-md-6"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml"
  
    ViewData["Title"] = "Add Staff Member";

#line default
#line hidden
            WriteLiteral("\r\n<h2>");
#line 8 "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            WriteLiteral("</h2>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06997f74ad7b4550e0996cc066eba6f0063979ac4137", async() => {
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                ");
#line 14 "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml"
           Write(Html.LabelFor(m => m.FirstName));

#line default
#line hidden
                WriteLiteral("\r\n                ");
#line 15 "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml"
           Write(Html.TextBoxFor(m => m.FirstName, new { @class = "form-control" }));

#line default
#line hidden
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
#line 18 "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml"
           Write(Html.LabelFor(m => m.LastName));

#line default
#line hidden
                WriteLiteral("\r\n                ");
#line 19 "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml"
           Write(Html.TextBoxFor(m => m.LastName, new { @class = "form-control" }));

#line default
#line hidden
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
#line 22 "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml"
           Write(Html.LabelFor(m => m.Role));

#line default
#line hidden
                WriteLiteral("\r\n                ");
#line 23 "C:\MyStuff\Practice Projects\dotnetcore\ConfigurationDemo\src\TennisBookings.Web\Areas\Admin\Views\Staff\AddStaffMember.cshtml"
           Write(Html.DropDownListFor(m => m.Role, StaffOptions.Roles.Select(r =>
                    new SelectListItem { Text = r, Value = r}), new { @class = "form-control" }));

#line default
#line hidden
                WriteLiteral("\r\n            </div>\r\n            <button type=\"submit\" class=\"btn btn-primary\">Add Staff Member</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Services.IStaffRolesOptionsService StaffOptions { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Areas.Admin.ViewModels.AddStaffMemberViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
