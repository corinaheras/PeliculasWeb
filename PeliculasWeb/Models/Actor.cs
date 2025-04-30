namespace PeliculasWeb.Models
{
    public class Actor 
    {
        //PK 
        public int ActorId { get; set; }


        //atributos
        public string Personaje { get; set; }
        public string NombreActor { get; set; }
        public int Edad { get; set; }
        public string Nacionalidad { get; set; }


        //relacion 1-N
        public ICollection<Pelicula> PeliculasProtagonizadas { get; set; }
    }
}
