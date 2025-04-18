namespace PeliculasWeb.Models
{
    public class Reseña 
    {
        //PK
        public int IdReseña { get; set; }

        //atributos
        public int Calificacion { get; set; }
        public string Comentario { get; set; }


        //FK 
        public int IdPelicula { get; set; }
        public int IdUsuario { get; set; }


        //navegacion 
        public Pelicula Pelicula { get; set; }
        public Cliente Cliente { get; set; }

    }
}
