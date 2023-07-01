namespace Retornar_tst.Services
{
    public class NumeroSorteioServices
    {
        public int GerarNumero()
        {
            Random random = new Random();
            return random.Next(0, 100000);

        }

        public void SalvarNumeroEmArquivo(int numero)
        {
            string caminhoArquivo = @"C:\Users\mhgir\OneDrive\Área de Trabalho\numeros.txt";

            using (StreamWriter writer = new StreamWriter(caminhoArquivo, true))
            {
                writer.WriteLine(numero);
            }
        }
    }
}
