using MediatR;
using MvcRedArbor.Application.DTOs;

namespace MvcRedArbor.Infraestructure.Candidates.Queries
{
    public record GetAllCandidatesQuery : IRequest<IEnumerable<CandidateDto>>;
}
