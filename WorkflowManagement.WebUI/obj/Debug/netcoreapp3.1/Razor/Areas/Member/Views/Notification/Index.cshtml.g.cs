#pragma checksum "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\Notification\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5720aeb667052d6bd1ec7186877e324b3d66d43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Notification_Index), @"mvc.1.0.view", @"/Areas/Member/Views/Notification/Index.cshtml")]
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
#line 2 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\_ViewImports.cshtml"
using WorkflowManagement.DTO.DTOs.NotificationDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\_ViewImports.cshtml"
using WorkflowManagement.DTO.DTOs.JobDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\_ViewImports.cshtml"
using WorkflowManagement.DTO.DTOs.ReportDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\_ViewImports.cshtml"
using WorkflowManagement.DTO.DTOs.AppUserDTOs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5720aeb667052d6bd1ec7186877e324b3d66d43", @"/Areas/Member/Views/Notification/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"144eb19084de877bf3066143238208e75aa69715", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Notification_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<NotificationListDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<h4 class=\"display-4 text-center\">Bildirimler</h4>\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\Notification\Index.cshtml"
 if (Model.Count > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\Notification\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success m-2 w-50 mx-auto\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5720aeb667052d6bd1ec7186877e324b3d66d435483", async() => {
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 325, "\"", 341, 1);
#nullable restore
#line 11 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\Notification\Index.cshtml"
WriteAttributeValue("", 333, item.Id, 333, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <p class=\"lead\">\r\n                    ");
#nullable restore
#line 13 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\Notification\Index.cshtml"
               Write(item.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    <button type=\"submit\" class=\"btn btn-info btn-sm float-right\">Okundu</button>\r\n                </p>\r\n            ");
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 18 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\Notification\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\Notification\Index.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-warning text-center m-2\">\r\n        Okunmamış bildiriminiz bulunmamaktadır.\r\n    </div>\r\n");
#nullable restore
#line 25 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Member\Views\Notification\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<NotificationListDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
