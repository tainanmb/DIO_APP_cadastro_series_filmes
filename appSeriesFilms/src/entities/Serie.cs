namespace appSeriesFilms.src.entities
{
    public class Serie : BaseEntity
    {
//Atributos
        public Genre Genre { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public bool Deleted { get; set; }

//Método construtor
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted=false;
        }

        public override string ToString()
        {
            string serie = "\n"+ "Título: "+ this.Title + "\n";
            serie += "Descrição: "+ this.Description + "\n";
            serie += "Gênero: "+ this.Genre + "\n";
            serie += "Ano de lançamento: "+ this.Year + "\n";
            serie += "Excluido: " + this.Deleted + "\n";
            return serie;   
        }
        
//Método que "deleta" a série
        public void Delete (){
            this.Deleted = true;
        }

        public string ReturnStatus(){
            string text;
            if (this.Deleted == true){
                text = "[Excluída]";
            } else{
                text = "[Ativa]";
            }
            return text;
        }

        public void SetSerie(Genre genre, string title, string description, int year){

            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
        }

        
    }
}
