namespace PeliculasWeb.Models
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string NombrePelicula { get; set; }
        public string Genero { get; set; }
        public string Sipnosis { get; set; }


        //FK 
        public int IdDirector { get; set; }
        public int IdActor { get; set; }


        //navegacion 
        public Director Director { get; set; }
        public Actor Actor { get; set; }

        //relacion 1-N reseñas
        public ICollection<Reseña> Reseñas { get; set; }

    }
  }
