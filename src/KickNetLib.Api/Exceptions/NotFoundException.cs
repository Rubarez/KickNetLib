
namespace KickNetLib.Api.Exceptions
{
    /// <summary>
    /// Custom exception to represent a "Not Found" error, typically used for scenarios where a requested resource 
    /// is not found in the system (e.g., a resource in a database or an API endpoint).
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Default constructor for the <see cref="NotFoundException"/> class.
        /// </summary>
        public NotFoundException()
        {
        }

        /// <summary>
        /// Constructor for the <see cref="NotFoundException"/> class that accepts a custom error message.
        /// </summary>
        /// <param name="message">The custom error message that provides more details about the exception.</param>
        public NotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor for the <see cref="NotFoundException"/> class that accepts both a custom error message 
        /// and an inner exception.
        /// </summary>
        /// <param name="message">The custom error message that provides more details about the exception.</param>
        /// <param name="inner">The inner exception that is the cause of the current exception. This can be useful for exception chaining.</param>
        public NotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
