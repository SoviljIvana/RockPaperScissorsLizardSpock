namespace RPSLS.Models
{
    public class Choice : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Player>? Players { get; set; }
        public List<Computer>? Computers { get; set; }
    }
}
