namespace Cosmalyze.Api.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public Product product { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public float RatingValue { get; set; }
        public string Comment { get; set; }
    }
}
