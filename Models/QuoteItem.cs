using System.ComponentModel.DataAnnotations;

namespace QuoteApi.Models
{
    public class QuoteItem
    {
        public long Id { get; set; }
        [Required]
        public string? Quote { get; set; }

        //not all quotes need an author or a source, it can be unknown
        public string? Author { get; set; }
        public string? Secret { get; set; }

    }
}
