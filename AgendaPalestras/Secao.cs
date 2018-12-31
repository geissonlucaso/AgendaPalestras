using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPalestras
{
    class Secao
    {
        // Atributos.
        // _hora atual inicializada com 9hs, que é o primeiro horário disponível em qualquer trilha.
        private static TimeSpan _horaAtual = new TimeSpan(9, 0, 0);

        // Properties.
        public string Turno { get; set; }
        public int Trilha { get; set; }
        public List<VagaPalestra> Palestras { get; set; }
        public TimeSpan[] HorariosDisponiveis { get; set; }


        // Construtores.
        public Secao(string turno, int trilha)
        {
            Turno = turno;
            Trilha = trilha;

            // Definição dos horários disponíveis em cada seção. Os valores foram definidos comforme a saída.
            if (Trilha == 1)
            {
                if (Turno == "Manha")
                    HorariosDisponiveis = new TimeSpan[]{
                        new TimeSpan(9,00,00),
                        new TimeSpan(10,00,00),
                        new TimeSpan(10,45,00),
                        new TimeSpan(11,15,00),
                        new TimeSpan(12,00,00)
                    };
                else
                    HorariosDisponiveis = new TimeSpan[] {
                        new TimeSpan(13,00,00),
                        new TimeSpan(14,00,00),
                        new TimeSpan(14,45,00),
                        new TimeSpan(15,30,00),
                        new TimeSpan(16,00,00),
                        new TimeSpan(16,30,00),
                        new TimeSpan(17,00,00)
                    };
            }
            else
            {
                if (Turno == "Manha")
                    HorariosDisponiveis = new TimeSpan[] {
                        new TimeSpan(09,00,00),
                        new TimeSpan(10,00,00),
                        new TimeSpan(11,00,00),
                        new TimeSpan(11,30,00),
                        new TimeSpan(12,00,00)
                    };
                else
                    HorariosDisponiveis = new TimeSpan[] {
                        new TimeSpan(13,00,00),
                        new TimeSpan(13,45,00),
                        new TimeSpan(14,30,00),
                        new TimeSpan(15,00,00),
                        new TimeSpan(16,00,00),
                        new TimeSpan(17,00,00)
                      };
            }

            // Inicializa a propriedade de listas de palestras.
            Palestras = new List<VagaPalestra>();
        }

        // Método para preenchimento da seção.
        public void PreencheSecao(List<VagaPalestra> lista30, List<VagaPalestra> lista45, List<VagaPalestra> lista60)
        {
            TimeSpan tempoFinal;
            TimeSpan tempoInicial;

            // Percorrendo os horários disponíveis
            for (int i = 0; i < HorariosDisponiveis.Length; i++)
            {
                // Condição para o índice não ultrapassar o valor limite
                if (i + 1 < HorariosDisponiveis.Length)
                {
                    // Calculo do tempo disponível na agenda.
                    tempoFinal = HorariosDisponiveis[i + 1];
                    tempoInicial = HorariosDisponiveis[i];
                    TimeSpan intervalo = tempoFinal - tempoInicial;

                    // Verifica se o intervalo calculado é de determinado valor.
                    // Adiciona um horário à palestra selecionada na lista correspondente.
                    // Remove o item da lista consultada.
                    if (intervalo == TimeSpan.FromMinutes(30))
                    {
                        Palestras.Add(new VagaPalestra(_horaAtual, lista30[0].Titulo, lista30[0].TempoDuracao));
                        lista30.RemoveAt(0);
                    }
                    else if (intervalo == TimeSpan.FromMinutes(45))
                    {
                        Palestras.Add(new VagaPalestra(_horaAtual, lista45[0].Titulo, lista45[0].TempoDuracao));
                        lista45.RemoveAt(0);
                    }
                    else
                    {
                        Palestras.Add(new VagaPalestra(_horaAtual, lista60[0].Titulo, lista60[0].TempoDuracao));
                        lista60.RemoveAt(0);
                    }

                    // Atualiza a hora atual da seção. 
                    _horaAtual += intervalo;
                }

                if (HorariosDisponiveis[i] == TimeSpan.FromHours(12))
                {
                    // Adiciona na agenda o almoço
                    Palestras.Add(new VagaPalestra(_horaAtual, "Almoço"));

                    // Adiciona 1hr. Tempo previsto pela saída.
                    _horaAtual += TimeSpan.FromMinutes(60);
                }
                else if (HorariosDisponiveis[i] == TimeSpan.FromHours(17))
                {
                    Palestras.Add(new VagaPalestra(_horaAtual, "Evento de Networking"));

                    // Define o valor 9hr para uso posterior.
                    _horaAtual = TimeSpan.FromHours(9);
                }
            }
        }
    }
}
