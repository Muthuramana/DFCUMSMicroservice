using System.Collections.Generic;

namespace DFC.UMS.Microservice.Models
{
    public class JobProfile
    {
        public string Title { get; set; }
        public string UrlName { get; set; }

        public IEnumerable<string> TaskItems { get; set; }

        public IEnumerable<string> AbilityList { get; set; }

        public IEnumerable<string> SkillList { get; set; }

    }
}
