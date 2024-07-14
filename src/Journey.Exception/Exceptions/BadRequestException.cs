using Journey.Exception.ExceptionsBase;
using System.Net;

namespace Journey.Exception.Exceptions
{
    public class BadRequestException : JourneyException
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
