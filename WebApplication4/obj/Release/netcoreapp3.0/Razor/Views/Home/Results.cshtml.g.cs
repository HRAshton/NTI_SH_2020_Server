#pragma checksum "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a264bd1e744d971b390306a33ad664ef88a64f19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Results), @"mvc.1.0.view", @"/Views/Home/Results.cshtml")]
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
#line 1 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
using WebApplication4.Models.ResponseModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
using WebApplication4.Models.StorageModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a264bd1e744d971b390306a33ad664ef88a64f19", @"/Views/Home/Results.cshtml")]
    public class Views_Home_Results : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication4.Models.ResultsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 5 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
  
    ViewData["Title"] = "View";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<meta http-equiv=""refresh"" content=""0.5"" />
<style>
    html {
        background: linear-gradient(45deg, #EECFBA, #C5DDE8);
    }

    h1 {
        text-align: center;
    }

    body {
        margin: 0;
    }

    table {
        font-family: ""Lucida Sans Unicode"", ""Lucida Grande"", Sans-Serif;
        font-size: 14px;
        border-collapse: collapse;
        text-align: center;
    }
    th, td:first-child {
        background: #AFCDE7;
        padding: 10px 20px;
        font-weight: bold;
    }
    th, td {
        border-style: solid;
        border-width: 0 1px 1px 0;
        border-color: white;
    }
    td {
        background: #D8E6F3;
    }
    th:first-child, td:first-child {
        text-align: left;
    }
</style>

<h1>Запросы</h1>
<table>
    <thead>
        <tr>
            <th>Команда</th>
            <th>Температура</th>
            <th>Влажность</th>
            <th>Последний вызов охраны</th>
            <th>Последний запрос</th>
            <th>Состояние</th>
        </tr>
   ");
            WriteLiteral(" </thead>\n    <tbody>\n");
#nullable restore
#line 59 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
     foreach (var t in Model.Houses.OrderBy(x => x.Name))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 62 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
           Write(t.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 63 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
            Write(t.Temperature?.ToString() ?? "Нет данных");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 64 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
            Write(t.Humidity?.ToString() ?? "Нет данных");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 65 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
           Write(LGC(t));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 66 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
            Write(t.LastRequestTime?.ToLongTimeString() ?? "Нет данных");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 67 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
            Write(t.StatusString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\n");
#nullable restore
#line 69 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 73 "D:\NTI_Server-master\WebApplication4\Views\Home\Results.cshtml"
           

    string LGC(HouseTeamModel houseTeamModel)
    {
        if (houseTeamModel.LastGuardCall == null)
        {
            return "Нет данных";
        }

        if (DateTime.Now - houseTeamModel.LastGuardCall > TimeSpan.FromMinutes(1))
        {
            return "> 60 сек. назад";
        }

        return ((int) (DateTime.Now - houseTeamModel.LastGuardCall).Value.TotalSeconds).ToString() + " сек. назад";
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication4.Models.ResultsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
