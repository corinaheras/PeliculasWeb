using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PeliculasWeb.Models
{
    public class Pelicula
    {
        //PK
        public int PeliculaId { get; set; }

        //atributos
        [DisplayName ("Fecha de estreno")]
        public DateTime FechaEstreno { get; set; }

        [DisplayName ("Nombre")]
        public string NombrePelicula { get; set; }
        public string Sipnosis { get; set; }

        [DisplayName ("Imagen")]
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
        [DisplayName ("Género")]
        public Genero Genero { get; set; }


        //relacion 1-N reseñas
        [ValidateNever]
        public ICollection<Reseña> Reseñas { get; set; }


    }
  }
