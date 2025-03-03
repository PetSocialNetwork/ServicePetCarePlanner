#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ServicePetCarePlanner.WebApi.Models.Requests
{
    public class RecordRequest
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public DateOnly Date { get; set; }
    }

    public class UpdateRecordRequest
    {
        [Required]
        public Guid Id { get; init; }
        [Required]
        public string Text { get; set; }
    }
}
