namespace SistemaControlTintoreria.Entities;

public class Prenda
{
    public int Id { get; set; }

    public string Tipo { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public int ClienteId { get; set; }
}
