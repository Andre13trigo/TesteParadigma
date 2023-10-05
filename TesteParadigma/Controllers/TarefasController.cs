using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TesteParadigma.Models;

namespace TesteParadigma.Controllers
{
    public class TarefasController : Controller
    {
        // GET: Tarefas
        public ActionResult Tarefa1()
        {
            ViewBag.Enunciado = "Utilizando o array [7, 5, 3, 9, 6, 4, 1], faça o código para percorrer a lista, localizar e substituir o valor 9 por 5,\r\n" +
                "remover o valor 4 da lista. Ao final você deve apresentar na tela a lista original, a nova lista e a soma dos valores da\r\nnova lista.";
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
            ViewBag.Enunciado = "Desenvolva um algoritmo que, dado um conjunto de números inteiros, retorne o índice da posição da soma de dois\r\n" +
                "números desse conjunto. Você pode assumir que cada conjunto de números tem apenas uma solução, e você não\r\n" +
                "pode usar o mesmo número duas vezes.";
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

        [HttpPost]
        public JsonResult ResolveTarefa3(string Model)
        {
            List<int> numeros = new List<int>();
            ModelTask3 obj = JsonConvert.DeserializeObject<ModelTask3>(Model);
            string[] numerosString = obj.array.Trim('[', ']').Split(',');
            foreach (string numeroString in numerosString)
            {
                if (int.TryParse(numeroString, out int numero))
                {
                    numeros.Add(numero);
                }
            }
            List<int> lista = SomadeDoisNum(numeros.ToArray(), obj.soma);
            string resp = "Os indices dos números que somam " + obj.soma+ " são (" + lista[0] + "," + lista[1] + ")";
            return Json(new { resp });
        }

        public static List<int> SomadeDoisNum(int[] num, int soma)
        {
            Dictionary<int, int> numDict = new Dictionary<int, int>();
            List<int> list = new List<int>();
            for (int i = 0; i < num.Length; i++)
            {
                int comp = soma - num[i];
                if (numDict.ContainsKey(comp))
                {
                    list.Add(numDict[comp]);
                    list.Add(i);
                }
                numDict[num[i]] = i;
            }
            return list;
        }
    }
}