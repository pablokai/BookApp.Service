using BookApp.DataAccess;
using BookApp.DataAccess.Interface;
using BookApp.Model;
using Microsoft.Extensions.Configuration;

namespace BookApp.BusinessLogic
{
    public class LibroBL
    {
        public ILibroDA libroDA;

        public LibroBL(ILibroDA libroDA)
        {
            this.libroDA = libroDA;
        }

        public async Task<List<Libro>> ListarLibros()
        {
            return await libroDA.ListarLibros();
        }

        public async Task<Respuesta<Libro>> InsertarLibro(Libro InputLibro)
        {
            return await libroDA.InsertarLibro(InputLibro);
        }

        public async Task<Respuesta<Libro>> ModificarLibro(Libro InputLibro)
        {
            return await libroDA.ModificarLibro(InputLibro);
        }

        public async Task<Respuesta<Libro>> EliminarLibro(Libro InputLibro)
        {
            return await libroDA.EliminarLibro(InputLibro);
        }

        public async Task<Respuesta<Libro>> ObtenerLibroPorId(Libro InputLibro)
        {
            return await libroDA.ObtenerLibroPorId(InputLibro);
        }
        public async Task<List<Genero>> ObtenerGenero()
        {
            return await libroDA.ObtenerGenero();
        }
    }
}
    