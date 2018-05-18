using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.Extensions.Configuration;

namespace DFC.UMS.Microservice.Repositories
{
    public class AnswerRepository : IAnswerRepo
    {
        private readonly UnderStandMySelfContext underStandMySelfContext;

        public AnswerRepository(IConfiguration configuration)
        {
            underStandMySelfContext = new UnderStandMySelfContext(configuration);
        }
        public StepDetail GetStepByNumber(int number)
        {
            return new StepDetail
            {
                QuestionId = number,
                Answers = new List<string> {"cooking", "painting", "travelling"},
                QuestionDesciption = "Favourite work activities"
            };
        }

        public async Task<bool> SaveAnswer(StepAnswer savedAnswer)
        {
            return await Task.FromResult(true);
        }

        public IQueryable<StepAnswer> GetStepsAnswersBySessionId(string sessionId)
        {
            return underStandMySelfContext.StepAnswers.Where(stepAnswer => stepAnswer.SessionId.Equals(sessionId));
        }
    }
}
