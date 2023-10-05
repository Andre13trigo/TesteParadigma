using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace TesteParadigma.Controllers
{
    public class TarefasController : Controller
    {
        // GET: Tarefas
        public ActionResult Tarefa1()
        {
            ViewBag.Enunciado = "Utilizando o array [7, 5, 3, 9, 6, 4, 1], faça o código para percorrer a lista, localizar e substituir o valor 9 por 5,\r\nremover o " +
                "valor 4 da lista. Ao final você deve apresentar na tela a lista original, a nova lista e a soma dos valores da\r\nnova lista.";
            return View();
        }

        public ActionResult Tarefa2()
        {
            return View();
        }

        public ActionResult Tarefa3()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ResolveTarefa1(string[] parametro)
        {
            int count = 0;
            List<string> aux = new List<string>();

            foreach (var item in parametro)
            {
                if (item == "9")
                {
                    aux.Add("5");
                }
                else if (item == "4")
                {
                    aux.Add("0");
                }
                else
                {
                    aux.Add(item);
                }
                count++;
            }
            aux = RemoverZeros(aux.ToArray());

            int numero;
            int soma = 0;
            foreach (var item in aux)
            {
                if (int.TryParse(item, out numero))
                {
                    soma += numero;
                }
            }
            return Json(new { parametro, aux, soma });
        }

        public static List<string> RemoverZeros(string[] vetor)
        {
            vetor = vetor.Where(num => num != "0").ToArray();
            return vetor.ToList();
        }
    }
}