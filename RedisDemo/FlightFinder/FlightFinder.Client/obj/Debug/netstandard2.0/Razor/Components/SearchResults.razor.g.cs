#pragma checksum "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4ba585b7e6f3fc281b25076bc2df3e5ddcb691c"
// <auto-generated/>
#pragma warning disable 1591
namespace FlightFinder.Client.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 3 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 4 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\_Imports.razor"
using FlightFinder.Client.Services;

#line default
#line hidden
#line 6 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\_Imports.razor"
using FlightFinder.Client.Components;

#line default
#line hidden
#line 7 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\_Imports.razor"
using FlightFinder.Shared;

#line default
#line hidden
    public partial class SearchResults : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "px-4");
#line 2 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
     if (Itineraries != null)
    {

#line default
#line hidden
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "title");
            __builder.OpenElement(4, "h2");
            __builder.AddAttribute(5, "class", "my-3");
            __builder.AddContent(6, 
#line 5 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
                              Itineraries.Count

#line default
#line hidden
            );
            __builder.AddContent(7, " results");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\n            ");
            __builder.OpenElement(9, "select");
            __builder.AddAttribute(10, "class", "custom-select");
            __builder.AddAttribute(11, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#line 6 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
                                                 chosenSortOrder

#line default
#line hidden
            ));
            __builder.AddAttribute(12, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => chosenSortOrder = __value, chosenSortOrder));
            __builder.SetUpdatesAttributeName("value");
            __builder.OpenElement(13, "option");
            __builder.AddAttribute(14, "value", 
#line 7 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
                                SortOrder.Price

#line default
#line hidden
            );
            __builder.AddContent(15, "Cheapest");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\n                ");
            __builder.OpenElement(17, "option");
            __builder.AddAttribute(18, "value", 
#line 8 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
                                SortOrder.Duration

#line default
#line hidden
            );
            __builder.AddContent(19, "Quickest");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#line 12 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
         foreach (var item in sortedItineraries)
        {

#line default
#line hidden
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "mb-4 d-flex align-items-center");
            __builder.OpenElement(22, "ul");
            __builder.AddAttribute(23, "class", "list-group");
            __builder.OpenElement(24, "li");
            __builder.AddAttribute(25, "class", "list-group-item d-flex align-items-center");
            __builder.OpenComponent<FlightFinder.Client.Components.SearchResultFlightSegment>(26);
            __builder.AddAttribute(27, "Symbol", "▶");
            __builder.AddAttribute(28, "Flight", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<FlightFinder.Shared.FlightSegment>(
#line 17 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
                                                                      item.Outbound

#line default
#line hidden
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\n                    ");
            __builder.OpenElement(30, "li");
            __builder.AddAttribute(31, "class", "list-group-item d-flex align-items-center");
            __builder.OpenComponent<FlightFinder.Client.Components.SearchResultFlightSegment>(32);
            __builder.AddAttribute(33, "Symbol", "◀");
            __builder.AddAttribute(34, "Flight", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<FlightFinder.Shared.FlightSegment>(
#line 20 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
                                                                      item.Return

#line default
#line hidden
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\n                ");
            __builder.OpenElement(36, "div");
            __builder.AddAttribute(37, "class", "price ml-3");
            __builder.OpenElement(38, "h3");
            __builder.AddContent(39, 
#line 24 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
                         item.Price.ToString("$0")

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\n                    ");
            __builder.OpenElement(41, "button");
            __builder.AddAttribute(42, "class", "btn");
            __builder.AddAttribute(43, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#line 25 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
                                                    () => OnAddItinerary.InvokeAsync(item)

#line default
#line hidden
            ));
            __builder.AddContent(44, "Add");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#line 28 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
        }

#line default
#line hidden
#line 28 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
         
    }

#line default
#line hidden
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 33 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResults.razor"
 
    // Parameters
    [Parameter]
    public IReadOnlyList<Itinerary> Itineraries { get; set; }

    [Parameter]
    public EventCallback<Itinerary> OnAddItinerary { get; set; }

    // Private state
    private SortOrder chosenSortOrder;
    private IEnumerable<Itinerary> sortedItineraries
        => chosenSortOrder == SortOrder.Price
        ? Itineraries.OrderBy(x => x.Price)
        : Itineraries.OrderBy(x => x.TotalDurationHours);

    private enum SortOrder { Price, Duration }

#line default
#line hidden
    }
}
#pragma warning restore 1591