using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception.Exceptions;
using Journey.Exception;
using Journey.Infrastructure.Entities;
using Journey.Infrastructure.Repository;

namespace Journey.Application.UseCases.Activitys.Complete
{
    public class CompleteActivityUseCase
    {
        private JourneyDbContext _context;

        public CompleteActivityUseCase(JourneyDbContext context)
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

            activity.Status = Infrastructure.Enums.ActivityStatus.Done;
            _context.Activities.Update(activity);
            _context.SaveChanges();
        }
    }
}
