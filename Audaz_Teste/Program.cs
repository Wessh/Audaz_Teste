using Audaz_Teste.Controllers;
using Audaz_Teste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audaz_Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            var fareController = new FareController();
            while (true)
            {
                Console.Clear();
                try
                {
                    var fare = new Fare();
                    fare.Id = Guid.NewGuid();

                    Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                    Console.Write("Valor: ");
                    var fareValueInput = Console.ReadLine();
                    fare.Value = decimal.Parse(fareValueInput);

                    Console.WriteLine("\nInforme o código da operadora para a tarifa:");
                    Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                    Console.Write("Operadora: ");
                    var operatorCodeInput = Console.ReadLine();

                    fareController.CreateFare(fare, operatorCodeInput);

                    Console.WriteLine("\nTarifa cadastrada com sucesso!");

                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{e.Message}");
                }

                Console.WriteLine("\nTecle [ENTER] para continuar...\nTecle [ESC] para encerrar...");
                var keyboard = Console.ReadKey();
                if (keyboard.Key == ConsoleKey.Escape) break;
            }
        }
    }
}
