using Dance.Store.Application.Dtos.RequestDto;
using Dance.Store.Application.UseCases.Trainer.CreateTrainer;
using Dance.Store.Application.UseCases.Trainer.DeleteTrainer;
using Dance.Store.Application.UseCases.Trainer.GetAllTrainers;
using Dance.Store.Application.UseCases.Trainer.GetTrainerById;
using Dance.Store.Application.UseCases.Trainer.UpdateTrainer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dance.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTrainersAsync(CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetAllTrainersCommand(), cancellationToken));
        }

        [HttpGet("{trainerId}"), ]
        public async Task<IActionResult> GetTrainerByIdAsync(Guid trainerId, CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new GetTrainerByIdCommand(trainerId), cancellationToken));
        }
            
        [HttpPost]
        public async Task<IActionResult> CreateTrainerAsync([FromBody] TrainerRequestDto trainerRequestDto,
            CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(new CreateTrainerCommand(trainerRequestDto), cancellationToken));
        }

        [HttpPut("{trainerId}")]
        public async Task<IActionResult> UpdateStudentAsync(Guid trainerId,
            [FromBody] TrainerRequestDto trainerRequestDto, CancellationToken cancellationToken)
        {
            await sender.Send(new UpdateTrainerCommand(trainerId, trainerRequestDto), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{trainerId}")]
        public async Task<IActionResult> DeleteTrainerAsync(Guid trainerId, CancellationToken cancellationToken)
        {
            await sender.Send(new DeleteTrainerCommand(trainerId), cancellationToken);
            return NoContent();
        }
    }
}
