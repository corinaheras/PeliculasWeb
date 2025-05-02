using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PeliculasWeb.Models
{
    public class Pelicula
    {
        //PK
        public int PeliculaId { get; set; }

        //atributos
        public DateTime FechaEstreno { get; set; }
        public string NombrePelicula { get; set; }
        public string Sipnosis { get; set; }

        public string? ImagenRuta { get; set; }


        //FK
        public int ActorId { get; set; }
        public int DirectorId { get; set; }

        public int GeneroId { get; set; }

        //navegacion 

        [ValidateNever]
        public Actor Actor { get; set; }

        [ValidateNever]
        public Director Director { get; set; }

        [ValidateNever]
        public Genero Genero { get; set; }


        //relacion 1-N reseñas
        [ValidateNever]
        public ICollection<Reseña> Reseñas { get; set; }


    }
  }
