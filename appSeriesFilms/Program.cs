using appSeriesFilms.src.entities;
using appSeriesFilms.src.methods;

namespace appSeriesFilms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SeriesRepository repository = new SeriesRepository();
            Methods startAction = new Methods(repository);
            string userOption = startAction.GetUserOption();
            startAction.InvokeAction(userOption);
           
        }
    }
}
