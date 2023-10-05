using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteParadigma.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Informações sobre o André";
            ViewBag.Resumo = "Atuando no setor de Desenvolvimento de Software Web e Mobile desde Junho de 2020, no segmento de restaurantes e delivery (food service), " +
                "como desenvolvedor Full-Stack Pleno, auxiliando na automação e gestão deste setor, utilizando as tecnologias .NET C# e JavaScript.\r\n\r\n" +
                "Atuei como desenvolvedor .NET C# em SAP Business One, pela Voraz Consultoria durante 3 meses em 2022";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Nome = "André Luís Trigo Fernandes";
            ViewBag.Telefone = "(46) 999147928";
            ViewBag.Endereco = "Rua Doutor Francisco Beltrão 360";
            ViewBag.Bairro = "Santa Teresinha";
            ViewBag.Complemento = "Apto 218";
            ViewBag.Cidade = "Pato Branco";
            ViewBag.Email = "andrefernandes@alunos.utfpr.edu.br";
            ViewBag.Estado = "Paraná - PR";
            ViewBag.Git = "https://github.com/Andre13trigo/";



            return View();
        }
    }
}