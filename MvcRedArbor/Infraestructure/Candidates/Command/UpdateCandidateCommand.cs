using MediatR;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Models;

namespace MvcRedArbor.Infraestructure.Candidates.Command
{
    public record UpdateCandidateCommand(int IdCandidate, string Name, string Surname, DateTime BirthDate, string Email, DateTime InsertDate, 
        DateTime ModifyDate) : IRequest<CandidateDto>;
}
