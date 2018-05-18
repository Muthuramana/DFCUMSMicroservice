using System.Collections.Generic;

namespace DFC.UMS.Microservice.Models
{
    public class StepDetail 
    {
        public int QuestionId { get; set; }
        public string QuestionDesciption { get; set; }
        public IEnumerable<string> Answers { get; set; }
    }
}
