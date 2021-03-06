#pragma checksum "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Roles\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a13981f50d6d427ac5c17a95903b92ceb7ea8481"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Roles_Edit), @"mvc.1.0.view", @"/Views/Roles/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a13981f50d6d427ac5c17a95903b92ceb7ea8481", @"/Views/Roles/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51db83534902e0d9ab2715f56e021dc8f72320a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Roles_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleBasedAuthorization.Models.Roles>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "/Roles/Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Roles\Edit.cshtml"
  
    ViewData["Title"] = "Edit Role & Permissions";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!-- Content Header (Page header) -->\n<section class=\"content-header\">\n    <h1>\n        ");
#nullable restore
#line 11 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Roles\Edit.cshtml"
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
        <!-- left column -->
        <div class=""col-md-12"">
            <!-- general form elements -->
            <div class=""box box-primary"">
                <div class=""box-header with-border"">
                    <h3 class=""box-title"">Edit Admin Info</h3>
                </div>
                <!-- /.box-header -->
                <!-- form start -->
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a13981f50d6d427ac5c17a95903b92ceb7ea84814967", async() => {
                WriteLiteral(@"
                    <div class=""box-body"">
                        <div class=""form-group"">
                            <label for=""exampleInputEmail1"">Title</label>
                            <input type=""text"" class=""form-control"" id=""Title"" name=""Title""");
                BeginWriteAttribute("value", " value=\"", 1039, "\"", 1059, 1);
#nullable restore
#line 30 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Roles\Edit.cshtml"
WriteAttributeValue("", 1047, Model.Title, 1047, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Enter Title"">
                        </div>
                        <div class=""form-group"">
                            <label for=""exampleInputPassword1"">Description</label>
                            <input type=""text"" class=""form-control"" id=""Description"" name=""Description""");
                BeginWriteAttribute("value", " value=\"", 1354, "\"", 1380, 1);
#nullable restore
#line 34 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Roles\Edit.cshtml"
WriteAttributeValue("", 1362, Model.Description, 1362, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Enter Description"">
                        </div>
                    </div>
                    <!-- /.box-body -->
                    <div class=""box-footer"">
                        <button type=""submit"" class=""btn btn-primary"">Submit</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <!-- /.box -->
        </div>
    </div>

    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""white-box"">
                <h3 class=""box-title m-b-30"">Assign Roles</h3>
                <div class=""row"">
                    <div class=""col-lg-12 col-sm-12"">

                        <div style=""margin-left:28px; margin-top:20px;"">
                            <button type=""button"" class=""btn"">Collepsed</button>
                            <button type=""button"" class=""btn"">Expanded</button>
                            <button type=""button"" class=""btn"">Checked All</button>
                            <button type=""button"" class=""btn"">Unchek All</button>
                        </div>

                        <ul class=""mytree"">
                            ");
#nullable restore
#line 62 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Roles\Edit.cshtml"
                       Write(Html.Raw(ViewBag.menu));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </ul>
                        <div style=""margin-left:28px"">
                            <button onclick=""Done()"" class=""btn btn-primary"">Update</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<script>

    $(document).on('click', '.mytree label', function (e) {
        $(this).next('ul').fadeToggle();
        e.stopPropagation();
    });

    $(document).on('change', '.mytree input[type=checkbox]', function (e) {
        $(this).siblings('ul').find(""input[type='checkbox']"").prop('checked', this.checked);
        $(this).parentsUntil('.mytree').children(""input[type='checkbox']"").prop('checked', this.checked);
        e.stopPropagation();
    });

    $(document).on('click', 'button', function (e) {
        switch ($(this).text()) {
            case 'Collepsed':
                $('.mytree ul').fadeOut();
                break;
            case 'Expanded':
                $('.mytree ul').f");
            WriteLiteral(@"adeIn();
                break;
            case 'Checked All':
                $("".mytree input[type='checkbox']"").prop('checked', true);
                break;
            case 'Unchek All':
                $("".mytree input[type='checkbox']"").prop('checked', false);
                break;
            default:
        }
    });


    function Done() {

        var checkedValues = $('input:checkbox:checked').map(function () {
            return this.id;
        }).get();

        $body = $(""body"");
        $(document).on({
            ajaxStart: function () { $body.addClass(""loading""); },
            ajaxStop: function () { }
        });

        $.ajax({
            type: ""POST"",
            url: '");
#nullable restore
#line 120 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Roles\Edit.cshtml"
             Write(Url.Action("Update", "Roles"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\n            data: {\n                id: ");
#nullable restore
#line 122 "G:\Project\RoleBasedAuthorizationCore5WithPermission\Views\Roles\Edit.cshtml"
               Write(Model.Roles_Master_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@",
                roles: checkedValues
            },
            error: function (result) {
                alert(""error"");
            },
            success: function (result) {
                $body.removeClass(""loading"");
                if (result.status == true) {

                    alert(""Successfully Updated Role!"")
                    var baseUrl = ""/Roles"";
                    window.location.href = baseUrl;
                }
                else {
                    alert(""Failed:""+result);
                }
            }
        });
    }

</script>


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleBasedAuthorization.Models.Roles> Html { get; private set; }
    }
}
#pragma warning restore 1591
