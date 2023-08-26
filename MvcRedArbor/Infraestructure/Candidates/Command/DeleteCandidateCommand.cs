using MediatR;

namespace MvcRedArbor.Infraestructure.Candidates.Command
{
    public record DeleteCandidateCommand(int IdCandidate) : IRequest<bool>;
}
