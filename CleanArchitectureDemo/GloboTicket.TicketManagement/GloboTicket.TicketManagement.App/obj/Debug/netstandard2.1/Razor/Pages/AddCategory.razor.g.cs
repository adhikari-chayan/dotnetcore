#pragma checksum "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\AddCategory.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c7ce85d37535275b3ffc6258cee7f3651e559ba"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/addcategory")]
    public partial class AddCategory : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3 class=\"mb-5\">New category</h3>\r\n\r\n");
            __builder.AddContent(1, 
#nullable restore
#line 5 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\AddCategory.razor"
 Message

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(2, "\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(3);
            __builder.AddAttribute(4, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 7 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\AddCategory.razor"
                  CategoryViewModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 7 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\AddCategory.razor"
                                                     HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(7);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(8, "\r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(9);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(10, "\r\n\r\n    ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "form-group row");
                __builder2.AddMarkupContent(13, "<label for=\"name\" class=\"col-sm-3\">Category name: </label>\r\n        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(14);
                __builder2.AddAttribute(15, "id", "name");
                __builder2.AddAttribute(16, "class", "form-control col-sm-5");
                __builder2.AddAttribute(17, "placeholder", "Enter category name");
                __builder2.AddAttribute(18, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\AddCategory.razor"
                                                                         CategoryViewModel.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => CategoryViewModel.Name = __value, CategoryViewModel.Name))));
                __builder2.AddAttribute(20, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => CategoryViewModel.Name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(21, "\r\n        ");
                __Blazor.GloboTicket.TicketManagement.App.Pages.AddCategory.TypeInference.CreateValidationMessage_0(__builder2, 22, 23, "offset-sm-3 col-sm-5", 24, 
#nullable restore
#line 15 "C:\MyStuff\Practice Projects\dotnetcore\CleanArchitectureDemo\GloboTicket.TicketManagement\GloboTicket.TicketManagement.App\Pages\AddCategory.razor"
                                                               () => CategoryViewModel.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(25, "\r\n\r\n    ");
                __builder2.AddMarkupContent(26, "<button type=\"submit\" class=\"submit-button mt-3\">Save category</button>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.GloboTicket.TicketManagement.App.Pages.AddCategory
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591