namespace Services.Exceptions
{
    /// <summary>
    /// Custom exception used when an entity is sought in the DB and not found
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message passed with the exception</param>
        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message passed with the exception</param>
        /// <param name="inner">Inner exception trace</param>
        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
