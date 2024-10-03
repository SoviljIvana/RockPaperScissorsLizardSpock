namespace RPSLS.Models
{
    public class Play : BaseModel
    {
        public Guid Id { get; set; }
        public string? Results { get; set; }
        public int Opponent1 { get; set; }
        public int? Opponent2 { get; set; }
    }
}
