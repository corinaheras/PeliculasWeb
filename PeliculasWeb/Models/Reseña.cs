namespace PeliculasWeb.Models
{
    public class Reseña
    {
        //PK
        public int IdReseña { get; set; }


        //FK clientes
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }


        //FK pelicula 
        public string NombrePelicula { get; set; }


        //atributos
        public int Calificacion { get; set; }
        public string Comentario { get; set; }


        //navegaciones
        public Cliente Cliente { get; set; }
        public Pelicula Pelicula { get; set; }

   



    }
}
