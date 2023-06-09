using Newtonsoft.Json;
using Postgrest.Attributes;

namespace TennisRD.Dtos;

[Table("evento")]
public class Evento : BaseModelApp
{
    [JsonProperty("nombre")]
    public string Nombre { get; set; }

    [JsonProperty("descripcion")]
    public string Descripcion { get; set; }

    [JsonProperty("organizadores")]
    public string[] Organizadores { get; set; }

    [JsonProperty("oficial")]
    public bool Oficial { get; set; }

    [JsonProperty("logo_url")]
    public Uri LogoUrl { get; set; }

    [JsonProperty("club_id")]
    public long ClubId { get; set; }

    [JsonProperty("pagina_web")]
    public string PaginaWeb { get; set; }

    [JsonProperty("instagram")]
    public string Instagram { get; set; }

    [JsonProperty("reglamento")]
    public string Reglamento { get; set; }

    [JsonProperty("por_equipo")]
    public bool PorEquipo { get; set; }

    [JsonProperty("hashtag")]
    public string Hashtag { get; set; }
}