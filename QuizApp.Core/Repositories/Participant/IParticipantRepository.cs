﻿using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {
        Task<Participant> GetByEmail(string email);
        Task<Participant> GetParticipant(string email, string userName);
    }
}
