using Journey.Communication.Enums;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.Exceptions;
using Journey.Infrastructure.Entities;
using Journey.Infrastructure.Repository;

namespace Journey.Application.UseCases.Activitys.Register
{
    public class RegisterActivityUseCase
    {
        private JourneyDbContext _context;

        public RegisterActivityUseCase(JourneyDbContext context)
        {
            _context = context;
        }


        public ResponseActivityJson Execute(Guid tripId, RequestRegisterActivityJson request)
        {
            var trip = _context.Trips
                .FirstOrDefault(trip => trip.Id == tripId);

            Validate(request, trip);

            var entity = new Activity
            {
                Name = request.Name,
                Date = request.Date,
                TripId = tripId
            };

            _context.Activities.Add(entity);
            _context.SaveChanges();

            return new ResponseActivityJson
            {
                Date = entity.Date,
                Id = entity.Id,
                Name = entity.Name,
                Status = (ActivityStatus)entity.Status
            };
        }

        private void Validate(RequestRegisterActivityJson request, Trip? trip)
        {
            if (trip == null)
            {
                throw new NotFoundException(ResourceMessageException.TripNotFound);
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                throw new BadRequestException(ResourceMessageException.NameNotNull);
            }

            if (request.Date.Date < trip.StartDate || request.Date.Date > trip.EndDate)
            {
                throw new BadRequestException(ResourceMessageException.ActivityDate);
            }
        }
    }
}
