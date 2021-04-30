using System;
using System.Collections.Generic;

namespace Dio.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
          string opcaoUsuario = ObterOpcaoUsuario(); 

            while (opcaoUsuario.ToUpper() != "X")
            {   
                switch (opcaoUsuario)
                {
                    case "1":
                    ListarConta();
                    break;
                    case "2":
                    InseriConta();
                    break;
                    case "3":
                    Transferir();
                    break;
                    case "4":
                    Sacar();
                    break;
                    case "5":
                    Depositar();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
                }
             opcaoUsuario = ObterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por usar nossos serviços.");
            
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            while  (valorDeposito<=0)
            {
                Console.WriteLine("Valor inválido");
                Console.WriteLine("Escreva um valor válido");
                valorDeposito = double.Parse(Console.ReadLine());    
            }
            listContas[indiceConta].Depositar(valorDeposito);
            
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = int.Parse(Console.ReadLine());
            while  (valorSaque<=0)
            {
                Console.WriteLine("Valor inválido");
                Console.WriteLine("Escreva um valor válido");
                valorSaque = double.Parse(Console.ReadLine());    
            }
            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da Conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o numero da Conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            while  (valorTransferencia<=0)
            {
                Console.WriteLine("Valor inválido");
                Console.WriteLine("Valor inválido");
                Console.WriteLine("Escreva um valor válido");
                valorTransferencia = double.Parse(Console.ReadLine());    
            }
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

            
        }


        private static void InseriConta()
        {
            Console.WriteLine("Inserir novas Contas");
            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o nome do Cliente");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial");
            double entradaSaldo = double.Parse(Console.ReadLine());
            //Validando se o valor do Saldo digitado é menor ou igual a 0
            while  (entradaSaldo<=0)
            {
                Console.WriteLine("Valor inválido");
                Console.WriteLine("Escreva um valor válido");
                entradaSaldo = double.Parse(Console.ReadLine());    
            }
            Console.WriteLine("Digite o Credito");
            double entradaCredito = double.Parse(Console.ReadLine());
            //Validando se o valor do crédito digitado é menor ou igual a 0
            while  (entradaCredito<=0)
            {
                Console.WriteLine("Valor inválido");
                Console.WriteLine("Escreva um valor válido");
                entradaCredito = double.Parse(Console.ReadLine());    
            }    
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                    Saldo: entradaSaldo,
                                    Credito: entradaCredito,
                                    Nome: entradaNome);

            listContas.Add(novaConta);
        }
        private static void ListarConta()
        {
            Console.WriteLine("Listar Contas");
                if(listContas.Count ==0)
                {
                    Console.WriteLine("Não existe conta cadastrada");
                    return;
                }        
                for (int i=0; i<listContas.Count; i++)
                {
                    Conta conta = listContas[i];
                    Console.Write("#{0} - ", i);
                    Console.WriteLine(conta);

                }

        
        }
        private static string ObterOpcaoUsuario()
        {
                Console.WriteLine();
                Console.WriteLine("Dio Bank ao seu disport !!");
                Console.WriteLine("Informe a opção desejada");
                Console.WriteLine("1 - Listar Contas");
                Console.WriteLine("2 - Inserir Novas Contas");
                Console.WriteLine("3 - Transferir");
                Console.WriteLine("4 - Sacar");
                Console.WriteLine("5 - Depositar");
                Console.WriteLine("C - Limpar Tela");
                Console.WriteLine("X - Sair");

                string opcaoUsuario = Console.ReadLine().ToUpper();
                return opcaoUsuario;


        }
    }
}