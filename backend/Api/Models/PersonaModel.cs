namespace Api.Models;

//No muestro el DNI como haríamos usualmente con la contraseña.
public class PersonaModel
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Direccion { get; set; }
}