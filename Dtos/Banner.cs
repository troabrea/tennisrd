using Postgrest.Attributes;

namespace TennisRD.Dtos;

[Table("banner")]
public class Banner : BaseModelApp
{
    public int Orden { get; set; }
    [Column("imagen_url")]
    public string ImagenUrl { get; set; }
    [Column("detalle_url")]
    public string DetalleUrl { get; set; }
    public DateTime? Desde { get; set; }
    public DateTime? Hasta { get; set; }
}