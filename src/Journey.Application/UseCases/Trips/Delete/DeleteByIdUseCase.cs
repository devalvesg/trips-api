using Journey.Communication.Responses;
using Journey.Exception.Exceptions;
using Journey.Exception;
using Microsoft.EntityFrameworkCore;
using Journey.Infrastructure.Repository;

namespace Journey.Application.UseCases.Trips.Delete
{
    public class DeleteByIdUseCase
    {
        private JourneyDbContext _context;

        public DeleteByIdUseCase(JourneyDbContext context)
        {
            _context = context;
        }


        public void Execute(string id)
        {
            var trip = _context
                .Trips
                .Include(x => x.Activities)
                .FirstOrDefault(x => x.Id.ToString().Equals(id.ToUpper()));

            if (trip == null)
            {
                throw new NotFoundException(ResourceMessageException.TripNotFound);
            }

            _context.Trips.Remove(trip);
            _context.SaveChanges();
        }
    }
}
