using MediatR;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using MvcRedArbor.Application.DTOs;
using MvcRedArbor.Infraestructure.Candidates.Queries;
using MvcRedArbor.Models;

namespace MvcRedArbor.Application.Handlers.CandidateHandler
{
    public class GetAllCandidateHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<CandidateDto>>
    {
        private readonly MvccrudContext _dbContext;
        public GetAllCandidateHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CandidateDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            var candidates = await _dbContext.Candidates.ToListAsync(cancellationToken);

            return candidates.Select(x => new CandidateDto
            {
                IdCandidate = x.IdCandidate,
                Name = x.Name,
                Surname = x.Surname,
                BirthDate = x.BirthDate,
                Email = x.Email,
                InsertDate = x.InsertDate,
                ModifyDate = x.ModifyDate
            });
        }
    }
}
