using MediatR;
using MvcRedArbor.Application.DTOs;

namespace MvcRedArbor.Infraestructure.CandidateExperiences.Queries
{
    public record GetAllCandidateExpQuery : IRequest<IEnumerable<CandidateExperienceDto>>;
}
