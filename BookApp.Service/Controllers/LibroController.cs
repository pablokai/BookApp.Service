using BookApp.BusinessLogic;
using BookApp.DataAccess.Interface;
using BookApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private LibroBL libroBL;

        public LibroController(ILibroDA libroDA)
        {
            this.libroBL = new LibroBL(libroDA);
        }

        [HttpPost]
        [Route("ListarLibros")]
        public async Task<IActionResult> ListarLibros()
        {
            try
            {
                var respuesta = await libroBL.ListarLibros();

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertarLibro")]
        public async Task<IActionResult> InsertarLibro([FromBody] Libro libro)
        {
            try
            {
                var respuesta = await libroBL.InsertarLibro(libro);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("ModificarLibro")]
        public async Task<IActionResult> ModificarLibro([FromBody] Libro libro)
        {
            try
            {
                var respuesta = await libroBL.ModificarLibro(libro);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("EliminarLibro")]
        public async Task<IActionResult> EliminarLibro([FromBody] Libro libro)
        {
            try
            {
                var respuesta = await libroBL.EliminarLibro(libro);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("ObtenerLibroPorId")]
        public async Task<IActionResult> ObtenerLibroPorId([FromBody] Libro libro)
        {
            try
            {
                var respuesta = await libroBL.ObtenerLibroPorId(libro);

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("ObtenerGenero")]
        public async Task<IActionResult> ObtenerGenero()
        {
            try
            {
                var respuesta = await libroBL.ObtenerGenero();

                return StatusCode(200, respuesta);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
