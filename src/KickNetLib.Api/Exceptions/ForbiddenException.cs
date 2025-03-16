
namespace KickNetLib.Api.Exceptions
{
    /// <summary>
    /// Custom exception to represent a "Forbidden" error (HTTP 403 status code).
    /// This exception can be used to signal that the user does not have permission
    /// to perform the requested operation.
    /// </summary>
    public class ForbiddenException : Exception
    {
        /// <summary>
        /// Default constructor for the <see cref="ForbiddenException"/> class.
        /// This constructor is typically used when no specific error message or inner exception 
        /// is provided.
        /// </summary>
        public ForbiddenException()
        {
        }

        /// <summary>
        /// Constructor for the <see cref="ForbiddenException"/> class that accepts a custom error message.
        /// This allows you to provide more context about the forbidden operation when it is thrown.
        /// </summary>
        /// <param name="message">A custom error message that provides details about the forbidden operation.</param>
        public ForbiddenException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor for the <see cref="ForbiddenException"/> class that accepts both 
        /// a custom error message and an inner exception.
        /// This is useful for exception chaining, where the inner exception contains more information
        /// about the root cause of the error.
        /// </summary>
        /// <param name="message">A custom error message that provides more details about the forbidden operation.</param>
        /// <param name="inner">The inner exception that caused the current exception.</param>
        public ForbiddenException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
