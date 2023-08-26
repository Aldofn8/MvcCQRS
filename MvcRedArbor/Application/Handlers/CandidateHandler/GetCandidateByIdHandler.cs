using MediatR;
using Microsoft.AspNetCore.Routing.Matching;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.Candidates.Queries;
using MvcRedArbor.Models;

namespace MvcRedArbor.Application.Handlers.CandidateHandler
{
    public class GetCandidateByIdHandler : IRequestHandler<GetCandidateByIdQuery, CandidateDto>
    {
        private readonly MvccrudContext _dbContext;
        public GetCandidateByIdHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CandidateDto> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _dbContext.Candidates.FindAsync(new object[] { request.IdCandidate }, cancellationToken);

            if (candidate == null)
            {
                return null;
            }

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
