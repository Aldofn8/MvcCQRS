using MediatR;
using Microsoft.AspNetCore.Routing.Matching;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.Candidates.Command;
using MvcRedArbor.Models;

namespace MvcRedArbor.Application.Handlers.CandidateHandler
{
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateCommand, CandidateDto>
    {
        private readonly MvccrudContext _dbContext;
        public UpdateCandidateHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CandidateDto> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _dbContext.Candidates.FindAsync(new object[] { request.IdCandidate }, cancellationToken);

            if (candidate == null)
            {
                return null;
            }

            candidate.Name = request.Name;
            candidate.Surname = request.Surname;
            candidate.BirthDate = request.BirthDate;
            candidate.Email = request.Email;
            candidate.InsertDate = request.InsertDate;
            candidate.ModifyDate = request.ModifyDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CandidateDto
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                BirthDate = candidate.BirthDate,
                Email = candidate.Email,
                InsertDate = candidate.InsertDate,
                ModifyDate = candidate.ModifyDate
            };
        }
    }
}
