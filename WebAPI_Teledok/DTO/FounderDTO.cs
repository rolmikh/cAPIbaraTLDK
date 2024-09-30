using System.Text.Json.Serialization;

namespace WebAPI_Teledok.DTO
{
    public class FounderDTO
    {

        public string? INNFounder { get; set; }
        public string? SurnameFounder { get; set; }
        public string? NameFounder { get; set; }
        public string? MiddleNameFounder { get; set; }
        public int ClientID { get; set; }

    }
}
