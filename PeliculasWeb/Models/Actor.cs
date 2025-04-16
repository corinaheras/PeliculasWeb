namespace PeliculasWeb.Models
{
    public class Actor
    {

        //PK 
        public int IdActor { get; set; }

        //FK
        public string Nombre { get; set; }

        public string Nacionalidad { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Edad { get; set; }

        //Navegacion

        public Usuarios Usuarios { get; set; }

        //relacion 1-N
        public ICollection<Pelicula> PeliculasProtagonizadas { get; set; }




    }
}
