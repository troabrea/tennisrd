using Newtonsoft.Json;
using Postgrest.Attributes;

namespace TennisRD.Dtos;

[Table("catalogo_producto")]
public partial class CatalogoProducto : BaseModelApp
{
    [JsonProperty("nombre_categoria")]
    public string NombreCategoria { get; set; }

    [JsonProperty("nombre_suplidor")]
    public string NombreSuplidor { get; set; }

    [JsonProperty("categoria_id")]
    public long CategoriaId { get; set; }

    [JsonProperty("suplidor_id")]
    public long SuplidorId { get; set; }

    [JsonProperty("nombre")]
    public string Nombre { get; set; }

    [JsonProperty("descripcion")]
    public string Descripcion { get; set; }

    [JsonProperty("precio")]
    public long Precio { get; set; }

    [JsonProperty("disponible")]
    public bool Disponible { get; set; }

    [JsonProperty("publicado")]
    public bool Publicado { get; set; }

    [JsonProperty("foto_url")]
    public Uri FotoUrl { get; set; }
}