
namespace KickNetLib.Api.Exceptions
{
    /// <summary>
    /// Custom exception to represent an "Internal Server Error" (500 status code).
    /// This exception can be used to signal server-related issues or unexpected conditions
    /// that occur during the processing of a request.
    /// </summary>
    public class InternalServerErrorException : Exception
    {
        /// <summary>
        /// Default constructor for the <see cref="InternalServerErrorException"/> class.
        /// This constructor is typically used when no specific error message or inner exception 
        /// is provided.
        /// </summary>
        public InternalServerErrorException()
        {
        }

        /// <summary>
        /// Constructor for the <see cref="InternalServerErrorException"/> class that accepts a custom error message.
        /// This allows you to provide more context about the error when it is thrown.
        /// </summary>
        /// <param name="message">A custom error message that provides details about the error.</param>
        public InternalServerErrorException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor for the <see cref="InternalServerErrorException"/> class that accepts both 
        /// a custom error message and an inner exception.
        /// This is useful for exception chaining, where the inner exception contains more information
        /// about the root cause of the error.
        /// </summary>
        /// <param name="message">A custom error message that provides more details about the error.</param>
        /// <param name="inner">The inner exception that caused the current exception.</param>
        public InternalServerErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
