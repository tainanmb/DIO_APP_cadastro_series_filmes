using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using appSeriesFilms.src.entities;

namespace appSeriesFilms.src.methods
{
    public class Methods
    {
        public SeriesRepository Repository { get; set; }

        public Methods(SeriesRepository repository)
        {
            this.Repository = repository;
        }

        public string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo(a) a DIO Séries!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        public void InvokeAction()
        {
            string userOption = GetUserOption();
            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
                
            }
        }

        private void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var list = this.Repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.Delete;

                Console.WriteLine(
                    "#ID {0}: - {1} {2}",
                    serie.Id,
                    serie.Title,
                    serie.ReturnStatus()
                );
            }
        }

        private void InsertSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string title = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento da série: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string description = Console.ReadLine();

            Serie serie = new Serie(Repository.NextId(), (Genre)genre, title, description, year);

            Repository.Insert(serie);
        }

        private void UpdateSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

           
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string title = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento da Série: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string description = Console.ReadLine();

			this.Repository.GetSerieById(indiceSerie).SetSerie((Genre)genre, title, description, year);

           
        }

		private  void DeleteSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			Repository.Delete(indiceSerie);
		}

        private void ViewSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = Repository.GetSerieById(indiceSerie);

			Console.WriteLine(serie);
		}
    }
}
