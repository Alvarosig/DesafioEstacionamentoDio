using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEstacionamento.Models
{
    public class Estacionamento
    {
        private List<string> Veiculo = new List<string>();
        private decimal precoInicial, precoHora;

        public void Iniciar()
        {

            ObterPreco();

            string? opcao;

            do
            {
                Console.WriteLine("\nDigite sua opção");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");


                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        CadastrarVeiculo();
                        break;
                    case "2":
                        RemoverVeiculo();
                        break;
                    case "3":
                        ListarVeiculos();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Opção Inválida, tente novamente");
                        break;
                }
            } while (opcao != "4");

        }

        public decimal ObterPreco()
        {
            Console.WriteLine("Digite o preço inicial");
            precoInicial = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Agora digite o preco por hora");
            precoHora = Convert.ToDecimal(Console.ReadLine());

            return precoInicial + precoHora;
        }

        public void CadastrarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (placa.Length > 7)
            {
                Console.WriteLine("A placa deve ter no máximo 7 dígitos");
            }
            else
            {
                Veiculo.Add(placa.ToUpper());
            }
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("\nOs veículos estacionados são:");
            foreach (var carro in Veiculo)
            {
                Console.WriteLine(carro);
            }
            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadKey();
        }

        public void RemoverVeiculo()
        {
            if (Veiculo.Count == 0)
            {
                Console.WriteLine("Nenhum veículo no estacionamento cadastrado");
            }
            else
            {
                Console.WriteLine("Digite a placa do veículo para remover:");
                string placa = Console.ReadLine().ToUpper();

                if (Veiculo.Contains(placa))
                {
                    Veiculo.Remove(placa);
                    CalcularHorario(placa);
                }
                else
                {
                    Console.WriteLine("Veículo não encontrado");
                }
            }
        }

        public void CalcularHorario(string placa)
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado");
            decimal horas = Convert.ToDecimal(Console.ReadLine());
            decimal total = precoInicial + (precoHora * horas);
            // precoInicial + precoHoras * horas
            Console.WriteLine($"O veículo {placa} foi removido e o preco total foi de: {total:C}");
            Console.ReadKey();
        }

    }
}