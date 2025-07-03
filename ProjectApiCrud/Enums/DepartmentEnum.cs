using System.Text.Json.Serialization;

namespace ProjectApiCrud.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        Rh,
        Financeiro,
        Compras,
        Atendimento,
        Zeladoria
    }
}
