using System.Collections.Generic;
using DFC.UMS.Microservice.Models;

namespace DFC.UMS.Microservice.ViewModel
{
    public class ResultsViewModel
    {
        public string ResultsMessage { get; set; }

        public IEnumerable<JobProfile> JobProfiles { get; set; }
    }
}
