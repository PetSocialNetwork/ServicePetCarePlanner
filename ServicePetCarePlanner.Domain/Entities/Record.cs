using ServicePetCarePlanner.Domain.Interfaces;

namespace ServicePetCarePlanner.Domain.Entities
{
    public class Record : IEntity
    {
        public Guid Id { get; init; }
        public DateOnly Date { get; set; }
        public string Text { get; set; }
        public Record(Guid id, string text)
        {
            Id = id;
            Text = text;
        }
        protected Record() { }
    }
}
