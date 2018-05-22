using System.Collections.Generic;
using System.Threading.Tasks;
using DFC.UMS.Microservice.Models;
using DFC.UMS.Microservice.Models.Framework;
using DFC.UMS.Microservice.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DFC.UMS.Microservice.Pages
{
    public class LoadAllDataModel : PageModel
    {

        private readonly IUnderstandMySelfRepository understandMySelfRepository;

        public LoadAllDataModel(IUnderstandMySelfRepository understandMySelfRepository)
        {
            this.understandMySelfRepository = understandMySelfRepository;
        }
        public string LoadText { get; set; } = "Data being Loaded...";

        public IEnumerable<Ability> Abilities { get; set; } = new List<Ability>{ new Ability{Description = "problem solving" }, new Ability{ Description = "written comprehension"}, new Ability{ Description = "information ordering" }, new Ability{ Description = "arm- steadiness" }, new Ability { Description = "near vision" } };

        public IEnumerable<Skill> Skills { get; set; } = new List<Skill>{ new Skill{Description = "programming" }, new Skill{ Description = "systems analysis" }, new Skill{ Description = "decision making" }, new Skill{ Description = "active Listening" }, new Skill { Description = "speaking" } };

        public IEnumerable<TaskItem> TaskItems { get; set; } = new List<TaskItem> { new TaskItem { Description = "giving extra support to students with special needs" }, new TaskItem { Description = "systems analysis" }, new TaskItem { Description = "working with children one-to-one or in small groups" }, new TaskItem { Description = "giving first aid to accident victims" }, new TaskItem { Description = "giving complaint and emergency information to colleagues" } };

        public IEnumerable<JobProfile> JobProfiles { get; set; } = new List<JobProfile>{ new JobProfile {Title = "software developer", UrlName = "software-developer", Overview = "Software developers design, build and test computer programmes for business, education and leisure activities." , SkillList = new List<string>{ "programming","systems analysis"  }, AbilityList = new List<string>{ "information ordering" }, TaskItems = new List<string>() }, new JobProfile {Title = "Teaching assistant", UrlName = "Teaching-assistant", Overview = "Teaching assistants support teachers and help children develop.", SkillList = new List<string>{ "decision making", "active Listening" }, AbilityList = new List<string>{ "written comprehension" }, TaskItems = new List<string>{ "working with children one-to-one or in small groups" } }};

        public IEnumerable<StepDetail> StepDetails { get; set; } = new List<StepDetail>{ new StepDetail{QuestionId  = 1, QuestionDescription = "Skills you possess or can build on" , FrameworkItemType = nameof(Skill)}, new StepDetail { QuestionId = 3, QuestionDescription = "Tasks you would enjoy in the work environment", FrameworkItemType = nameof(TaskItem) } , new StepDetail { QuestionId = 2, QuestionDescription = "What would you be comfortable doing as part of your daily job", FrameworkItemType = nameof(Ability) } };

        public async Task OnGet()
        {
            foreach (var ability in Abilities)
            {
                await understandMySelfRepository.SaveAbilityAsync(ability);
            }

            foreach (var skill in Skills)
            {
                await understandMySelfRepository.SaveSkillAsync(skill);
            }

            foreach (var taskItem in TaskItems)
            {
                await understandMySelfRepository.SaveTaskItemAsync(taskItem);
            }

            foreach (var jobProfile in JobProfiles)
            {
                await understandMySelfRepository.SaveJobProfileAsync(jobProfile);
            }

            foreach (var stepDetail in StepDetails)
            {
                await understandMySelfRepository.SaveStepDetailsAsync(stepDetail);
            }

            Task.WaitAll();

            LoadText = "Data Loaded Succesfully";
        }
    }
}