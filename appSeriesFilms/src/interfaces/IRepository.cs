
using System.Collections.Generic;


namespace appSeriesFilms.src.interfaces
{
    public interface IRepository<AnyEntity>
    {
        List<AnyEntity> List();
        void Insert (AnyEntity entity);
        void Delete (int id);
        void Update (int id, AnyEntity entity);
        public int NextId();
        
    }
}