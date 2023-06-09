using Newtonsoft.Json;
using Postgrest.Attributes;

namespace TennisRD.Dtos;

[Table("torneo_view")]
public class TorneoView : BaseModelApp
{
    [JsonProperty("evento_id")]
    public long EventoId { get; set; }

    [JsonProperty("titulo")]
    public string Titulo { get; set; }

    [JsonProperty("desde")]
    public DateTime Desde { get; set; }

    [JsonProperty("hasta")]
    public DateTime Hasta { get; set; }

    [JsonProperty("club_id")]
    public long ClubId { get; set; }

    [JsonProperty("organizadores")]
    public string[] Organizadores { get; set; }

    [JsonProperty("correo")]
    public string Correo { get; set; }

    [JsonProperty("whatsapp")]
    public string Whatsapp { get; set; }

    [JsonProperty("pagina_web")]
    public string PaginaWeb { get; set; }

    [JsonProperty("instagram")]
    public string Instagram { get; set; }

    [JsonProperty("inscripcion")]
    public long Inscripcion { get; set; }

    [JsonProperty("hashtag")]
    public string Hashtag { get; set; }

    [JsonProperty("estatus")]
    public long Estatus { get; set; }

    [JsonProperty("tipo_cancha")]
    public long TipoCancha { get; set; }

    [JsonProperty("inscripciones_abiertas")]
    public bool InscripcionesAbiertas { get; set; }

    [JsonProperty("nombre_club")]
    public string NombreClub { get; set; }

    [JsonProperty("nombre_evento")]
    public string NombreEvento { get; set; }

    [JsonProperty("logo_url")]
    public Uri LogoUrl { get; set; }
}