#pragma checksum "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b53c74105d6a38ef50234514a33f2a7b95b5240"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Menu_Index), @"mvc.1.0.view", @"/Views/Menu/Index.cshtml")]
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
#line 1 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\_ViewImports.cshtml"
using RoleBasedAuthorizationCore5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\_ViewImports.cshtml"
using RoleBasedAuthorizationCore5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b53c74105d6a38ef50234514a33f2a7b95b5240", @"/Views/Menu/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51db83534902e0d9ab2715f56e021dc8f72320a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Menu_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RoleBasedAuthorization.Models.Menus>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
   ViewData["Title"] = "Menus";
   Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!-- Content Header (Page header) -->\n<section class=\"content-header\">\n    <h1>\n        ");
#nullable restore
#line 9 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </h1>
</section>
<!-- Main content -->
<section class=""content container-fluid"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box"">
                <div class=""box-header"">
                    <h3 class=""box-title"">Menus Table</h3>
                </div>
                <!-- /.box-header -->
                <div class=""box-body"">
                    <table id=""menuTable"" class=""table table-bordered table-hover"">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Icon</th>
                                <th>Url</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 32 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td>\n                                    ");
#nullable restore
#line 36 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 39 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 42 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Icon));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 45 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Url));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1842, "\"", 1869, 2);
            WriteAttributeValue("", 1849, "/Roles/Edit/", 1849, 12, true);
#nullable restore
#line 48 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
WriteAttributeValue("", 1861, item.Id, 1861, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1920, "\"", 1949, 2);
            WriteAttributeValue("", 1927, "/Roles/Delete/", 1927, 14, true);
#nullable restore
#line 49 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
WriteAttributeValue("", 1941, item.Id, 1941, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\n                                </td>\n                            </tr>");
#nullable restore
#line 51 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Menu\Index.cshtml"
                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</section>

<script>$(function () {
    $('#menuTable').DataTable({
      'paging'      : true,
      'lengthChange': false,
      'searching'   : false,
      'ordering'    : true,
      'info'        : true,
      'autoWidth'   : false
    })
  })</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RoleBasedAuthorization.Models.Menus>> Html { get; private set; }
    }
}
#pragma warning restore 1591
