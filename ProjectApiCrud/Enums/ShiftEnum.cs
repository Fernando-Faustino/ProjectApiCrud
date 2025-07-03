using System.Text.Json.Serialization;

namespace ProjectApiCrud.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ShiftEnum
    {
        Manhã,
        Tarde,
        Noite,
       
    }
}
