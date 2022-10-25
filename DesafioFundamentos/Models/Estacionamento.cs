using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            bool placaValida;
            string placa;
            do
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placa = Console.ReadLine().ToUpper();
                placaValida = ValidarPlaca(placa);
                if(!placaValida)
                {
                    Console.WriteLine("Placa inválida, tente novamente!");
                    Console.Clear();
                }
            } while (!placaValida);
            
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            bool placaValida;
            string placa;
            do
            {
                Console.WriteLine("Digite a placa do veículo para remover:");
                placa = Console.ReadLine().ToUpper();
                placaValida = ValidarPlaca(placa);
                if (!placaValida)
                {
                    Console.WriteLine("Placa inválida, tente novamente!");
                    Console.Clear();
                }
            } while (!placaValida);

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrEmpty(placa) || placa.Length > 8) return false;

            var placaValida = new Regex("[a-zA-Z]{3}-[0-9]{4}");

            return placaValida.IsMatch(placa);
        }
    }
}
