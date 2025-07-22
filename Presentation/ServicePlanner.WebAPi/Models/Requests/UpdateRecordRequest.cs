#pragma warning disable CS8618
namespace ServicePlanner.WebApi.Models.Requests
{
    public class UpdateRecordRequest
    {
        public Guid Id { get; init; }
        public string Text { get; set; }
    }
}
