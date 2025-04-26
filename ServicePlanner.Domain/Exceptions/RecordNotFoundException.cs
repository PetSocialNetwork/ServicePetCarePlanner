namespace ServicePlanner.Domain.Exceptions
{
    /// <summary>
    /// Исключение типа, если запись не найдена
    /// </summary>
    public class RecordNotFoundException : DomainException
    {
        public RecordNotFoundException(string? message) : base(message)
        {
        }

        public RecordNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
