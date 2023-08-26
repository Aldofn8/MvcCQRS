using MediatR;
using MvcRedArbor.Infraestructure.CandidateExperiences.Command;
using MvcRedArbor.Models;

namespace MvcRedArbor.Application.Handlers.CandidateExperienceHandler
{
    public class DeleteCandidateExpHandler : IRequestHandler<DeleteCandidateExpCommand, bool>
    {
        private readonly MvccrudContext _dbContext;
        public DeleteCandidateExpHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteCandidateExpCommand request, CancellationToken cancellationToken)
        {
            var candidateExp = await _dbContext.CandidateExperiences.FindAsync(new object[] { request.IdCandidateExperiences }, cancellationToken);

            if (candidateExp == null)
            {
                return false;
            }

            _dbContext.CandidateExperiences.Remove(candidateExp);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
