using BookApp.DataAccess.Interface;
using BookApp.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BookApp.DataAccess
{
    public class LibroDA : ILibroDA
    {
        private ConnectionManager _connectionManager;
        public LibroDA(IConfiguration configuration)
        {
            _connectionManager = new ConnectionManager(configuration);
        }

        public async Task<List<Libro>> ListarLibros()
        {
            List<Libro> libros = new List<Libro>();
            try
            {
                using var connection = _connectionManager.GetConnection();
                var result = await connection.QueryAsync<Libro>
                (
                    sql: "usp_ListarLibros",
                    commandType: System.Data.CommandType.StoredProcedure
                );

                if(result != null ) { 
                    libros = result.ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return libros;
             
        }

        public async Task<Respuesta<Libro>> InsertarLibro(Libro InputLibro)
        {
            Respuesta<Libro> respuesta = new Respuesta<Libro>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Titulo", InputLibro.Titulo, DbType.String);
                parameters.Add("@Autor", InputLibro.Autor, DbType.String);
                parameters.Add("@Edicion", InputLibro.Edicion, DbType.Int32);
                parameters.Add("@IdGenero", InputLibro.IdGenero, DbType.Int32);
                parameters.Add("@AnnioPublicacion", InputLibro.AnnioPublicacion, DbType.DateTime);
                parameters.Add("@Portada", InputLibro.Portada, DbType.Byte);
                //output variables
                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                using var connection = _connectionManager.GetConnection();
                var result = await connection.QueryAsync<Respuesta<Libro>>
                (
                    sql: "usp_InsertarLibros",
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );

                if (result != null)
                {
                    respuesta = result.FirstOrDefault();

                    if(respuesta.Estado == 0)
                    {
                        respuesta.Lista.Add(new Libro
                        {
                            Autor = InputLibro.Autor,
                            Titulo = InputLibro.Titulo,
                            Edicion = InputLibro.Edicion,
                            IdGenero= InputLibro.IdGenero,
                            AnnioPublicacion =InputLibro.AnnioPublicacion,

                        });
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;

        }

        public async Task<Respuesta<Libro>> ModificarLibro(Libro InputLibro)
        {
            Respuesta<Libro> respuesta = new Respuesta<Libro>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdLibro", InputLibro.IdLibro, DbType.Int32);
                parameters.Add("@Titulo", InputLibro.Titulo, DbType.String);
                parameters.Add("@Autor", InputLibro.Autor, DbType.String);
                parameters.Add("@Edicion", InputLibro.Edicion, DbType.Int32);
                parameters.Add("@IdGenero", InputLibro.IdGenero, DbType.Int32);
                parameters.Add("@AnnioPublicacion", InputLibro.AnnioPublicacion, DbType.DateTime);
                parameters.Add("@Portada", InputLibro.Portada, DbType.Byte);
                //output variables
                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                using var connection = _connectionManager.GetConnection();
                var result = await connection.QueryAsync<Respuesta<Libro>>
                (
                    sql: "usp_ModificarLibros",
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );

                if (result != null)
                {
                    respuesta = result.FirstOrDefault();

                    if (respuesta.Estado == 0)
                    {
                        respuesta.Lista.Add(new Libro
                        {
                            Autor = InputLibro.Autor,
                            Titulo = InputLibro.Titulo,
                            Edicion = InputLibro.Edicion,
                            IdGenero = InputLibro.IdGenero,
                            AnnioPublicacion = InputLibro.AnnioPublicacion,

                        });
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;

        }

        public async Task<Respuesta<Libro>> EliminarLibro(Libro InputLibro)
        {
            Respuesta<Libro> respuesta = new Respuesta<Libro>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdLibro", InputLibro.IdLibro, DbType.Int32);

                //output variables
                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                using var connection = _connectionManager.GetConnection();
                var result = await connection.QueryAsync<Respuesta<Libro>>
                (
                    sql: "usp_EliminarLibros",
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );

                if (result != null)
                {
                    respuesta = result.FirstOrDefault();

                    if (respuesta.Estado == 0)
                    {
                        respuesta.Lista.Add(new Libro
                        {
                            Autor = InputLibro.Autor,
                            Titulo = InputLibro.Titulo,
                            Edicion = InputLibro.Edicion,
                            IdGenero = InputLibro.IdGenero,
                            AnnioPublicacion = InputLibro.AnnioPublicacion,

                        });
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;

        }

        public async Task<Respuesta<Libro>> ObtenerLibroPorId(Libro InputLibro)
        {
            Respuesta<Libro> respuesta = new Respuesta<Libro>();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdLibro", InputLibro.IdLibro, DbType.Int32);

                //output variables
                parameters.Add("@Estado", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                using var connection = _connectionManager.GetConnection();
                var result = await connection.QueryAsync<Respuesta<Libro>>
                (
                    sql: "usp_ObtenerLibro",
                    param: parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );

                if (result != null)
                {
                    respuesta = result.FirstOrDefault();

                }

            }
            catch (Exception)
            {

                throw;
            }

            return respuesta;

        }
    }
}