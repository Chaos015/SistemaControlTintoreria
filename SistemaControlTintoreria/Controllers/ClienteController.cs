
using Microsoft.AspNetCore.Mvc;
using SistemaControlTintoreria.DTOs;

namespace SistemaControlTintoreria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private static readonly List<ClienteDto> clientes = new()
{
    new ClienteDto
    {
        Id = 1,
        Nombre = "Carlos Perez",
        Telefono = "809-555-0101",
        Direccion = "Santo Domingo"
    },
    new ClienteDto
    {
        Id = 2,
        Nombre = "Maria Rodriguez",
        Telefono = "809-555-0102",
        Direccion = "Santiago"
    }
};
    private static int siguienteId = 3;

    [HttpGet]
    public ActionResult<IEnumerable<ClienteDto>> ObtenerClientes()
    {
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public ActionResult<ClienteDto> ObtenerCliente(int id)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public ActionResult<ClienteDto> CrearCliente(ClienteDto clienteDto)
    {
        clienteDto.Id = siguienteId++;
        clientes.Add(clienteDto);

        return CreatedAtAction(
            nameof(ObtenerCliente),
            new { id = clienteDto.Id },
            clienteDto);
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarCliente(int id, ClienteDto clienteDto)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
            return NotFound();

        cliente.Nombre = clienteDto.Nombre;
        cliente.Telefono = clienteDto.Telefono;
        cliente.Direccion = clienteDto.Direccion;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarCliente(int id)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
            return NotFound();

        clientes.Remove(cliente);

        return NoContent();
    }
}
