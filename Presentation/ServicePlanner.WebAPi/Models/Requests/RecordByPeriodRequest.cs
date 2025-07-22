#pragma warning disable CS8618

namespace ServicePlanner.WebApi.Models.Requests
{
    public class RecordByPeriodRequest
    {
        public Guid ProfileId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public PaginationRequest Options { get; set; }
    }
}
