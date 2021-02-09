using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = "";

            do
            {
                opcaoUsuario = ObterOpcaoUsuario();

                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
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
                    case "c":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            while(opcaoUsuario.ToLower() != "q");

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadKey();
        }

        private static void Transferir()
        {
            Console.WriteLine("Transferir");
            
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia,
                listaContas[indiceContaDestino]);
            
            Console.WriteLine();
        }

        private static void Sacar()
        {
            int indiceConta = -1;
            double valorSaque = 0;
            
            Console.WriteLine("Sacar");
            
            Console.Write("Digite o número da conta: ");
            indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            valorSaque = double.Parse(Console.ReadLine());

            Console.WriteLine();

            listaContas[indiceConta].Sacar(valorSaque);
            
            Console.WriteLine();
        }

        private static void Depositar()
        {
            int indiceConta = -1;
            double valorDeposito = 0;
            
            Console.WriteLine("Depositar");
            
            Console.Write("Digite o número da conta: ");
            indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            valorDeposito = double.Parse(Console.ReadLine());

            Console.WriteLine();

            listaContas[indiceConta].Depositar(valorDeposito);
            
            Console.WriteLine();
        }

        private static void InserirContas()
        {
            int entradaTipoConta = 0;
            string entradaNome = "";
            double entradaSaldo = 0;
            double entradaCredito = 0;

            Console.WriteLine("Inserir nova conta");
            
            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            entradaNome = Console.ReadLine();
            
            Console.Write("Digite o saldo inicial: ");
            entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            entradaCredito = double.Parse(Console.ReadLine());

            Console.WriteLine();

            Conta novaConta = new Conta(tipoConta: (TipoConta) entradaTipoConta,
                saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.\n");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                
                Console.Write("Conta {0}:\n", i + 1);
                Console.WriteLine(conta);
                
                Console.WriteLine();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("DIO Bank ao seu dispor!");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Limpar tela");
            Console.WriteLine("Q- Sair");
            Console.Write("Informe a opção desejada: ");

            string opcaoUsuario = Console.ReadLine().ToLower();
            Console.WriteLine();
            
            return opcaoUsuario;
        }
    }
}
