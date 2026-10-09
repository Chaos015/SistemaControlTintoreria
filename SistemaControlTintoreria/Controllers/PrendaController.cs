
using Microsoft.AspNetCore.Mvc;
using SistemaControlTintoreria.DTOs;

namespace SistemaControlTintoreria.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrendaController : ControllerBase
{
    private static readonly List<PrendaDto> prendas = new();
    private static int siguienteId = 1;

    [HttpGet]
    public ActionResult<IEnumerable<PrendaDto>> ObtenerPrendas()
    {
        return Ok(prendas);
    }

    [HttpGet("{id}")]
    public ActionResult<PrendaDto> ObtenerPrenda(int id)
    {
        var prenda = prendas.FirstOrDefault(p => p.Id == id);

        if (prenda == null)
            return NotFound();

        return Ok(prenda);
    }

    [HttpPost]
    public ActionResult<PrendaDto> CrearPrenda(PrendaDto prendaDto)
    {
        prendaDto.Id = siguienteId++;
        prendas.Add(prendaDto);

        return CreatedAtAction(
            nameof(ObtenerPrenda),
            new { id = prendaDto.Id },
            prendaDto);
    }

    [HttpPut("{id}")]
    public IActionResult ActualizarPrenda(int id, PrendaDto prendaDto)
    {
        var prenda = prendas.FirstOrDefault(p => p.Id == id);

        if (prenda == null)
            return NotFound();

        prenda.Tipo = prendaDto.Tipo;
        prenda.Descripcion = prendaDto.Descripcion;
        prenda.Color = prendaDto.Color;
        prenda.ClienteId = prendaDto.ClienteId;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarPrenda(int id)
    {
        var prenda = prendas.FirstOrDefault(p => p.Id == id);

        if (prenda == null)
            return NotFound();

        prendas.Remove(prenda);

        return NoContent();
    }
}
