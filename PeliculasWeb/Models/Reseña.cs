using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PeliculasWeb.Models
{
    public class Reseña 
    {
        //PK
        public int ReseñaId { get; set; }

        //atributos
        [DisplayName ("Calificación")]
        public int Calificacion { get; set; }
        public string Comentario { get; set; }
        [DisplayName ("Fecha de publicación")]
        public DateTime FechaReseña { get; set; }
        [DisplayName ("Recomendada?")]
        public bool EsRecomendada { get; set; }


        //FK 
        public int ClienteId { get; set; }
        public int PeliculaId { get; set; }


        //navegacion 

        [ValidateNever]
        public Pelicula Pelicula { get; set; }

        [ValidateNever]
        public Cliente Cliente { get; set; }


    }
}
