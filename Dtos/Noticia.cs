using Newtonsoft.Json;
using Postgrest.Attributes;

namespace TennisRD.Dtos;

[Table(("noticia"))]
public class Noticia : BaseModelApp
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("titulo")]
    public string Titulo { get; set; }

    [JsonProperty("resumen")]
    public string Resumen { get; set; }

    [JsonProperty("contenido")]
    public string Contenido { get; set; }

    [JsonProperty("fecha")]
    public DateTime Fecha { get; set; }

    [JsonProperty("autor")]
    public string Autor { get; set; }

    [JsonProperty("publicado")]
    public bool Publicado { get; set; }

    [JsonProperty("foto_url")]
    public Uri FotoUrl { get; set; }

    [JsonProperty("detalle_url")]
    public string DetalleUrl { get; set; }

    [JsonProperty("estatus_notificacion")]
    public long EstatusNotificacion { get; set; }

    [JsonProperty("hashtags")]
    public List<String> Hashtags { get; set; }
}