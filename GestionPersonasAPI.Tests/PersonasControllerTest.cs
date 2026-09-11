using System.ComponentModel.DataAnnotations;
using GestionPersonasAPI.Controllers;
using GestionPersonasAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPersonasAPI.Tests
{
    public class PersonasControllerTest
    {
        [Fact]
        public async Task GetPersonas_RetornaLista_CuandoExistenPersonas()
        {
            var context = Setup.GetDatabaseContext();
            context.Personas.AddRange(new[]
            {
                new Persona
                {
                    PrimerNombre = "Juan",
                    PrimerApellido = "Perez",
                    DUI = "01234567-8",
                    FechaNacimiento = new DateTime(1990, 5, 15)
                },
                new Persona
                {
                    PrimerNombre = "Maria",
                    PrimerApellido = "Lopez",
                    DUI = "12345678-9",
                    FechaNacimiento = new DateTime(1985, 1, 20)
                }
            });
            await context.SaveChangesAsync();
            var controller = new PersonasController(context);

            var result = await controller.GetPersonas();

            var personas = Assert.IsType<List<Persona>>(result.Value);
            Assert.Equal(2, personas.Count);
        }

        [Fact]
        public async Task GetPersona_RetornaPersona_CuandoIdEsValido()
        {
            var context = Setup.GetDatabaseContext();
            var nuevaPersona = new Persona
            {
                PrimerNombre = "Juan",
                SegundoNombre = "Carlos",
                PrimerApellido = "Perez",
                SegundoApellido = "Lopez",
                DUI = "01234567-8",
                FechaNacimiento = new DateTime(1990, 5, 15)
            };
            context.Personas.Add(nuevaPersona);
            await context.SaveChangesAsync();
            var controller = new PersonasController(context);

            var result = await controller.GetPersona(nuevaPersona.Id);

            var actionResult = Assert.IsType<ActionResult<Persona>>(result);
            var persona = Assert.IsType<Persona>(actionResult.Value);
            Assert.Equal("Juan", persona.PrimerNombre);
            Assert.Equal("01234567-8", persona.DUI);
        }

        [Fact]
        public async Task GetPersona_RetornaNotFound_CuandoIdNoExiste()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);

            var result = await controller.GetPersona(999);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostPersona_AgregarPersona_CuandoEsValida()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);
            var nuevaPersona = new Persona
            {
                PrimerNombre = "Ana",
                SegundoNombre = "Maria",
                PrimerApellido = "Gomez",
                SegundoApellido = "Ruiz",
                DUI = "87654321-0",
                FechaNacimiento = new DateTime(2000, 12, 1)
            };

            var result = await controller.PostPersona(nuevaPersona);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var persona = Assert.IsType<Persona>(createdResult.Value);
            Assert.Equal("Ana", persona.PrimerNombre);
            Assert.Equal("87654321-0", persona.DUI);
        }

        [Fact]
        public async Task PostPersona_IncrementaConteo_CuandoSeAgregaNuevaPersona()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);

            await controller.PostPersona(new Persona
            {
                PrimerNombre = "Pedro",
                PrimerApellido = "Martinez",
                DUI = "11111111-1",
                FechaNacimiento = new DateTime(1995, 3, 10)
            });

            await controller.PostPersona(new Persona
            {
                PrimerNombre = "Luis",
                PrimerApellido = "Ramirez",
                DUI = "22222222-2",
                FechaNacimiento = new DateTime(1992, 7, 25)
            });

            var personas = context.Personas.ToList();
            Assert.Equal(2, personas.Count);
        }

        [Fact]
        public async Task PostPersona_RetornaBadRequest_CuandoPrimerNombreEstaVacio()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);
            var personaInvalida = new Persona
            {
                PrimerNombre = "",
                PrimerApellido = "Perez",
                DUI = "01234567-8",
                FechaNacimiento = new DateTime(1990, 5, 15)
            };
            ValidarModelo(controller, personaInvalida);

            var result = await controller.PostPersona(personaInvalida);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task PostPersona_RetornaBadRequest_CuandoPrimerApellidoEstaVacio()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);
            var personaInvalida = new Persona
            {
                PrimerNombre = "Juan",
                PrimerApellido = "",
                DUI = "01234567-8",
                FechaNacimiento = new DateTime(1990, 5, 15)
            };
            ValidarModelo(controller, personaInvalida);

            var result = await controller.PostPersona(personaInvalida);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task PostPersona_RetornaBadRequest_CuandoDUIEsInvalido()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);
            var personaInvalida = new Persona
            {
                PrimerNombre = "Juan",
                PrimerApellido = "Perez",
                DUI = "123",
                FechaNacimiento = new DateTime(1990, 5, 15)
            };
            ValidarModelo(controller, personaInvalida);

            var result = await controller.PostPersona(personaInvalida);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task PostPersona_RetornaBadRequest_CuandoNombreExcedeLongitudMaxima()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);
            var personaInvalida = new Persona
            {
                PrimerNombre = new string('A', 101),
                PrimerApellido = "Perez",
                DUI = "01234567-8",
                FechaNacimiento = new DateTime(1990, 5, 15)
            };
            ValidarModelo(controller, personaInvalida);

            var result = await controller.PostPersona(personaInvalida);

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task PutPersona_ActualizaPersona_CuandoEsValida()
        {
            var context = Setup.GetDatabaseContext();
            var persona = new Persona
            {
                PrimerNombre = "Juan",
                PrimerApellido = "Perez",
                DUI = "01234567-8",
                FechaNacimiento = new DateTime(1990, 5, 15)
            };
            context.Personas.Add(persona);
            await context.SaveChangesAsync();
            var controller = new PersonasController(context);

            persona.PrimerNombre = "Juan Actualizado";
            persona.DUI = "99999999-9";

            var result = await controller.PutPersona(persona.Id, persona);

            Assert.IsType<NoContentResult>(result);
            var actualizada = await context.Personas.FindAsync(persona.Id);
            Assert.Equal("Juan Actualizado", actualizada!.PrimerNombre);
            Assert.Equal("99999999-9", actualizada.DUI);
        }

        [Fact]
        public async Task PutPersona_RetornaBadRequest_CuandoIdNoCoincide()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);
            var persona = new Persona
            {
                Id = 1,
                PrimerNombre = "Juan",
                PrimerApellido = "Perez",
                DUI = "01234567-8",
                FechaNacimiento = new DateTime(1990, 5, 15)
            };

            var result = await controller.PutPersona(2, persona);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PutPersona_RetornaNotFound_CuandoIdNoExiste()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);
            var persona = new Persona
            {
                Id = 999,
                PrimerNombre = "Juan",
                PrimerApellido = "Perez",
                DUI = "01234567-8",
                FechaNacimiento = new DateTime(1990, 5, 15)
            };

            var result = await controller.PutPersona(999, persona);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeletePersona_EliminaPersona_CuandoExiste()
        {
            var context = Setup.GetDatabaseContext();
            var persona = new Persona
            {
                PrimerNombre = "Juan",
                PrimerApellido = "Perez",
                DUI = "01234567-8",
                FechaNacimiento = new DateTime(1990, 5, 15)
            };
            context.Personas.Add(persona);
            await context.SaveChangesAsync();
            var controller = new PersonasController(context);

            var result = await controller.DeletePersona(persona.Id);

            Assert.IsType<NoContentResult>(result);
            Assert.False(await context.Personas.AnyAsync());
        }

        [Fact]
        public async Task DeletePersona_RetornaNotFound_CuandoIdNoExiste()
        {
            var context = Setup.GetDatabaseContext();
            var controller = new PersonasController(context);

            var result = await controller.DeletePersona(999);

            Assert.IsType<NotFoundResult>(result);
        }

        private static void ValidarModelo(PersonasController controller, Persona persona)
        {
            var validationContext = new ValidationContext(persona);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(persona, validationContext, validationResults, validateAllProperties: true);

            foreach (var validationResult in validationResults)
            {
                foreach (var memberName in validationResult.MemberNames)
                {
                    controller.ModelState.AddModelError(memberName, validationResult.ErrorMessage!);
                }
            }
        }
    }
}