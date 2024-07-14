using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.Exceptions;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Get
{
    public class GetTripByIdUseCase
    {
        private JourneyDbContext _context;

        public GetTripByIdUseCase(JourneyDbContext context)
        {
            _context = context;
        }


        public ResponseTripJson Execute(string id)
        {
            var trip = _context
                .Trips
                .Include(x => x.Activities)
                .FirstOrDefault(x => x.Id.ToString().Equals(id.ToUpper()));



            if (trip == null)
            {
                throw new NotFoundException(ResourceMessageException.TripNotFound);
            }

            return new ResponseTripJson
            {
                Id = trip.Id,
                Name = trip.Name,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                Activities = trip.Activities.Select(X => new ResponseActivityJson { Id = X.Id, Name = X.Name, Date = X.Date, Status = (Communication.Enums.ActivityStatus)X.Status }).ToList()
            };

        }
    }
}
