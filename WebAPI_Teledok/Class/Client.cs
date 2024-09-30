using System.Text.Json.Serialization;

namespace WebAPI_Teledok.Class
{
    public class Client
    {
        public int IdClient { get; set; }
        public string? INNClient { get; set; }
        public string? NameClient { get; set; }
        public DateTime DateOfAdditionClient { get; set; }
        public DateTime? DateOfUpdateClient { get; set;}
        public int TypeOfClientID { get; set; }

        [JsonIgnore]
        public TypeOfClient? TypeOfClient { get; set; }
        
        [JsonIgnore]
        public ICollection<Founder>? Founders { get; set; }
        
    }
}
