// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FlightFinder.Client
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
    public partial class Main : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 20 "C:\MyStuff\Practice Projects\dotnetcore\RedisDemo\FlightFinder\FlightFinder.Client\Main.razor"
 
    protected override void OnInitialized()
    {
        state.OnChange += StateHasChanged;        
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AppState state { get; set; }
    }
}
#pragma warning restore 1591
