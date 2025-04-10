namespace Core.Domain.Exceptions
{
    /// <summary>
    /// Representa uma exceção lançada quando uma regra de domínio é violada.
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException() { }

        public DomainException(string message)
            : base(message) { }

        public DomainException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
