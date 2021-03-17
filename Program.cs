using System;
using System.Collections.Generic;


namespace Dio.Bank
{
    class Program
    {
        
        static List<Conta> listContas = new List<Conta>(); //List<t> para movimentação aquivos armazenados 
        static void Main(string[] args)
        {
        
       string opcaoUsuario =ObterOpcaoUsuario(); // obter opção escolhida pelo usuario
       
        // processamento opção escolhida
        while (opcaoUsuario.ToUpper() != "X"){
            switch (opcaoUsuario){
                case "1":
                    ListarContas();
                    break;
                    
                case "2":
                    InserirConta();
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
           Console.WriteLine("Obrigado por ultilizar o serviço");
           Console.WriteLine();
     
        }


        private static void ListarContas() // listar conta acessando classe conta
        {
           Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
                }
        }

        private static void InserirConta() // Inserir conta acessando classe conta
        {
            Console.WriteLine("Inserir nova conta");

			Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito: ");
			double entradaCredito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: 
                                (TipoConta)entradaTipoConta,
								saldo: entradaSaldo,
								credito: entradaCredito,
								nome: entradaNome);

			listContas.Add(novaConta);
        }

        private static void Transferir() // tranferir valores conta acessando classe conta
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].transferir(valorTransferencia, listContas[indiceContaDestino]);
		}
        private static void Sacar() // Sacar valores conta acessando classe conta
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
		}

        private static void Depositar() // Depositar valores conta acessando classe conta
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
		}


        private static string ObterOpcaoUsuario() // Menu usuario acesso principal conta
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank!!!");
            Console.WriteLine("Informe a opção desejada: ");
            
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova Conta");
            Console.WriteLine("3- Tansferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela ");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
             Console.WriteLine();
             return opcaoUsuario;
        }
       
    }

}
