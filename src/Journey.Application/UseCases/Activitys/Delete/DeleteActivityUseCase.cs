using Journey.Exception.Exceptions;
using Journey.Exception;
using Journey.Infrastructure.Repository;

namespace Journey.Application.UseCases.Activitys.Delete
{
    public class DeleteActivityUseCase
    {
        private JourneyDbContext _context;

        public DeleteActivityUseCase(JourneyDbContext context)
        {
            _context = context;
        }


        public void Execute(Guid tripId, Guid activityId)
        {
            var activity = _context.Activities
                .FirstOrDefault(activity => activity.Id == activityId && activity.TripId == tripId);

            if (activity == null)
            {
                throw new NotFoundException(ResourceMessageException.ActivityNotFound);
            }

            _context.Activities.Remove(activity);
            _context.SaveChanges();
        }
    }
}
