using System.ComponentModel.DataAnnotations;

namespace ServicePlanner.WebApi.Models.Requests
{
    public class RecordByPeriodRequest:BySearchRequest
    {
        [Required]
        public Guid ProfileId { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
    }
}
