#pragma checksum "C:\Users\hohuy\Downloads\DotNetProject\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "872be0099705d4502423ce372dd6c314f062c95c"
// <auto-generated/>
#pragma warning disable 1591
namespace helloworld.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using helloworld;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using helloworld.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using helloworld.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using helloworld.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\hohuy\Downloads\DotNetProject\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(EmptyLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div b-n9fwm3a14c><section class=\"section\" b-n9fwm3a14c><div class=\"main\" b-n9fwm3a14c><div class=\"intro-section\" b-n9fwm3a14c><h6 class=\"intro-heading\" b-n9fwm3a14c>Welcome to <span style=\"color:#46a049\" b-n9fwm3a14c>dotnet-algorithon</span></h6>\r\n                   <p class=\"intro-text\" b-n9fwm3a14c>We will help you to improve your programming skills and algorithmic thinking through selected exercises.</p>\r\n                   <img src=\"../Images/laptop_hkaxzz.png\" alt=\"Laptop\" b-n9fwm3a14c></div>\r\n   \r\n               <div class=\"sign-section\" b-n9fwm3a14c><div class=\"sign-block\" b-n9fwm3a14c><h3 class=\"sign-heading\" b-n9fwm3a14c>Sign in</h3>\r\n                       <form action=\"#\" class=\"signup-form\" autocomplete=\"off\" b-n9fwm3a14c><label for=\"email\" class=\"signup-label\" b-n9fwm3a14c>Email:</label>\r\n                           <input type=\"text\" id=\"email\" class=\"signup-input\" placeholder=\"Eg: johndoe@gmai.com\" b-n9fwm3a14c>\r\n                           <label for=\"password\" class=\"signup-label\" b-n9fwm3a14c>Password:</label>\r\n                           <input type=\"password\" id=\"password\" class=\"signup-input\" placeholder=\"********\" b-n9fwm3a14c>\r\n                           <button class=\"sign-button\" b-n9fwm3a14c>Sign in</button></form>\r\n                       <p class=\"signup-already\" b-n9fwm3a14c><span b-n9fwm3a14c>Do you have an account ?</span>\r\n                           <a href=\"SignUp.cshtml\" class=\"signup-login-link\" b-n9fwm3a14c>Sign up here!</a></p></div></div></div></section></div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthService authService { get; set; }
    }
}
#pragma warning restore 1591
