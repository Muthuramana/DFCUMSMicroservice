using System.Collections.Generic;
using DFC.UMS.Microservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace DFC.UMS.Microservice.ViewModel
{
    public class StepViewModel
    {
        public StepAnswer SavedAnswer { get; set; } = new StepAnswer();
       
        public StepDetail Step { get; set; } = new StepDetail();

        public IEnumerable<string> Answers { get; set; }
    }
}
