using System.ComponentModel.DataAnnotations;

namespace ServicePetCarePlanner.WebApi.Models.Requests
{
    public class RecordByPeriodRequest
    {
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
    }
}
