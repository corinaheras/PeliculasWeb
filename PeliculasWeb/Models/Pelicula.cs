namespace PeliculasWeb.Models
{
    public class Pelicula
    {
        //PK
        public int PeliculaId { get; set; }

        //atributos
        public DateTime FechaEstreno { get; set; }
        public string NombrePelicula { get; set; }
        public string Genero { get; set; }
        public string Sipnosis { get; set; }


        //FK
        public int ActorId { get; set; }
        public int DirectorId { get; set; }


        //navegacion 
        public Actor Actor { get; set; }
        public Director Director { get; set; }


        //relacion 1-N reseñas
        public ICollection<Reseña> Reseñas { get; set; }

    }
  }
