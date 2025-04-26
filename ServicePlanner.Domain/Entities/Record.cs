using ServicePlanner.Domain.Interfaces;

namespace ServicePlanner.Domain.Entities
{
    public class Record : IEntity
    {
        public Guid Id { get; init; }
        public Guid ProfileId { get; init; }
        public DateOnly Date { get; set; }
        public string Text { get; set; }
        public Record(Guid id, Guid profileId, string text)
        {
            Id = id;
            Text = text;
            ProfileId = profileId;
        }
        protected Record() { }
    }
}
