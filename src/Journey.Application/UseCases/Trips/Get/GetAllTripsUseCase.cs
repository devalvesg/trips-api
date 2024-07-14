using Journey.Communication.Responses;
using Journey.Infrastructure.Repository;

namespace Journey.Application.UseCases.Trips.Get
{
    public class GetAllTripsUseCase
    {
        private JourneyDbContext _context;

        public GetAllTripsUseCase(JourneyDbContext context)
        {
            _context = context;
        }

        public ResponseTripsJson Execute()
        {
            var trips =  _context.Trips.ToList();

            return new ResponseTripsJson
            {
                Trips = trips.Select(trip => new ResponseShortTripJson
                {
                    Id = trip.Id,
                    EndDate = trip.EndDate,
                    Name = trip.Name,
                    StartDate = trip.StartDate,
                }).ToList()
            };
        }
    }
}
