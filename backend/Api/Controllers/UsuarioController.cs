using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly prog3Context _context;

    public UsuarioController(prog3Context context)
    {
        _context = context;
    }
    [HttpPost("login")]
    public async Task<ActionResult<UsuarioModel>> Login(UsuarioLoginModel usuarioLoginModel)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuarioLoginModel.Email && x.Password == usuarioLoginModel.Password);
        if (usuario == null)
        {
            return Unauthorized("Email o Contraseña incorrecta");
        }

        var usuarioModel = new UsuarioModel
        {
            Id = usuario.Id,
            Email = usuario.Email,
            Activo = usuario.Activo
        };
        return Ok(usuarioModel);
    }
}