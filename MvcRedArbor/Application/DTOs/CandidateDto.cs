using MvcRedArbor.Models;

namespace MvcRedArbor.Application.DTOs
{
    public class CandidateDto
    {
        public int IdCandidate { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public string Email { get; set; } = null!;

        public DateTime InsertDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public virtual ICollection<CandidateExperience> CandidateExperiences { get; set; } = new List<CandidateExperience>();
    }
}
