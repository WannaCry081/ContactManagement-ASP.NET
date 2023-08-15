namespace backend.Exceptions
{
    /// <summary>
    /// Exception class to represent a contact not found error.
    /// </summary>
    public class ContactNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactNotFoundException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public ContactNotFoundException(string message) : base(message) { }
    }
}
