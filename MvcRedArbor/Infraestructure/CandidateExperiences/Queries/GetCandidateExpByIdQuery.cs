using MediatR;
using MvcRedArbor.Application.DTOs;

namespace MvcRedArbor.Infraestructure.CandidateExperiences.Queries
{
    public record GetCandidateExpByIdQuery(int IdCandidateExperience) : IRequest<CandidateExperienceDto>;
}
