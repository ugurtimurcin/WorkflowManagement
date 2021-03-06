#pragma checksum "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0bbff99c25731bfd0221af7b98b7f9a376a9dfa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_JobOrder_Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/JobOrder/Detail.cshtml")]
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
#line 3 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using WorkflowManagement.DTO.DTOs.UrgencyDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using WorkflowManagement.DTO.DTOs.NotificationDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using WorkflowManagement.DTO.DTOs.JobDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using WorkflowManagement.DTO.DTOs.AppUserDTOs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using WorkflowManagement.DTO.DTOs.AssignEmployeeDTOs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0bbff99c25731bfd0221af7b98b7f9a376a9dfa", @"/Areas/Admin/Views/JobOrder/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1516a9a67ff413f3407dcab2bef7d526dfd0c828", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_JobOrder_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JobListAllDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h4 class=\"display-4 text-center my-2\">Detay</h4>\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
 if (Model.Reports.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a class=\"btn btn-info\">Excel</a>\r\n    <table class=\"table table-hover table-sm\">\r\n        <tr>\r\n            <th colspan=\"2\">");
#nullable restore
#line 10 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
                       Write(Model.AppUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 10 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
                                                Write(Model.AppUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Personelinin ");
#nullable restore
#line 10 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
                                                                                     Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Görevine Yazmış Olduğu Raporlar</th>\r\n        </tr>\r\n        <tr>\r\n            <th>Tanım</th>\r\n            <th>Detay</th>\r\n        </tr>\r\n");
#nullable restore
#line 16 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
         foreach (var report in Model.Reports)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
               Write(report.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
               Write(report.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 22 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 24 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"border border-dark text-center\">\r\n        ");
#nullable restore
#line 28 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
   Write(Model.AppUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 28 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
                            Write(Model.AppUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" isimli personel ");
#nullable restore
#line 28 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
                                                                    Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" görevi ile ilgili henüz bir rapor yazmadı. \r\n    </div>\r\n");
#nullable restore
#line 30 "C:\Users\Oxir\Desktop\WorkflowManagement\WorkflowManagement.WebUI\Areas\Admin\Views\JobOrder\Detail.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JobListAllDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
