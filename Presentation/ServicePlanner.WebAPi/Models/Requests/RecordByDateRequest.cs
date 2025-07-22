#pragma warning disable CS8618

namespace ServicePlanner.WebApi.Models.Requests
{
    public class RecordByDateRequest 
    {
        public Guid ProfileId { get; set; }
        public DateOnly Date { get; set; }
        public PaginationRequest Options { get; set; }
    }
}
