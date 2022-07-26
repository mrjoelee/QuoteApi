namespace QuoteApi.Models
{
    public class QuoteItemDTO //DTO Data Transfer Obect - map properties between classes, security, bundle informaton, keep api consistent
    {
        public long Id { get; set; }
        public string? Quote { get; set; }
        public string? Author { get; set; }

    }
}
