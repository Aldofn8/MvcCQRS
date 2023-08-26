using MediatR;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Models;

namespace MvcRedArbor.Infraestructure.CandidateExperiences.Command
{
    public record UpdateCandidateExpCommand(int IdCandidateExperiences, int IdCandidate, string Company, string Job, string Description, decimal Salary, DateTime BeginDate, DateTime? EndDate, DateTime InsertDate, 
        DateTime ModifyDate) : IRequest<CandidateExperienceDto>;
}
