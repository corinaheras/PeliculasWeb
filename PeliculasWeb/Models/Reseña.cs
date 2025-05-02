using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PeliculasWeb.Models
{
    public class Reseña 
    {
        //PK
        public int ReseñaId { get; set; }

        //atributos
        public int Calificacion { get; set; }
        public string Comentario { get; set; }

        public DateTime FechaReseña { get; set; }
        public bool EsRecomendada { get; set; }


        //FK 
        public int ClienteId { get; set; }
        public int PeliculaId { get; set; }

        [ValidateNever]
        //navegacion 
        public Pelicula Pelicula { get; set; }
        public Cliente Cliente { get; set; }


    }
}
