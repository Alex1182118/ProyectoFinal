#pragma checksum "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\Tabla\ColumnasSelect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1e6381a820944e327712ae6a5a03b1be818b062"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tabla_ColumnasSelect), @"mvc.1.0.view", @"/Views/Tabla/ColumnasSelect.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tabla/ColumnasSelect.cshtml", typeof(AspNetCore.Views_Tabla_ColumnasSelect))]
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
#line 1 "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\_ViewImports.cshtml"
using ProyectoED1;

#line default
#line hidden
#line 2 "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\_ViewImports.cshtml"
using ProyectoED1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1e6381a820944e327712ae6a5a03b1be818b062", @"/Views/Tabla/ColumnasSelect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbe78bb0fb929845864c5a545fd120aafe813711", @"/Views/_ViewImports.cshtml")]
    public class Views_Tabla_ColumnasSelect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProyectoED1.Models.DefColumna>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Comando", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\Tabla\ColumnasSelect.cshtml"
  
    ViewData["Title"] = "Columnas";

#line default
#line hidden
            BeginContext(95, 44, true);
            WriteLiteral("<h2>Columnas Seleccionadas: </h2>\r\n<p>\r\n    ");
            EndContext();
            BeginContext(139, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02fd8ae5b94b44098ef10502c412eeb0", async() => {
                BeginContext(187, 17, true);
                WriteLiteral("Ingresar comandos");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(208, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(301, 49, false);
#line 13 "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\Tabla\ColumnasSelect.cshtml"
           Write(Html.DisplayNameFor(model => model.nombreColumna));

#line default
#line hidden
            EndContext();
            BeginContext(350, 63, true);
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 18 "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\Tabla\ColumnasSelect.cshtml"
         foreach (var item in Model) {

#line default
#line hidden
            BeginContext(453, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(502, 48, false);
#line 21 "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\Tabla\ColumnasSelect.cshtml"
           Write(Html.DisplayFor(modelItem => item.nombreColumna));

#line default
#line hidden
            EndContext();
            BeginContext(550, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(606, 46, false);
#line 24 "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\Tabla\ColumnasSelect.cshtml"
           Write(Html.DisplayFor(modelItem => item.tipoColumna));

#line default
#line hidden
            EndContext();
            BeginContext(652, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(708, 46, false);
#line 27 "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\Tabla\ColumnasSelect.cshtml"
           Write(Html.DisplayFor(modelItem => item.list_string));

#line default
#line hidden
            EndContext();
            BeginContext(754, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 30 "C:\Users\alexg\OneDrive\Escritorio\prueba-master 2 2 2\ProyectoED1\ProyectoED1\Views\Tabla\ColumnasSelect.cshtml"
}

#line default
#line hidden
            BeginContext(793, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProyectoED1.Models.DefColumna>> Html { get; private set; }
    }
}
#pragma warning restore 1591