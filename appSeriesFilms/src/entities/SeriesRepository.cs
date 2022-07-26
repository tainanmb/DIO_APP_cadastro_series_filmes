using appSeriesFilms.src.interfaces;

namespace appSeriesFilms.src.entities
{
    public class SeriesRepository : IRepository<Serie>
    {
        private List<Serie> SerieList = new List<Serie>();

        public void Insert(Serie serie)
        {
            this.SerieList.Add(serie);
        }

        public void Delete(int id)
        {
            this.SerieList[id].Delete();
        }

        public void Update(int id, Serie serie)
        {
            this.SerieList[id] = serie;
        }

        public int NextId()
        {
            return this.SerieList.Count;
        }

        public List<Serie> List()
        {
            return this.SerieList;
        }

        public Serie GetSerieById(int id){
            return this.SerieList[id];
        }
    }
}
