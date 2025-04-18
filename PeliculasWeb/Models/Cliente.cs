namespace PeliculasWeb.Models
{
    public class Cliente : Usuarios
    {
  
        //atributos
        public string CorreoElectronico { get; set; }
        private bool EsPremium { get; set; }

        //relacion 1-N
        public ICollection<Reseña> Reseñas { get; set; }

    }
}
