using LibrosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace LibrosAPI.Tests
{
    public class LibrosControllerTest
    {
        [Fact]
        public async Task PostLibro_AgregarLibro_CuandoLibroEsValido()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new LibrosController(context);
            var nuevoLibro = new Libro
            {
                Titulo = "Nuevo Libro",
                Autor = "Autor de Prueba",
                AnioPublicacion = DateTime.Now.Year,
            };
            var result = await controller.PostLibro(nuevoLibro);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);

            var libro = Assert.IsType<Libro>(createdResult.Value);
            Assert.Equal("Nuevo Libro", libro.Titulo);
        }

        [Fact]
        public async Task GetLibro_RetornarLibro_CuandoIdEsValido()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new LibrosController(context);
            var nuevoLibro = new Libro
            {
                Titulo = "Libro de prueba",
                Autor = "Autor de prueba",
                AnioPublicacion = DateTime.Now.Year,
            };
            context.Libros.Add(nuevoLibro);
            await context.SaveChangesAsync();

            var result = await controller.GetLibro(nuevoLibro.Id);

            var actionResult = Assert.IsType<ActionResult<Libro>>(result);
            var returnValue = Assert.IsType<Libro>(actionResult.Value);

            Assert.Equal("Libro de prueba", returnValue.Titulo);
        }

        [Fact]
        public async Task GetLibro_RetornaNotFound_CuandoIdNoExiste()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new LibrosController(context);

            var result = await controller.GetLibro(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostLibro_NoAgregarLibro_CuandoNoTieneTitulo()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new LibrosController(context);
            var nuevoLibro = new Libro
            {
                Titulo = null,
                Autor = "Autor de Prueba",
                AnioPublicacion = DateTime.Now.Year,
            };

            var result = await controller.PostLibro(nuevoLibro);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task PostLibro_IncrementaConteo_CuandoSeAgregarNuevoLibro()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new LibrosController(context);
            var nuevoLibro1 = new Libro
            {
                Titulo = "Libro 1",
                Autor = "Autor 1",
                AnioPublicacion = DateTime.Now.Year,
            };

            await controller.PostLibro(nuevoLibro1);

            var nuevoLibro2 = new Libro
            {
                Titulo = "Libro de prueba 2",
                Autor = "Autor de prueba 2",
                AnioPublicacion = DateTime.Now.Year,
            };

            var result = await controller.PostLibro(nuevoLibro2);
            var libros = context.Libros.ToList();
            Assert.Equal(2, libros.Count);
        }

    }
}
