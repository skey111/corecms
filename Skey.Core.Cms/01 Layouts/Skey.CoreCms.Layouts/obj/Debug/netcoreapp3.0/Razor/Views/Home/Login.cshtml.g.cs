#pragma checksum "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1f7d19f59442adbf1316ae6f50496245fae4ab0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Login), @"mvc.1.0.view", @"/Views/Home/Login.cshtml")]
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
#nullable restore
#line 5 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml"
using CoreCms.ViewModels.AccountModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1f7d19f59442adbf1316ae6f50496245fae4ab0", @"/Views/Home/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76a843986a7441d228f70f0f4ba123f6f97b3ad3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LoginModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "password", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Home/Login?post=1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml"
  
    Layout = "_LayoutLogin";
    ViewData["Title"] = "登录页";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script src=\"/assets/login/js/login.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f1f7d19f59442adbf1316ae6f50496245fae4ab04878", async() => {
                WriteLiteral("\r\n    <div class=\"wrap\">\r\n        <div class=\"wpn\">\r\n            <div class=\"form-data pos\">\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 343, "\"", 350, 0);
                EndWriteAttribute();
                WriteLiteral(@"><img src=""/assets/login/img/logo.png"" class=""head-logo""></a>
                <div class=""change-login"">
                    <p class=""account_number on"">账号登录</p>
                </div>
                <div class=""form1"">
                    <p class=""p-input pos"">
                        <label for=""num"">");
#nullable restore
#line 19 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml"
                                    Write(Html.DisplayNameFor(m => m.UserName));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n");
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f1f7d19f59442adbf1316ae6f50496245fae4ab06100", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 21 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserName);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <span class=\"tel-warn num-err hide\"><em>账号或密码错误，请重新输入</em><i class=\"icon-warn\"></i></span>\r\n                    </p>\r\n                    <p class=\"p-input pos\">\r\n                        <label for=\"pass\">");
#nullable restore
#line 25 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml"
                                     Write(Html.DisplayNameFor(m => m.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n");
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f1f7d19f59442adbf1316ae6f50496245fae4ab08210", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 28 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Password);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <span class=\"tel-warn pass-err hide\"><em>账号或密码错误，请重新输入</em><i class=\"icon-warn\"></i></span>\r\n                    </p>\r\n                    <p class=\"p-input pos code hide\">\r\n                        <label for=\"veri\">");
#nullable restore
#line 32 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml"
                                     Write(Html.DisplayNameFor(m => m.Code));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n");
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f1f7d19f59442adbf1316ae6f50496245fae4ab010543", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 34 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Code);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <img");
                BeginWriteAttribute("src", " src=\"", 1756, "\"", 1762, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <span class=""tel-warn img-err hide""><em>账号或密码错误，请重新输入</em><i class=""icon-warn""></i></span>
                        <!-- <a href=""javascript:;"">换一换</a> -->
                    </p>
                </div>
                <div class=""r-forget cl"">
                    <a href=""Reg"" class=""z"">账号注册</a>
                    <a href=""#"" class=""y"">忘记密码</a>
                </div>
                <button type=""submit"" class=""lang-btn   log-btn"">登录</button>
               
                <div class=""third-party"">
                    <a href=""#"" class=""log-qq icon-qq-round""></a>
                    <a href=""#"" class=""log-qq icon-weixin""></a>
                    <a href=""#"" class=""log-qq icon-sina1""></a>
                </div>
                <p class=""right"">Powered by © 2018</p>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    $(function () {\r\n        var res = ");
#nullable restore
#line 58 "C:\Company\skey\core\Cms\Skey.Core.Cms\01 Layouts\Skey.CoreCms.Layouts\Views\Home\Login.cshtml"
             Write(Html.Raw(ViewBag.Result));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n        if (res.Success) {\r\n            document.location.href = \"/Home/Index\";\r\n        } else {\r\n            var msg = res.Msg;\r\n            if (msg != \"\") {\r\n                alert(msg);\r\n            }\r\n        }\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoginModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
