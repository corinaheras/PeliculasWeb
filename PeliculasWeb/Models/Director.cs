using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PeliculasWeb.Models
{
    public class Director 
    {
        //PK
        public int DirectorId { get; set; } //id del director

        //atributos
        public string Nombre { get; set; } //nombre del director
        public string Nacionalidad { get; set; } //nacionalidad del director
        public int Edad { get; set; } //fecha de nacimiento del director
        public int PremiosGanados { get; set; }

        [ValidateNever]
        //relacion 1-N
        public ICollection<Pelicula> PeliculasDirigidas { get; set; }

    }
}
