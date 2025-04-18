namespace PeliculasWeb.Models
{
    public class Actor : Usuarios
    {

        //relacion 1-N
        public ICollection<Pelicula> PeliculasProtagonizadas { get; set; }




    }
}
