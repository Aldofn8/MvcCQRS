using MediatR;

namespace MvcRedArbor.Infraestructure.CandidateExperiences.Command
{
    public record DeleteCandidateExpCommand(int IdCandidateExperiences) : IRequest<bool>;
}
