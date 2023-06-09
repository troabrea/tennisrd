using Newtonsoft.Json;
using Postgrest.Attributes;

namespace TennisRD.Dtos;

[Table("club")]
public class Club : BaseModelApp
{
    [JsonProperty("nombre")]
    public string Nombre { get; set; }

    [JsonProperty("direccion")]
    public string? Direccion { get; set; }

    [JsonProperty("ciudad")]
    public string? Ciudad { get; set; }

    [JsonProperty("telefono")]
    public string? Telefono { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("contacto")]
    public string Contacto { get; set; }

    [JsonProperty("canchas_duras")]
    public long CanchasDuras { get; set; }

    [JsonProperty("canchas_blandas")]
    public long CanchasBlandas { get; set; }

    [JsonProperty("horario")]
    public string Horario { get; set; }

    [JsonProperty("reservable")]
    public bool Reservable { get; set; }

    [JsonProperty("whatsapp_reserva")]
    public string WhatsappReserva { get; set; }

    [JsonProperty("latitud")]
    public double Latitud { get; set; }

    [JsonProperty("longitud")]
    public double Longitud { get; set; }

    [JsonProperty("foto_url")]
    public Uri FotoUrl { get; set; }

    [JsonProperty("privado")]
    public bool Privado { get; set; }

    [JsonProperty("costo_hora")]
    public long CostoHora { get; set; }
}