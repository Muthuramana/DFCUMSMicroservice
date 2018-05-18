using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;

namespace DFC.UMS.Microservice.Repositories.Contracts
{
    public interface IAnswerRepo
    {
        StepDetail GetStepByNumber(int number);

       Task<bool> SaveAnswer(StepAnswer savedAnswer);

        IQueryable<StepAnswer> GetStepsAnswersBySessionId(string sessionId);
    }
}
