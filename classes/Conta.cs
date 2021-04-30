using System;

namespace Dio
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private string Nome {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        
        
    
        public Conta(TipoConta tipoConta, string Nome, double Saldo, double Credito )
        {
            this.Nome=Nome;
            this.Saldo=Saldo;
            this.Credito=Credito;
            this.TipoConta=tipoConta;
            
        }
            public bool Sacar(double valorSaque)
            {
              //Validação de saldo insufiente 
              if (this.Saldo-valorSaque < (this.Credito*-1))
              {
                Console.WriteLine("Saldo insufiente para saque");
                return false;      
              }
              this.Saldo -=valorSaque;

              Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
              return true;
            } 
            public void Depositar(double deposito)
            {
                this.Saldo +=deposito;
                Console.WriteLine("Saldo atual da conta de {0}é {1}",this.Nome, this.Saldo);
            }
            public void Transferir(double valorTransferir, Conta contaDestino)
            {
                if(this.Sacar(valorTransferir))
                {
                    contaDestino.Depositar(valorTransferir);
                }        

            }
            public override string ToString()
            {
                string retorno ="";
                retorno += "TipoConta "+this.TipoConta + "| ";
                retorno += "Nome - " + this.Nome + "| ";
                retorno += "Saldo =R$" + this.Saldo+ "| ";
                retorno += "Credito = R$" + this.Credito + "| ";
                return retorno;
            }
         


        
    }   
}