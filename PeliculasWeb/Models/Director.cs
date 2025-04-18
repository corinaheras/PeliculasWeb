namespace PeliculasWeb.Models
{
    public class Director : Usuarios
    {
 
        //atributos
        public int PremiosGanados { get; set; }  

        //relacion 1-N
        public ICollection<Pelicula> PeliculasDirigidas { get; set; }

    }
}
