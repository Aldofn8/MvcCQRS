using MediatR;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.CandidateExperiences.Command;
using MvcRedArbor.Models;

namespace MvcRedArbor.Application.Handlers.CandidateExperienceHandler
{
    public class CreateCandidateExpHandler : IRequestHandler<CreateCandidateExpCommand, CandidateExperienceDto>
    {
        private readonly MvccrudContext _dbContext;
        public CreateCandidateExpHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CandidateExperienceDto> Handle(CreateCandidateExpCommand request, CancellationToken cancellationToken)
        {
            var candidatesExp = new CandidateExperience
            {
                IdCandidate = request.IdCandidate,
                Company = request.Company,
                Job = request.Job,
                Description = request.Description,
                Salary = request.Salary,
                BeginDate = request.BeginDate,
                EndDate = request.EndDate,
                InsertDate = request.InsertDate,
                ModifyDate = request.ModifyDate,


            };

            _dbContext.CandidateExperiences.Add(candidatesExp);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CandidateExperienceDto
            {
                IdCandidate = candidatesExp.IdCandidate,
                Company = candidatesExp.Company,
                Job = candidatesExp.Job,
                Description = candidatesExp.Description,
                Salary = candidatesExp.Salary,
                BeginDate = candidatesExp.BeginDate,
                EndDate = candidatesExp.EndDate,
                InsertDate = candidatesExp.InsertDate,
                ModifyDate = candidatesExp.ModifyDate,
            };
        }
    }
}
