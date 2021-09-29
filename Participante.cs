using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjEventos
{
    class Participante{

        private string nome;
        private string email;
        

        public Participante(string email, string nome){
            this.email = email;
            this.nome = nome;
        }
        public Participante() : this("...","..."){ }
       
        public string Email{
            get => email;
            set => email=value;
        }

        public string Nome{
            get => nome;
            set => nome = value;
        }

        public bool podeInscrever(Evento[] e) {
           int qtdEventosParticipante = 0;

            foreach(Evento evento in e)
      {
                foreach (Participante participante in evento.Participantes)
                {
                    if (this.Equals(participante))
                    {
                        qtdEventosParticipante++;
                    }
                }
            }
            return qtdEventosParticipante < 2 ? true : false;
        }

        public override bool Equals(object obj) 
        {
            return obj is Participante participante &&
                   email.Equals(participante.email);
        }

        public override String ToString() 
        {
            return $"Nome: {nome}, Email: {email}\n";
        }
    }
}
