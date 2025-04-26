#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ServicePlanner.WebApi.Models.Responses
{
    public class RecordResponse
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        public Guid ProfileId { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
