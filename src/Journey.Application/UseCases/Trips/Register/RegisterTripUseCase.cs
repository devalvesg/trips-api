using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.Exceptions;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure.Repository;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {

        private JourneyDbContext _context;

        public RegisterTripUseCase(JourneyDbContext context)
        {
           _context = context;
        }

        public ResponseShortTripJson Execute(RequestRegisterTripJson request)
        {

            Validate(request);

            var entity = new Infrastructure.Entities.Trip { Name = request.Name, StartDate = request.StartDate, EndDate = request.EndDate };

            _context.Trips.Add(entity);

            _context.SaveChanges();

            return new ResponseShortTripJson
            {
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Name = entity.Name,
                Id = entity.Id
            };
        }

        private void Validate(RequestRegisterTripJson request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new BadRequestException(ResourceMessageException.NameNotNull);
            }

            if(request.StartDate.Date < DateTime.UtcNow.Date)
            {
                throw new BadRequestException(ResourceMessageException.StartDateInvalid);
            }

            if(request.EndDate.Date < request.StartDate.Date)
            {
                throw new BadRequestException(ResourceMessageException.EndDateInvalid);
            }
        }
    }
}
