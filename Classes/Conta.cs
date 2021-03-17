
using System;

namespace Dio.Bank
{
    public class Conta
    {
        
        private string Nome{ get; set;} //Armazenar nomes

         private double Saldo{ get; set;} //Armazenar saldo

         private double Credito{ get; set;} //Armazenar valor cradito

        private TipoConta TipoConta {get; set;}//Armazenar tipo conta

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome )
         {
             this.TipoConta = tipoConta;
             this.Saldo = saldo;
             this.Credito = credito;
             this.Nome = nome;
         }
         public bool Sacar(double valorSaque) //Validação de saldo suficiente
         {
             
             if(this.Saldo - valorSaque <(this.Credito *-1)){
                 Console.WriteLine("Saldo insuficiente");
                
                 return false;
                  
             }
                this.Saldo = this.Saldo - valorSaque;

                 Console.WriteLine("Saldo atual da conta de {0} e {1}",this.Nome,this.Saldo);

                 return true;
         }
        
        public void Depositar(double valorDeposito) //Metodo Depositar
                { this.Saldo += valorDeposito;

                Console.WriteLine("Saldo atual da conta de {0} e {1}",this.Nome,this.Saldo);

            }
        public void transferir(double valorTransferencia, Conta contaDestino) //Metodo Depositar
        {
             if (this.Sacar(valorTransferencia)){
                    contaDestino.Depositar(valorTransferencia);

                }

            }

         public override string ToString() //Metodo de acesso a classe conta
        {
            string retorno = "";
            retorno += "Tipoconta " + this.TipoConta + " | "; 
            retorno += "Nome " + this.Nome + " | "; 
            retorno += "Saldo " + this.Saldo + " | "; 
            retorno += "Credito " + this.Credito+ " | "; 
            return retorno;
        }    

    }
}