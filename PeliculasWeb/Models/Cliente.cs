namespace PeliculasWeb.Models
{
    public class Cliente
    {
        //PK
        public int IdCliente { get; set; }
        //FK
        public string Nombre { get; set; }

        //atributos
        public string CorreoElectronico { get; set; }
        private bool EsPremium { get; set; } 

        //navegacion
        public Usuarios usuarios { get; set; }

        //relacion 1-N
        public ICollection<Reseña> Reseñas { get; set; }

    }
}
