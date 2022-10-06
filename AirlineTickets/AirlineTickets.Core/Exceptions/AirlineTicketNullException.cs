using System.Runtime.Serialization;

namespace AirlineTickets.Core.Exceptions
{
    public class AirlineTicketNullException : Exception
    {
        public AirlineTicketNullException() { }

        public AirlineTicketNullException(string message) : base(message) { }

        public AirlineTicketNullException(string message, Exception innerException) : base(message, innerException) { }

        protected AirlineTicketNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
