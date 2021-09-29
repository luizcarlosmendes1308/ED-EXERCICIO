using System;

namespace ProjEventos{
    class Program{
        static void Main(string[] args){
            bool sair = false;
            int opcao;
            Eventos eventos = new Eventos();

            while(!sair) {
Console.WriteLine("\n0. sair \n1.adicionar evento \n2.pesquisar evento \n3.listar eventos \n4.adicionar participante \n5.pesquisar participante \n6.informar quantidade");
                    opcao = int.Parse(Console.ReadLine());                
                switch(opcao){
                    case 0:
                        sair = true;
                        break;
                    case 1:
                        addEvento(eventos);
                        break;
                    case 2:
                        pEvento(eventos);
                        break;
                    case 3:
                        listEvento(eventos);
                        break;
                    case 4:
                        addParticipante(eventos);
                        break;
                    case 5:
                        pesqParticipante(eventos);
                        break;
                    case 6:
                        infQuantidade(eventos);
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        break;
                }

                void addEvento(Eventos eventos)
                {
                    Console.WriteLine("Digite o dia do evento (1=SEG, 2=TER, ..., 6=SAB):");
                    int day = int.Parse(Console.ReadLine());

                    Console.WriteLine("Id do evento:");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Descrição do evento:");
                    string descricao = Console.ReadLine();

                    Console.WriteLine("Quantidade máxima de participantes:");
                    int qtdMax = int.Parse(Console.ReadLine());

                    eventos.adicionarEvento(new Evento(id, descricao, qtdMax), day);
                    Console.WriteLine("Evento adicionado.");
                }

                void pEvento(Eventos eventos)
                {
                    Console.WriteLine("Digite o id do evento que deseja procurar:");
                    int id = int.Parse(Console.ReadLine());

                    string dadosEvento = eventos.pesquisarEvento(id);
                    if (dadosEvento.Equals(""))
                    {
                        Console.WriteLine("Evento não encontrado.");
                    } else
                    {
                        Console.WriteLine(dadosEvento);
                    }
                }

                void listEvento(Eventos eventos)
                {
                    string dadosEventos = eventos.listaEventos();

                    if (dadosEventos.Equals(""))
                    {
                        Console.WriteLine("Sem eventos cadastrados");
                    } else
                    {
                        Console.WriteLine(dadosEventos);
                    }
                }

                void addParticipante(Eventos eventos)
                {
                    Console.WriteLine("Evento de qual dia? (1=SEG, 2=TER, ..., 6=SAB)");
                    int day = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o email do participante:");
                    string email = Console.ReadLine();

                    Console.WriteLine("Digite o nome do participante:");
                    string nome = Console.ReadLine();

                    switch(eventos.inscreverParticipante(day, new Participante(email, nome)))
                    {
                        case 0:
                            Console.WriteLine("Inscrição efetuada");
                            break;
                        case 1:
                            Console.WriteLine("Evento lotado");
                            break;
                        case 2:
                            Console.WriteLine("Excedido limite de inscrições para o participante");
                            break;
                    }
                }

                void pesqParticipante(Eventos eventos)
                {
                    Console.WriteLine("Digite o email do participante para realizar a pesquisa:");
                    string email = Console.ReadLine();

                    string dadosParticipante = eventos.pesquisarParticipante(new Participante(email, "..."));
                    if(dadosParticipante.Equals(""))
                    {
                        Console.WriteLine("Participante não cadastrado.");
                    }else
                    {
                        Console.WriteLine(dadosParticipante);
                    }
                }

                void infQuantidade(Eventos eventos)
                {
                    Console.WriteLine($"Total de participantes: {eventos.qtdeParticipantes()}");
                }
            }
        }
    }
}
