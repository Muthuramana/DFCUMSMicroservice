using System;
using DFC.UMS.Microservice.Models.Framework;

namespace DFC.UMS.Microservice.Models
{
    public class JobProfile : SelectedAnswerFilter
    {
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; }
        public string UrlName { get; set; }
        public string Overview { get; set; }
    }
}
