namespace RPSLS.Models
{
    public class Player : BaseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int? ChoiceId { get; set; }
        public virtual Choice? Choice { get; set; }
    }
}
