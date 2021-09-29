using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEventos{
    class Eventos    {
        private Evento[] osEventos;

        internal Evento[] OsEventos        {
            get => osEventos;
        }

        public Eventos()        {
            osEventos = new Evento[6];
            for(int i = 0; i < 6; i++)        {
                osEventos[i] = new Evento();
            }
        }

        public Eventos(Evento[] osEventos)
        {
            this.osEventos = osEventos;
        }

        public void adicionarEvento(Evento e, int day)
        {
            osEventos[day-1] = e;
        }

        public string pesquisarParticipante(Participante p)
        {
            string participanteNome = "";
            string participanteEventos = "";
            foreach(Evento evento in osEventos)
            {
                foreach (Participante participante in evento.Participantes)
                {
                    if(participante.Equals(p))
                    {
                        participanteEventos += $"Evento: {evento.Descricao}\n";
                        if(participanteNome.Equals(""))
                        {
                            participanteNome = $"Nome: {participante.Nome}\n";
                        }
                    }
                }
            }

            return participanteNome+participanteEventos;
        }

        public string pesquisarEvento(int id)
        {
            string eventoString = "";
            foreach(Evento evento in osEventos)
            {
                if (evento.Id.Equals(id))
                {
                    eventoString = evento.ToString();
                    break;
                }
            }
            return eventoString;
        }

        public int qtdeParticipantes()
        {
            int qtd = 0;
            foreach(Evento evento in osEventos)
            {
                qtd += evento.qtdeParticipantes();
            }
            return qtd;
        }

        public string listaEventos()
        {
            string eventosString = "";
            foreach(Evento evento in osEventos)
            {
                if (!evento.Id.Equals(-1))
                {
                    eventosString += $"Id: {evento.Id}, Descrição: {evento.Descricao}, Quantidade de participantes : {evento.qtdeParticipantes()}\n";
                }
            }
            return eventosString;
        }

        public int inscreverParticipante(int day, Participante p)
        {
            if(!p.podeInscrever(osEventos))
            {
                return 2;
            }

            if(osEventos[day-1].qtdeParticipantes() >= osEventos[day-1].QtdeMaxParticipantes)
            {
                return 1;
            }

            osEventos[day-1].inscreverParticipante(p);

            return 0;
        }
    }
}
