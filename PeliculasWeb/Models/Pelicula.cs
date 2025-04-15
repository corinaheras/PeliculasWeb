namespace PeliculasWeb.Models
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string NombrePelicula { get; set; }
        public string Genero { get; set; }
        public string Sipnosis { get; set; }
    }
}
