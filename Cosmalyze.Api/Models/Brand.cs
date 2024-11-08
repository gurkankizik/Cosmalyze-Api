namespace Cosmalyze.Api.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAllVegan { get; set; }
        public bool IsPartialVegan { get; set; }
        public bool IsCruelty { get; set; }
    }
}
