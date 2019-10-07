using System;
using System.Threading.Tasks;

namespace Gomes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();

            Console.WriteLine("Hello World!");
        }

        static async Task RunAsync()
        {
           
            Gomes.Calculate.Calcula gera = new Gomes.Calculate.Calcula();

            await  gera.Calcular();
           
        }
    }
}
