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
            ViewBag.Enunciado1 = "Analise o cenário a seguir: ";
            ViewBag.Enunciado2 = "Dado o resulado acima, qual será o resultado do SQL abaixo?";
            ViewBag.Enunciado3 = "SELECT COUNT(Codigo) as TotalFinal FROM Pedido WHERE CodigoComprador <> 123";
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

        [HttpPost]
        public JsonResult ResolveTarefa2()
        {
            string text1 = "Observando o primeiro SQL, sabemos que a Tabela Pedido tem 100 registros, portanto Total = 100";
            string text2 = "No segundo SQL, quando temos a condição CodigoComprador = 123, restringimos o conjunto de pedidos para Total123 = 15";
            string text3 = "Logo no terceiro SQL, seria o primeiro conjunto Total = 100 menos o segundo conjunto Total123 = 15";
            string resp = "O resultado o SQL será 100 - 15 = 85";
            return Json(new { text1, text2, text3, resp });
        }
    }
}