using System.Text.Json.Serialization;

namespace WebAPI_Teledok.Class
{
    public class TypeOfClient
    {
        public int IdTypeOfClient { get; set; }
        public string? NameTypeOfClient { get; set;}

        public ICollection<Client>? Clients { get; set; }
    }
}
