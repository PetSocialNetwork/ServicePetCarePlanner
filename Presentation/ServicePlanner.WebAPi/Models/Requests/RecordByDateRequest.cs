using System.ComponentModel.DataAnnotations;

namespace ServicePlanner.WebApi.Models.Requests
{
    public class RecordByDateRequest : BySearchRequest
    {
        [Required]
        public Guid ProfileId { get; set; }
        [Required]
        public DateOnly Date { get; set; }
    }
}
