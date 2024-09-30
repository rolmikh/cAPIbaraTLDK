namespace WebAPI_Teledok.Class
{
    public class Founder
    {
        public int IdFounder { get; set; }
        public string? INNFounder { get; set; }
        public string? SurnameFounder { get; set; }
        public string? NameFounder { get; set; }
        public string? MiddleNameFounder { get; set; }
        public DateTime DateOfAdditionFounder { get; set; }
        public DateTime? DateOfUpdateFounder { get; set; }
        public int ClientID { get; set; }

        public Client? Client { get; set; }
    }
}
