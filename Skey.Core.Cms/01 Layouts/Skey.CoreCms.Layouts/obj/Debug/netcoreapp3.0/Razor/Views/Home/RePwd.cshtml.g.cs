#pragma checksum "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\RePwd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "415a065c9a74aaccb9462c633f7a04b9cad50c6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_RePwd), @"mvc.1.0.view", @"/Views/Home/RePwd.cshtml")]
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
#line 1 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\_ViewImports.cshtml"
using Skey.CoreCms.Layouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\_ViewImports.cshtml"
using Skey.CoreCms.Layouts.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"415a065c9a74aaccb9462c633f7a04b9cad50c6d", @"/Views/Home/RePwd.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76a843986a7441d228f70f0f4ba123f6f97b3ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_RePwd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\RePwd.cshtml"
  
    Layout = "_LayoutLogin";
    ViewData["Title"] = "找回密码";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""wrap"">
    <div class=""wpn"">
        <div class=""form-data find_password"">
            <h4>找回密码</h4>
            <p class=""right_now"">已有账号，<a href=""./login.html"">马上登录</a></p>
            <p class=""p-input pos"">
                <label for=""pc_tel"">手机号/邮箱</label>
                <input type=""text"" id=""pc_tel"">
                <span class=""tel-warn pc_tel-err hide""><em>最多五个字</em><i class=""icon-warn""></i></span>
            </p>
            <p class=""p-input pos pc-very"">
                <label for=""veri-code"">输入验证码</label>
                <input type=""number"" id=""veri-code"">
                <a href=""javascript:;"" class=""send"">发送验证码</a>
                <span class=""time hide""><em>120</em>s</span>
                <span class=""tel-warn error hide""><em>验证码错误，请重新输入</em><i class=""icon-warn""></i></span>
            </p>
            <p class=""p-input pos code pc-code"">
                <label for=""veri"">请输入验证码</label>
                <input type=""text"" id=""veri"">
                <img");
            BeginWriteAttribute("src", " src=\"", 1088, "\"", 1094, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                <span class=""tel-warn img-err hide""><em>最多五个字</em><i class=""icon-warn""></i></span>
                <!-- <a href=""javascript:;"">换一换</a> -->
            </p>
            <button class=""lang-btn next"">下一步</button>
            <p class=""right"">Powered by © 2018</p>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
