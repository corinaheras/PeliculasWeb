namespace PeliculasWeb.Models
{
    public class Director
    {
        //PK
        public int IdDirector { get; set; }

        //atributos
        public int PremiosGanados { get; set; }

        //FK
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        public int Edad { get; set; }

        //navegacion

        public Usuarios usuarios { get; set; }


        //relacion 1-N
        public ICollection<Pelicula> PeliculasDirigidas { get; set; }

    }
}
