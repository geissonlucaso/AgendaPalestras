using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPalestras
{
    class VagaPalestra
    {
        // Properties 
        public TimeSpan HorarioMarcado { get; set; }
        public string Titulo { get; set; }
        public int TempoDuracao { get; set; }

        // Construtores
        public VagaPalestra()
        {

        }

        public VagaPalestra(string titulo, int tempoDuracao)
        {
            Titulo = titulo;
            TempoDuracao = tempoDuracao;
        }

        public VagaPalestra(TimeSpan horarioMarcado, string titulo)
        {
            Titulo = titulo;
            HorarioMarcado = horarioMarcado;
        }

        public VagaPalestra(TimeSpan horarioMarcado, string titulo, int tempoDuracao) : this(titulo, tempoDuracao)
        {
            HorarioMarcado = horarioMarcado;
        }

        // Método para quebrar a string de entrada.
        // A string será quebrada em duas partes. Cada uma será passada como parametro para o construtor de VagaPalestra.
        // Adiciona a instância na lista.
        static public void PreencheLista(List<VagaPalestra> lista, string entradaPalesta)
        {
            string titulo = entradaPalesta.Trim().Substring(0, entradaPalesta.Length - 5).Trim();
            int duracao = int.Parse(entradaPalesta.Trim().Substring(entradaPalesta.Length - 5, 2).Trim());

            // Preenchimento da lista. 
            lista.Add(new VagaPalestra(titulo, duracao));
        }

        // Formatação da exibição do objeto, quando requisitado.
        public override string ToString()
        {
            string hrMarcado = String.Format("{0:00}:{1:00}", HorarioMarcado.Hours, HorarioMarcado.Minutes);
            if (TempoDuracao == 0)
            {
                return hrMarcado + " " + Titulo;
            }
            else
            {
                return hrMarcado + " " + Titulo + " " + TempoDuracao + "min";
            }
        }
    }
}
