#pragma checksum "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e368b384abcbfb414306bc5e4d5831ff2e10a671"
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
    public partial class SearchResultFlightSegment : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "symbol");
            __builder.AddContent(2, 
#line 2 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
     Symbol

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(3, "\n\n");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "airline");
            __builder.AddContent(6, 
#line 6 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
     Flight.Airline

#line default
#line hidden
            );
            __builder.AddMarkupContent(7, "\n    ");
            __builder.OpenElement(8, "small");
            __builder.AddContent(9, 
#line 7 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
            Flight.TicketClass.ToDisplayString()

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\n\n");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "departure");
            __builder.OpenElement(13, "h4");
            __builder.AddContent(14, 
#line 11 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
         Flight.DepartureTime.ToShortTimeString()

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\n    ");
            __builder.AddContent(16, 
#line 12 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
     Flight.DepartureTime.ToString("ddd MMM d")

#line default
#line hidden
            );
            __builder.AddContent(17, " (");
            __builder.AddContent(18, 
#line 12 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
                                                  Flight.FromAirportCode

#line default
#line hidden
            );
            __builder.AddMarkupContent(19, ")\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\n\n");
            __builder.AddMarkupContent(21, "<div class=\"arrow\">➝</div>\n\n");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "return");
            __builder.OpenElement(24, "h4");
            __builder.AddContent(25, 
#line 18 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
         Flight.ReturnTime.ToShortTimeString()

#line default
#line hidden
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\n    ");
            __builder.AddContent(27, 
#line 19 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
     Flight.ReturnTime.ToString("ddd MMM d")

#line default
#line hidden
            );
            __builder.AddContent(28, " (");
            __builder.AddContent(29, 
#line 19 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
                                               Flight.ToAirportCode

#line default
#line hidden
            );
            __builder.AddMarkupContent(30, ")\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\n\n");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "duration");
            __builder.AddContent(34, 
#line 23 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
     Flight.DurationHours

#line default
#line hidden
            );
            __builder.AddMarkupContent(35, " hours\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#line 27 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Components\SearchResultFlightSegment.razor"
 
    [Parameter]
    public string Symbol { get; set; }

    [Parameter]
    public FlightSegment Flight { get; set; }

#line default
#line hidden
    }
}
#pragma warning restore 1591
