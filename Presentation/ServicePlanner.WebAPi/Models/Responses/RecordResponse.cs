#pragma warning disable CS8618

namespace ServicePlanner.WebApi.Models.Responses
{
    public class RecordResponse
    {
        public Guid Id { get; init; }
        public Guid ProfileId { get; set; }
        public DateOnly Date { get; set; }
        public string Text { get; set; }
    }
}
