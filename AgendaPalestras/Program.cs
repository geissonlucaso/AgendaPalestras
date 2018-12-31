using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPalestras
{
    class Program
    {
        // Listas utilizadas na geração da conferência
        static List<VagaPalestra> ListaPalestras = new List<VagaPalestra>();
        static List<VagaPalestra> vagaPalestras30min = new List<VagaPalestra>();
        static List<VagaPalestra> vagaPalestras45min = new List<VagaPalestra>();
        static List<VagaPalestra> vagaPalestras60min = new List<VagaPalestra>();

        // Declarando as seções de cada trilha.
        static Secao SecaoManha1 = new Secao("Manha", 1);
        static Secao SecaoTarde1 = new Secao("Tarde", 1);
        static Secao SecaoManha2 = new Secao("Manha", 2);
        static Secao SecaoTarde2 = new Secao("Tarde", 2);

        static void Main(string[] args)
        {
            // Loop para receber a entrada.
            // Será repetido 19 vezes(Número de entradas).
            for (int i = 0; i < 19; i++)
            {
                string texto = Console.ReadLine();
                VagaPalestra.PreencheLista(ListaPalestras, texto);
            }

            // Filtrando as palestras de modo a realocar os registros em outras tres lista (Critério TempoDuracao).
            foreach (var item in ListaPalestras)
            {
                if (item.TempoDuracao == 30)
                {
                    vagaPalestras30min.Add(item);
                }
                else if (item.TempoDuracao == 45)
                {
                    vagaPalestras45min.Add(item);
                }
                else
                {
                    vagaPalestras60min.Add(item);
                }
            }

            // A ordenação foi feita levando em conta a ordem de entrada dos registros e a ordem de exibição(saída). 
            ReordenarLista30Min();
            ReordenarLista45min();
            ReordenarLista60min();

            // Preenchimento das seções. As seções recebem as tres listas de palestras.
            SecaoManha1.PreencheSecao(vagaPalestras30min, vagaPalestras45min, vagaPalestras60min);
            SecaoTarde1.PreencheSecao(vagaPalestras30min, vagaPalestras45min, vagaPalestras60min);
            SecaoManha2.PreencheSecao(vagaPalestras30min, vagaPalestras45min, vagaPalestras60min);
            SecaoTarde2.PreencheSecao(vagaPalestras30min, vagaPalestras45min, vagaPalestras60min);

            // Exibição da saída
            // Percorre cada item das listas de palestras das seções.
            Console.WriteLine("Trilha 1");
            foreach (var item in SecaoManha1.Palestras)
            {
                Console.WriteLine(item);
            }

            foreach (var item in SecaoTarde1.Palestras)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" \n " );
            Console.WriteLine("Trilha 2");
            foreach (var item in SecaoManha2.Palestras)
            {
                Console.WriteLine(item);
            }
            foreach (var item in SecaoTarde2.Palestras)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }

        // Métodos para ordenar a lista de plalestras conforme a ordem de saida na agenda
        // Reordena lista30min.
        static void ReordenarLista30Min()
        {
            string[] vetAuxiliar = new string[vagaPalestras30min.Count];
            for (int i = 0; i < vagaPalestras30min.Count; i++)
            {
                vetAuxiliar[i] = vagaPalestras30min[i].Titulo;
            }
            vagaPalestras30min[0].Titulo = vetAuxiliar[0];
            vagaPalestras30min[1].Titulo = vetAuxiliar[3];
            vagaPalestras30min[2].Titulo = vetAuxiliar[4];
            vagaPalestras30min[3].Titulo = vetAuxiliar[6];
            vagaPalestras30min[4].Titulo = vetAuxiliar[1];
            vagaPalestras30min[5].Titulo = vetAuxiliar[2];
            vagaPalestras30min[6].Titulo = vetAuxiliar[5];
        }

        // Reordena lista45min.
        static void ReordenarLista45min()
        {
            string[] vetAuxiliar = new string[vagaPalestras45min.Count];
            for (int i = 0; i < vagaPalestras45min.Count; i++)
            {
                vetAuxiliar[i] = vagaPalestras45min[i].Titulo;
            }
            vagaPalestras45min[0].Titulo = vetAuxiliar[0];
            vagaPalestras45min[1].Titulo = vetAuxiliar[1];
            vagaPalestras45min[2].Titulo = vetAuxiliar[2];
            vagaPalestras45min[3].Titulo = vetAuxiliar[4];
            vagaPalestras45min[4].Titulo = vetAuxiliar[3];
            vagaPalestras45min[5].Titulo = vetAuxiliar[5];
        }

        // Reordena lista60min.
        static void ReordenarLista60min()
        {
            string[] vetAuxiliar = new string[vagaPalestras60min.Count];
            for (int i = 0; i < vagaPalestras60min.Count; i++)
            {
                vetAuxiliar[i] = vagaPalestras60min[i].Titulo;
            }
            vagaPalestras60min[0].Titulo = vetAuxiliar[0];
            vagaPalestras60min[1].Titulo = vetAuxiliar[4];
            vagaPalestras60min[2].Titulo = vetAuxiliar[2];
            vagaPalestras60min[3].Titulo = vetAuxiliar[3];
            vagaPalestras60min[4].Titulo = vetAuxiliar[5];
            vagaPalestras60min[5].Titulo = vetAuxiliar[1];
        }

    }
}
