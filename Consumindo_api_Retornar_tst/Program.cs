namespace Consumindo_api_Retornar_tst
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string BaseUrl = "http://localhost:5215/";
            Console.WriteLine("Gerando Números do Sorteio");
            int op;
            do
            {
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Gerar Número");
                Console.WriteLine("0 - Sair");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 0:
                    break;
                case 1:

            }


            while (op !=0);

        }
    }
}