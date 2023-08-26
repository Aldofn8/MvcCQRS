using MediatR;
using Microsoft.AspNetCore.Routing.Matching;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.Candidates.Command;
using MvcRedArbor.Models;

namespace MvcRedArbor.Application.Handlers.CandidateHandler
{
    public class CreateCandidateHandler : IRequestHandler<CreateCandidateCommand, CandidateDto>
    {
        private readonly MvccrudContext _dbContext;
        public CreateCandidateHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CandidateDto> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidates = new Candidate
            {
                Name = request.Name,
                Surname = request.Surname,
                BirthDate = request.BirthDate,
                Email = request.Email,
                InsertDate = request.InsertDate,
                ModifyDate = request.ModifyDate
            };

            _dbContext.Candidates.Add(candidates);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new CandidateDto
            {
                IdCandidate = candidates.IdCandidate,
                Name = candidates.Name,
                Surname = candidates.Surname,
                BirthDate = candidates.BirthDate,
                Email = candidates.Email,
                InsertDate = candidates.InsertDate,
                ModifyDate = candidates.ModifyDate
            };
        }
    }
}
