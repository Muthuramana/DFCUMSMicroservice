using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace DFC.UMS.Microservice.Models
{
    public class StepDetail 
    {
        [BsonId]
        public int QuestionId { get; set; }
        public string QuestionDescription { get; set; }
        public string FrameworkItemType { get; set; }

    }
}
