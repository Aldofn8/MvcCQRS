using MediatR;
using MvcRedArbor.Application.DTOs;

namespace MvcRedArbor.Infraestructure.Candidates.Queries
{
    public record GetCandidateByIdQuery(int IdCandidate) : IRequest<CandidateDto>;
}
