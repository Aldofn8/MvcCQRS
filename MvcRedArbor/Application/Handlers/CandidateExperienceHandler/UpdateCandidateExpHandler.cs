using MediatR;
using Microsoft.AspNetCore.Routing.Matching;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.CandidateExperiences.Command;
using MvcRedArbor.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MvcRedArbor.Application.Handlers.CandidateExperienceHandler
{
    public class UpdateCandidateExpHandler : IRequestHandler<UpdateCandidateExpCommand, CandidateExperienceDto>
    {
        private readonly MvccrudContext _dbContext;
        public UpdateCandidateExpHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CandidateExperienceDto> Handle(UpdateCandidateExpCommand request, CancellationToken cancellationToken)
        {
            var candidatesExp = await _dbContext.CandidateExperiences.FindAsync(new object[] { request.IdCandidateExperiences }, cancellationToken);

            if (candidatesExp == null)
            {
                return null;
            }

            candidatesExp.IdCandidateExperiences = request.IdCandidateExperiences;
            candidatesExp.IdCandidate = request.IdCandidate;
            candidatesExp.Company = request.Company;
            candidatesExp.Job = request.Job;
            candidatesExp.Description = request.Description;
            candidatesExp.Salary = request.Salary;
            candidatesExp.BeginDate = request.BeginDate;
            candidatesExp.EndDate = request.EndDate;
            candidatesExp.InsertDate = request.InsertDate;
            candidatesExp.ModifyDate = request.ModifyDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CandidateExperienceDto
            {
                IdCandidateExperiences = candidatesExp.IdCandidateExperiences,
                IdCandidate = candidatesExp.IdCandidate,
                Company = candidatesExp.Company,
                Job = candidatesExp.Job,
                Description = candidatesExp.Description,
                Salary = candidatesExp.Salary,
                BeginDate = candidatesExp.BeginDate,
                EndDate = candidatesExp.EndDate,
                InsertDate = candidatesExp.InsertDate,
                ModifyDate = candidatesExp.ModifyDate
            };
        }
    }
}
