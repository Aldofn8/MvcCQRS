using MediatR;
using Microsoft.AspNetCore.Mvc;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.Candidates.Queries;
using MvcRedArbor.Infraestructure.Candidates.Command;
using MvcRedArbor.Infraestructure.CandidateExperiences.Command;

namespace MvcRedArbor.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IEnumerable<CandidateDto>> Index()
        {
            return await _mediator.Send(new GetAllCandidatesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDto>> Details(int id)
        {
            var query = new GetCandidateByIdQuery(id);
            var candidates = await _mediator.Send(query);

            if (candidates == null)
            {
                return NotFound();
            }

            return candidates;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CandidateDto>> Create(CreateCandidateCommand command)
        {
            var candidate = await _mediator.Send(command);
            return CreatedAtAction(nameof(Details), new { IdCandidate = candidate.IdCandidate }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, UpdateCandidateCommand command)
        {
            if (id != command.IdCandidate)
            {
                return BadRequest();
            }

            var candidate = await _mediator.Send(command);
            if (candidate == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCandidateCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
