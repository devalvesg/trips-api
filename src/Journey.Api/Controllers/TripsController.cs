using Journey.Application.UseCases.Activitys.Complete;
using Journey.Application.UseCases.Activitys.Delete;
using Journey.Application.UseCases.Activitys.Register;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.Get;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {

        private RegisterTripUseCase _registerUseCase;
        private GetAllTripsUseCase _getAllUseCase;
        private GetTripByIdUseCase _getByIdUseCase;
        private DeleteByIdUseCase _deleteByIdUseCase;
        private RegisterActivityUseCase _registerActivityUseCase;
        private CompleteActivityUseCase _completeActivityUseCase;
        private DeleteActivityUseCase _deleteActivityUseCase;

        public TripsController(
            RegisterTripUseCase registerUseCase,
            GetAllTripsUseCase getAllUseCase, 
            GetTripByIdUseCase getByIdUseCase, 
            DeleteByIdUseCase deleteByIdUseCase, 
            RegisterActivityUseCase registerActivityUseCase,
            CompleteActivityUseCase completeActivityUseCase,
            DeleteActivityUseCase deleteActivityUseCase)
        {
            _registerActivityUseCase = registerActivityUseCase;
            _registerUseCase = registerUseCase;
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
            _deleteByIdUseCase = deleteByIdUseCase;
            _completeActivityUseCase = completeActivityUseCase;
            _deleteActivityUseCase = deleteActivityUseCase;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _getAllUseCase.Execute();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterTripJson request)
        {
            var response = _registerUseCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var response = _getByIdUseCase.Execute(id);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            _deleteByIdUseCase.Execute(id);
            return NoContent();
        }

        [HttpPost]
        [Route("{tripId}/activity")]
        public IActionResult RegisterActivity([FromBody] RequestRegisterActivityJson request, [FromRoute] Guid tripId)
        {
            var response = _registerActivityUseCase.Execute(tripId, request);
            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{tripId}/activity/{activityId}")]
        public IActionResult CompleteActivity([FromRoute] Guid tripId, [FromRoute] Guid activityId)
        {
            _completeActivityUseCase.Execute(tripId, activityId);
            return NoContent();
        }

        [HttpDelete]
        [Route("{tripId}/activity/{activityId}")]
        public IActionResult DeleteActivity([FromRoute] Guid tripId, [FromRoute] Guid activityId)
        {
            _deleteActivityUseCase.Execute(tripId, activityId);
            return NoContent();
        }
    }
}
