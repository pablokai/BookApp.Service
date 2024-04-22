namespace BookApp.Model
{
    public class Libro
    {
        public int? IdLibro { get; set; }
        public string Titulo { get; set; }
        public string NombreAutor { get; set; }
        public string PrimerApellidoAutor { get; set; }
        public string SegundoApellidoAutor { get; set; }

        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int IdGenero { get; set; }
        public string Genero { get; set; }
        public DateTime AnnioPublicacion { get; set; }
        public byte[]? PortadaBase64 { get; set; }
        public string Portada { get; set; }
        public int TotalPaginas { get; set; }

    }
}