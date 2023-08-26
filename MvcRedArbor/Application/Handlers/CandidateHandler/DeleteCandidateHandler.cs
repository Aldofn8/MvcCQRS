using MediatR;
using MvcRedArbor.Infraestructure.Candidates.Command;
using MvcRedArbor.Models;

namespace MvcRedArbor.Application.Handlers.CandidateHandler
{
    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateCommand, bool>
    {
        private readonly MvccrudContext _dbContext;
        public DeleteCandidateHandler(MvccrudContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _dbContext.Candidates.FindAsync(new object[] { request.IdCandidate }, cancellationToken);

            if (candidate == null)
            {
                return false;
            }

            _dbContext.Candidates.Remove(candidate);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
