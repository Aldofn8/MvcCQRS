using MediatR;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.CandidateExperiences.Queries;
using MvcRedArbor.Models;

namespace MvcRedArbor.Application.Handlers.CandidateExperienceHandler
{
    public class GetCandidateExpByIdHandler : IRequestHandler<GetCandidateExpByIdQuery, CandidateExperienceDto>
    {
        private readonly MvccrudContext _dbContext;
        public GetCandidateExpByIdHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CandidateExperienceDto> Handle(GetCandidateExpByIdQuery request, CancellationToken cancellationToken)
        {
            var candidateExp = await _dbContext.CandidateExperiences.FindAsync(new object[] { request.IdCandidateExperience }, cancellationToken);

            if (candidateExp == null)
            {
                return null;
            }

            return new CandidateExperienceDto
            {
                IdCandidateExperiences = candidateExp.IdCandidateExperiences,
                IdCandidate = candidateExp.IdCandidate,
                Company = candidateExp.Company,
                Job = candidateExp.Job,
                Description = candidateExp.Description,
                Salary = candidateExp.Salary,
                BeginDate = candidateExp.BeginDate,
                EndDate = candidateExp.EndDate,
                InsertDate = candidateExp.InsertDate,
                ModifyDate = candidateExp.ModifyDate
            };
        }
    }
}
