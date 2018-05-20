using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Models.Framework;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DFC.UMS.Microservice.Repositories
{
    public class UnderStandMySelfMongoRepository : IUnderstandMySelfRepository
    {
        private readonly IMongoDatabase mongoDatabase;
        private readonly IMongoCollection<JobProfile> jobprofileCollection;
        private readonly IMongoCollection<StepAnswer> stepAnswerCollection;
        private readonly IMongoCollection<StepDetail> stepDetailCollection;
        private readonly IMongoCollection<TaskItem> taskCollection;
        private readonly IMongoCollection<Skill> skillCollection;
        private readonly IMongoCollection<Ability> abilityCollection;

        public UnderStandMySelfMongoRepository(IConfiguration configuration)
        {
            var mongoCs = configuration["mongo-cs"];
            var client = new MongoClient(mongoCs);
            mongoDatabase = client.GetDatabase("UMSMicroService");
            jobprofileCollection = mongoDatabase.GetCollection<JobProfile>(nameof(JobProfile));
            stepAnswerCollection = mongoDatabase.GetCollection<StepAnswer>(nameof(StepAnswer));
            stepDetailCollection = mongoDatabase.GetCollection<StepDetail>(nameof(StepDetail));
            taskCollection = mongoDatabase.GetCollection<TaskItem>(nameof(TaskItem));
            skillCollection = mongoDatabase.GetCollection<Skill>(nameof(Skill));
            abilityCollection = mongoDatabase.GetCollection<Ability>(nameof(Ability));

        }
        public async Task<StepDetail> GetStepByNumberAsync(int number)
        {
            var result = await stepDetailCollection.FindAsync(stepdetail => stepdetail.QuestionId.Equals(number));

            if (result != null)
            {
                return await result.FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task SaveStepDetailsAsync(StepDetail stepDetail)
        {
            var result = await stepDetailCollection.FindAsync(doc => doc.QuestionId.Equals(stepDetail.QuestionId)).Result.FirstOrDefaultAsync();
            if (result == null)
            {
                await stepDetailCollection.InsertOneAsync(stepDetail);
            }
        }

        public async Task SaveJobProfileAsync(JobProfile jobProfile)
        {
            var result = await jobprofileCollection.FindAsync(doc => doc.UrlName.Equals(jobProfile.UrlName)).Result.FirstOrDefaultAsync();
            if (result == null)
            {
                await jobprofileCollection.InsertOneAsync(jobProfile);
            }
        }
        public async Task SaveAnswerAsync(StepAnswer savedAnswer)
        {
            var result = await stepAnswerCollection.FindAsync(doc => doc.QuestionId.Equals(savedAnswer.QuestionId) && doc.SessionId.Equals(savedAnswer.SessionId)).Result.FirstOrDefaultAsync();
            if (result == null)
            {
                await stepAnswerCollection.InsertOneAsync(savedAnswer);
            }
        }

        public async Task<IEnumerable<StepAnswer>> GetStepsAnswersBySessionId(string sessionId)
        {
            return await stepAnswerCollection.FindAsync(stepAnswer => stepAnswer.SessionId.Equals(sessionId)).Result.ToListAsync();
        }

        public async Task SaveTaskItemAsync(TaskItem taskItem)
        {
            var result = await taskCollection.FindAsync(doc => doc.Description.Equals(taskItem.Description)).Result.FirstOrDefaultAsync();
            if (result == null)
            {
                await taskCollection.InsertOneAsync(taskItem);
            }
        }

        public IEnumerable<TaskItem> GetAllTaskItems()
        {
          return taskCollection.AsQueryable();
        }

        public async Task SaveSkillAsync(Skill skill)
        {
            var result = await skillCollection.FindAsync(doc => doc.Description.Equals(skill.Description)).Result.FirstOrDefaultAsync();
            if (result == null)
            {
                await skillCollection.InsertOneAsync(skill);
            }
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return skillCollection.AsQueryable();
        }

        public async Task SaveAbilityAsync(Ability ability)
        {
            var result = await abilityCollection.FindAsync(doc => doc.Description.Equals(ability.Description)).Result.FirstOrDefaultAsync();
            if (result == null)
            {
                await abilityCollection.InsertOneAsync(ability);
            }
        }

        public IEnumerable<Ability> GetAllAbilities()
        {
            return abilityCollection.AsQueryable();
        }
    }
}
