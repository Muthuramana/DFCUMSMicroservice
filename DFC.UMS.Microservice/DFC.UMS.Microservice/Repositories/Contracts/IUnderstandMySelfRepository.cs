using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Models.Framework;

namespace DFC.UMS.Microservice.Repositories.Contracts
{
    public interface IUnderstandMySelfRepository
    {
        Task<StepDetail> GetStepByNumberAsync(int number);
        Task SaveStepDetailsAsync(StepDetail stepDetail);
        Task SaveJobProfileAsync(JobProfile jobProfile);
        Task SaveAnswerAsync(StepAnswer savedAnswer);
        Task<IEnumerable<StepAnswer>> GetStepsAnswersBySessionId(string sessionId);

        Task SaveTaskItemAsync(TaskItem taskItem);

        IEnumerable<TaskItem> GetAllTaskItems();

        Task SaveSkillAsync(Skill skill);

        IEnumerable<Skill> GetAllSkills();

        Task SaveAbilityAsync(Ability ability);

        IEnumerable<Ability> GetAllAbilities();
        IEnumerable<JobProfile> GetJobProfilesByFilter(SelectedAnswerFilter selectedAnswerFilter);
    }
}
