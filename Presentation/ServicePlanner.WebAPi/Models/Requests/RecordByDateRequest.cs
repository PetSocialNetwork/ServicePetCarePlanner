using System.ComponentModel.DataAnnotations;

namespace ServicePlanner.WebApi.Models.Requests
{
    public class RecordByDateRequest
    {
        [Required]
        public Guid ProfileId { get; set; }
        [Required]
        public DateOnly Date { get; set; }
    }
}
