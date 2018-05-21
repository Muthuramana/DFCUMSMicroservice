using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace DFC.UMS.Microservice.Models
{
    public class StepAnswer
    {
        [BsonId]
        public Guid Id { get; set; } = new Guid();
        public int QuestionId { get; set; }

        public IEnumerable<string> SavedAnswers { get; set; }

        public string SessionId { get; set; }

        public string FrameworkItemType { get; set; }
    }
}
