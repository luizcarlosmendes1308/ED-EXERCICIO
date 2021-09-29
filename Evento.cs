using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEventos
{
    class Evento
    {
        private int id;
        private string descricao;
        private int qtdeMaxParticipantes;
        private Participante[] participantes;

        public Evento(int id, string descricao, int qtdeMaxParticipantes)
        {
            this.id = id;
            this.descricao = descricao;
            this.qtdeMaxParticipantes = qtdeMaxParticipantes;
            this.participantes = new Participante[this.qtdeMaxParticipantes];
            for(int i = 0; i < this.qtdeMaxParticipantes; i++)
            {
                this.participantes[i] = new Participante();
            }
        }

        public Evento() : this(-1,"...",1)
        { }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }

        public int QtdeMaxParticipantes
        {
            get => qtdeMaxParticipantes;

        }

        public Participante[] Participantes
        {
            get => participantes;
        }

        public void inscreverParticipante(Participante p)
        {
            for(int i = 0; i < participantes.Length; i++)
            {
                if(participantes[i].Email.Equals("..."))
                {
                    participantes[i] = p;
                    break;
                }
            }
        }

        public int qtdeParticipantes()
        {
            int qtd = 0;
            foreach(Participante participante in participantes)
            {
                if(!participante.Email.Equals("..."))
                {
                    qtd++;
                }
            }
            return qtd;
        }

        public string listaParticipantes()
        {
            string participantesString = "";
            foreach(Participante participante in participantes)
            {
                if(!participante.Email.Equals("..."))
                {
                    participantesString += $"\n Nome: {participante.Nome}, Email: {participante.Email}";
                }
            }
            return participantesString;
        }

        public override bool Equals(object obj) 
        {
            return obj is Evento evento &&
                   id.Equals(evento.id);
        }

        public override String ToString() 
        {
            return $"Id: {id}, Descrição: {descricao}, Quantidade máxima: {qtdeMaxParticipantes}, Participantes: [{listaParticipantes()}]\n";
        }

    }
}
