using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Service.Services.DTOs
{
    public class ParticipantDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int? Score { get; set; }
        public int? TimeTaken { get; set; }

        public virtual IList<ParticipantResultDto> ParticipantResults { get; set; }
    }
}
