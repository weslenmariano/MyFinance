#pragma checksum "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "918ae70ed73b2dfb038b7ccf077c1fb16c44a60b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlanoConta_Index), @"mvc.1.0.view", @"/Views/PlanoConta/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PlanoConta/Index.cshtml", typeof(AspNetCore.Views_PlanoConta_Index))]
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
#line 1 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\_ViewImports.cshtml"
using MyFinance;

#line default
#line hidden
#line 2 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\_ViewImports.cshtml"
using MyFinance.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"918ae70ed73b2dfb038b7ccf077c1fb16c44a60b", @"/Views/PlanoConta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d05dd6abef5a8ff60f9a555c67ee727241a6c480", @"/Views/_ViewImports.cshtml")]
    public class Views_PlanoConta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(43, 269, true);
            WriteLiteral(@"
<h3>Plano de contas</h3>

<table class=""table table-bordered"">
    <thead>
        <tr>
            <th>#</th>
            <th>#</th>
            <th>ID</th>
            <th>Descricao</th>
            <th>Tipo</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 19 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
          
            foreach (var item in (List<PlanoContaModel>)ViewBag.ListaPlanoContas)
            {


#line default
#line hidden
            BeginContext(424, 75, true);
            WriteLiteral("        <tr>\r\n            <td><button type=\"button\" class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 499, "\"", 538, 3);
            WriteAttributeValue("", 509, "Editar(\'", 509, 8, true);
#line 24 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
WriteAttributeValue("", 517, item.Id.ToString(), 517, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 536, "\')", 536, 2, true);
            EndWriteAttribute();
            BeginContext(539, 83, true);
            WriteLiteral(">Editar</button></td>\r\n            <td><button type=\"button\" class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 622, "\"", 662, 3);
            WriteAttributeValue("", 632, "Excluir(\'", 632, 9, true);
#line 25 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
WriteAttributeValue("", 641, item.Id.ToString(), 641, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 660, "\')", 660, 2, true);
            EndWriteAttribute();
            BeginContext(663, 40, true);
            WriteLiteral(">Excluir</button></td>\r\n            <td>");
            EndContext();
            BeginContext(704, 18, false);
#line 26 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
           Write(item.Id.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(722, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(746, 25, false);
#line 27 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
           Write(item.Descricao.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(771, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(795, 68, false);
#line 28 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
           Write(item.Tipo.ToString().Replace("R", "Receita").Replace("D", "Despesa"));

#line default
#line hidden
            EndContext();
            BeginContext(863, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 30 "E:\CURSOS_UDEMY\ASPNET_CORE_MVC\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"

            }
        

#line default
#line hidden
            BeginContext(913, 513, true);
            WriteLiteral(@"    </tbody>
</table>

<button type=""button"" class=""btn btn-block btn-primary"" onclick=""CriarPlanoConta()"">Criar Plano de Conta</button>
<script>
    function CriarPlanoConta() {
        window.location.href = ""..\\PlanoConta\\CriarPlanoConta"";
    }

    function Excluir(id_Conta) {
        window.location.href = ""..\\PlanoConta\\ExcluirPlanoConta\\""+id_Conta;
    }

    function Editar(id_Conta) {
        window.location.href = ""..\\PlanoConta\\CriarPlanoConta\\"" + id_Conta;
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
