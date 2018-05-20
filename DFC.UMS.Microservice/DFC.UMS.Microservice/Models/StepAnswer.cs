using System.Collections.Generic;

namespace DFC.UMS.Microservice.Models
{
    public class StepAnswer
    {
        public int QuestionId { get; set; }

        public IEnumerable<string> SavedAnswers { get; set; }

        public string SessionId { get; set; }
    }
}
