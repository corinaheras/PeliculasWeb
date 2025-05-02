using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PeliculasWeb.Models
{
    public class Genero
    {
        //PK 
        public int GeneroId { get; set; }


        //atributos
        public string NombreGenero { get; set; }
        public string Descripcion { get; set; }

        [ValidateNever]
        //relacion 1-N
        public ICollection<Pelicula> Peliculas { get; set; }

    }
}
