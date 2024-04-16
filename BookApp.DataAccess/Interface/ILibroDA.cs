using BookApp.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataAccess.Interface
{
    public interface ILibroDA
    {
        Task<List<Libro>> ListarLibros();
        Task<Respuesta<Libro>> InsertarLibro(Libro InputLibro);
        Task<Respuesta<Libro>> ModificarLibro(Libro InputLibro);
        Task<Respuesta<Libro>> EliminarLibro(Libro InputLibro);
        Task<Respuesta<Libro>> ObtenerLibroPorId(Libro InputLibro);
        Task<List<Genero>> ObtenerGenero();


    }
}
       