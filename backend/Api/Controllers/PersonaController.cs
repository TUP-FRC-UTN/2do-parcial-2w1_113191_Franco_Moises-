using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{
    private readonly prog3Context _context;

    public Controller(prog3Context context)
    {
        _context = context;
    }
    [HttpPost("Persona")]
    public async Task<ActionResult<PersonaModel>> Create(PersonaCreateModel persona)
    {
        var newPersona = new Persona
        {
            Nombre = persona.Nombre,
            Apellido = persona.Apellido,
            Dni = persona.Dni,
            Direccion = persona.Direccion
        };
        _context.Personas.Add(newPersona);
        await _context.SaveChangesAsync();

        var personaModel = new PersonaModel
        {
            Id = newPersona.Id,
            Nombre = newPersona.Nombre,
            Apellido = newPersona.Apellido,
            Direccion = newPersona.Direccion
        };
        return Ok(personaModel);
    }
}