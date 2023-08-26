using MediatR;
using Microsoft.EntityFrameworkCore;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.CandidateExperiences.Queries;
using MvcRedArbor.Models;

namespace MvcRedArbor.Application.Handlers.CandidateExperienceHandler
{
    public class GetAllCandidateExpHandler : IRequestHandler<GetAllCandidateExpQuery, IEnumerable<CandidateExperienceDto>>
    {
        private readonly MvccrudContext _dbContext;
        public GetAllCandidateExpHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CandidateExperienceDto>> Handle(GetAllCandidateExpQuery request, CancellationToken cancellationToken)
        {
            var candidatesExp = await _dbContext.CandidateExperiences.ToListAsync(cancellationToken);

            return candidatesExp.Select(x => new CandidateExperienceDto
            {
                IdCandidateExperiences = x.IdCandidateExperiences,
                IdCandidate = x.IdCandidate,
                Company = x.Company,
                Job = x.Job,
                Description = x.Description,
                Salary = x.Salary,
                BeginDate = x.BeginDate,
                EndDate = x.EndDate,
                InsertDate = x.InsertDate,
                ModifyDate = x.ModifyDate
            });
        }
    }
}
