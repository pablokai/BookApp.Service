namespace BookApp.Model
{
    public class Libro
    {     
            public int? IdLibro { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public int Edicion { get; set; }
            public int IdGenero { get; set; }
            public DateTime AnnioPublicacion { get; set; }
            public byte[]? Portada { get; set; }

    }
}