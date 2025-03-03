using System.ComponentModel.DataAnnotations;

namespace ServicePetCarePlanner.WebApi.Models.Requests
{
    public class RecordByDateRequest
    {
        [Required]
        public DateOnly Date { get; set; }
    }
}
