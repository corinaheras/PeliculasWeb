using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PeliculasWeb.Models
{
    public class Cliente 
    {

        //PK 
        public int ClienteId { get; set; }


        //atributos
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EsPremium { get; set; }

        [ValidateNever]
        //relacion 1-N
        public ICollection<Reseña> Reseñas { get; set; }

    }
}
