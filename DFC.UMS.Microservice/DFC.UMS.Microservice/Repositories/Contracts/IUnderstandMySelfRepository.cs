using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;

namespace DFC.UMS.Microservice.Repositories.Contracts
{
    public interface IUnderstandMySelfRepository
    {
        Task<StepDetail> GetStepByNumber(int number);
        Task SaveStepDetails(StepDetail stepDetail);
        Task SaveJobProfileAsync(JobProfile jobProfile);
        Task SaveAnswer(StepAnswer savedAnswer);
        Task<IEnumerable<StepAnswer>> GetStepsAnswersBySessionId(string sessionId);
    }
}
