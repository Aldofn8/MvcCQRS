using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.CandidateExperiences.Command;
using MvcRedArbor.Infraestructure.CandidateExperiences.Queries;

namespace MvcRedArbor.Controllers
{
    public class CandidateExperiencesController : Controller
    {
        private readonly IMediator _mediator;

        public CandidateExperiencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CandidateExperienceDto>> Index()
        {
            return await _mediator.Send(new GetAllCandidateExpQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateExperienceDto>> Details(int id)
        {
            var query = new GetCandidateExpByIdQuery(id);
            var candidatesExp = await _mediator.Send(query);

            if (candidatesExp == null)
            {
                return NotFound();
            }

            return candidatesExp;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<CandidateExperienceDto>> Create(CreateCandidateExpCommand command)
        {
            var candidateExp = await _mediator.Send(command);
            return CreatedAtAction(nameof(Details), new { IdCandidateExperiences = candidateExp.IdCandidateExperiences }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, UpdateCandidateExpCommand command)
        {
            if (id != command.IdCandidateExperiences)
            {
                return BadRequest();
            }

            var candidateExperience = await _mediator.Send(command);
            if (candidateExperience == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCandidateExpCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
