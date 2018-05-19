using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
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

        public UnderStandMySelfMongoRepository(IConfiguration configuration)
        {
            var mongoCs = configuration["mongo-cs"];
            var client = new MongoClient(mongoCs);
            mongoDatabase = client.GetDatabase("SFMicroservices");
            jobprofileCollection = mongoDatabase.GetCollection<JobProfile>(nameof(JobProfile));
            stepAnswerCollection = mongoDatabase.GetCollection<StepAnswer>(nameof(StepAnswer));
            stepDetailCollection = mongoDatabase.GetCollection<StepDetail>(nameof(JobProfile));

        }
        public async Task<StepDetail> GetStepByNumber(int number)
        {
            return await stepDetailCollection.FindAsync(stepdetail => stepdetail.QuestionId.Equals(number)).Result.FirstOrDefaultAsync();
        }

        public async Task SaveStepDetails(StepDetail stepDetail)
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
        public async Task SaveAnswer(StepAnswer savedAnswer)
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
    }
}
