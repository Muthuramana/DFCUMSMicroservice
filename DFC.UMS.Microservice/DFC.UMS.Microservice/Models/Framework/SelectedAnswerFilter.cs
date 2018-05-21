using System.Collections.Generic;

namespace DFC.UMS.Microservice.Models.Framework
{
    public class SelectedAnswerFilter
    {
        public IEnumerable<string> TaskItems { get; set; } = new List<string>();

        public IEnumerable<string> AbilityList { get; set; } = new List<string>();

        public IEnumerable<string> SkillList { get; set; } = new List<string>();
    }
}
