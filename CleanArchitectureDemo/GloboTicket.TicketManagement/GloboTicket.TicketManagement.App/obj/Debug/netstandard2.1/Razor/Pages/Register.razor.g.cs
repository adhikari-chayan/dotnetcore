#pragma checksum "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\Register.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f6272b18f56974ea64e5628b93599df5b7263b9"
// <auto-generated/>
#pragma warning disable 1591
namespace GloboTicket.TicketManagement.App.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using GloboTicket.TicketManagement.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using GloboTicket.TicketManagement.App.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using GloboTicket.TicketManagement.App.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/register")]
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "mt-5 row");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "card col-12 col-lg-6 mr-auto ml-auto p-3");
            __builder.AddMarkupContent(4, "<h3 class=\"card-title\">Register</h3>\r\n        ");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "card-body");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(7);
            __builder.AddAttribute(8, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 8 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\Register.razor"
                              RegisterViewModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 8 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\Register.razor"
                                                                HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(10, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "input-group col mt-2");
                __builder2.AddMarkupContent(13, "<label class=\"col-12 col-md-4 p-0\" for=\"firstName\">First name:</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(14);
                __builder2.AddAttribute(15, "id", "firstName");
                __builder2.AddAttribute(16, "class", "col-12 col-md-8 login-field");
                __builder2.AddAttribute(17, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\Register.razor"
                                                                                               RegisterViewModel.FirstName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(18, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterViewModel.FirstName = __value, RegisterViewModel.FirstName))));
                __builder2.AddAttribute(19, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterViewModel.FirstName));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(20, "\r\n                ");
                __builder2.OpenElement(21, "div");
                __builder2.AddAttribute(22, "class", "input-group col mt-2");
                __builder2.AddMarkupContent(23, "<label class=\"col-12 col-md-4 p-0\" for=\"lastName\">Last name:</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(24);
                __builder2.AddAttribute(25, "type", "lastName");
                __builder2.AddAttribute(26, "class", "col-12 col-md-8 login-field");
                __builder2.AddAttribute(27, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\Register.razor"
                                                                                                 RegisterViewModel.LastName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(28, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterViewModel.LastName = __value, RegisterViewModel.LastName))));
                __builder2.AddAttribute(29, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterViewModel.LastName));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n                ");
                __builder2.OpenElement(31, "div");
                __builder2.AddAttribute(32, "class", "input-group col mt-2");
                __builder2.AddMarkupContent(33, "<label class=\"col-12 col-md-4 p-0\" for=\"email\">Email:</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(34);
                __builder2.AddAttribute(35, "id", "email");
                __builder2.AddAttribute(36, "class", "col-12 col-md-8 login-field");
                __builder2.AddAttribute(37, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 19 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\Register.razor"
                                                                                           RegisterViewModel.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(38, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterViewModel.Email = __value, RegisterViewModel.Email))));
                __builder2.AddAttribute(39, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterViewModel.Email));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(40, "\r\n                ");
                __builder2.OpenElement(41, "div");
                __builder2.AddAttribute(42, "class", "input-group col mt-2");
                __builder2.AddMarkupContent(43, "<label class=\"col-12 col-md-4 p-0\" for=\"userName\">Username:</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(44);
                __builder2.AddAttribute(45, "id", "userName");
                __builder2.AddAttribute(46, "class", "col-12 col-md-8 login-field");
                __builder2.AddAttribute(47, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\Register.razor"
                                                                                              RegisterViewModel.UserName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(48, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterViewModel.UserName = __value, RegisterViewModel.UserName))));
                __builder2.AddAttribute(49, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterViewModel.UserName));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(50, "\r\n                ");
                __builder2.OpenElement(51, "div");
                __builder2.AddAttribute(52, "class", "input-group col mt-2");
                __builder2.AddMarkupContent(53, "<label class=\"col-12 col-md-4 p-0\" for=\"password\">Password:</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(54);
                __builder2.AddAttribute(55, "id", "password");
                __builder2.AddAttribute(56, "type", "password");
                __builder2.AddAttribute(57, "class", "col-12 col-md-8 login-field");
                __builder2.AddAttribute(58, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 27 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\Register.razor"
                                                                                                              RegisterViewModel.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(59, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterViewModel.Password = __value, RegisterViewModel.Password))));
                __builder2.AddAttribute(60, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterViewModel.Password));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(61, "\r\n                ");
                __builder2.AddMarkupContent(62, "<div class=\"input-group col mt-2\"><div class=\"offset-md-4\"><button class=\"m-2 p-2\">Register</button></div></div>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591