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

        public IEnumerable<Ability> Abilities { get; set; } = new List<Ability>
        {
            new Ability {Description = "problem solving"},
            new Ability {Description = "written comprehension"},
            new Ability {Description = "information ordering"},
            new Ability {Description = "arm- steadiness"},
            new Ability {Description = "near vision"},
            new Ability {Description = "the ability to remain calm under pressure at busy times"}
        };

        public IEnumerable<Skill> Skills { get; set; } = new List<Skill>
        {
            new Skill {Description = "programming"},
            new Skill {Description = "systems analysis"},
            new Skill {Description = "decision making"},
            new Skill {Description = "active Listening"},
            new Skill {Description = "speaking"},
            new Skill {Description = "initiative and teamworking skills"}
        };

        public IEnumerable<TaskItem> TaskItems { get; set; } = new List<TaskItem>
        {
            new TaskItem {Description = "giving extra support to students with special needs"},
            new TaskItem {Description = "systems analysis"},
            new TaskItem {Description = "working with children one-to-one or in small groups"},
            new TaskItem {Description = "giving first aid to accident victims"},
            new TaskItem {Description = "giving complaint and emergency information to colleagues"},
            new TaskItem {Description = "greeting customers as they arrive and showing them to their table"},
            new TaskItem {Description = "giving out menus and taking orders for food and drink"},
            new TaskItem {Description = "measuring out large quantities of ingredients"},
            new TaskItem {Description = "keeping eating and serving areas clean and tidy"},
            new TaskItem {Description = "encouraging them to talk about emotional or relationship problems"},
            new TaskItem {Description = "dispensing medicines in a high street or supermarket pharmacy"},
            new TaskItem {Description = "using electric shock equipment (a defibrillator) to resuscitate patients"},
            new TaskItem {Description = "questioning passengers about their travel plans, and deciding if they need further questioning"},
            new TaskItem {Description = "completing procedures when guests arrive and leave"},
            new TaskItem {Description = "work at national and international conferences, lectures and meetings"},
            new TaskItem {Description = "excellent organisational and time management skills"},
            new TaskItem {Description = "You may mark changes needed using British Standards Institution symbols or specialist software"},
            new TaskItem {Description = "interviewing parents and relatives after a birth or death"},
            new TaskItem {Description = "communicating and implementing business, marketing and sales plans"},
            new TaskItem {Description = "developing market research surveys and working with customers in focus groups"},
            new TaskItem {Description = "research and analytical skills for looking at financial markets and products"},
            new TaskItem {Description = "researching and analysing market trends and your target markets"},
            new TaskItem {Description = "researching markets and the latest trading figures"},
            new TaskItem {Description = "developing market research surveys and working with customers in focus groups"},
            new TaskItem {Description = "research and analytical skills for looking at financial markets and products"},
            new TaskItem {Description = "researching and analysing market trends and your target markets"},
            new TaskItem {Description = "researching markets and the latest trading figures"},
            new TaskItem {Description = "demonstrating tooth brushing and flossing to individuals and groups"},
            new TaskItem {Description = "helping patients shower and get dressed"},
            new TaskItem {Description = "giving pregnant women advice on issues like healthy eating"},
            new TaskItem {Description = "talking through requirements with the client and the development team" }
        };

        public IEnumerable<JobProfile> JobProfiles { get; set; } = GetJobProfiles();

        public IEnumerable<StepDetail> StepDetails { get; set; } = new List<StepDetail>
        {
            new StepDetail
            {
                QuestionId = 1,
                QuestionDescription = "Skills you possess or can build on",
                FrameworkItemType = nameof(Skill)
            },
            new StepDetail
            {
                QuestionId = 3,
                QuestionDescription = "Tasks you would enjoy in the work environment",
                FrameworkItemType = nameof(TaskItem)
            },
            new StepDetail
            {
                QuestionId = 2,
                QuestionDescription = "What would you be comfortable doing as part of your daily job",
                FrameworkItemType = nameof(Ability)
            }
        };

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

        private static IEnumerable<JobProfile> GetJobProfiles()
        {
            return new List<JobProfile>
            {
                new JobProfile
                {
                    Title = "software developer",
                    UrlName = "software-developer",
                    Overview =
                        "Software developers design, build and test computer programmes for business, education and leisure activities.",
                    SkillList = new List<string> {"programming", "systems analysis"},
                    AbilityList = new List<string> {"information ordering", "the ability to remain calm under pressure at busy times"},
                    TaskItems = new List<string> { "talking through requirements with the client and the development team" }
                },
                new JobProfile
                {
                    Title = "Teaching assistant",
                    UrlName = "Teaching-assistant",
                    Overview = "Teaching assistants support teachers and help children develop.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> {"working with children one-to-one or in small groups"}
                },
                new JobProfile
                {
                    Title = "Border Force officer",
                    UrlName = "border-force-officer",
                    Overview =
                        "Border Force officers protect UK border entry points like ports and airports, by enforcing immigration and customs regulations.",
                    SkillList = new List<string> { "decision making", "active Listening"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string>() { "questioning passengers about their travel plans, and deciding if they need further questioning" }
                },
                new JobProfile
                {
                    Title = "Hotel receptionist",
                    UrlName = "hotel-receptionist",
                    Overview = "Hotel receptionists make guests feel welcome, manage room bookings (reservations) and deal with requests from guests.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> { "completing procedures when guests arrive and leave" }
                },
                new JobProfile
                {
                    Title = "Interpreter",
                    UrlName = "interpreter",
                    Overview =
                        "Interpreters convert the spoken word from one language into another, either face-to-face or remotely.",
                    SkillList = new List<string> { "systems analysis"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string>() { "work at national and international conferences, lectures and meetings" }
                },
                new JobProfile
                {
                    Title = "Personal assistant",
                    UrlName = "personal-assistant",
                    Overview = "Personal assistants give secretarial and administrative support to managers.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> { "excellent organisational and time management skills" }
                },
                new JobProfile
                {
                    Title = "Proofreader",
                    UrlName = "proofreader",
                    Overview =
                        "Proofreaders check text before it&#39;s printed or published to make sure it&#39;s correct and complete.",
                    SkillList = new List<string> { "systems analysis"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string>() { "You may mark changes needed using British Standards Institution symbols or specialist software" }
                },
                new JobProfile
                {
                    Title = "Registrar of births, deaths, marriages and civil partnerships",
                    UrlName = "registrar-of-births-deaths-marriages-and-civil-partnerships",
                    Overview = "Registrars collect and record details of all births, deaths, marriages and civil partnerships.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> { "interviewing parents and relatives after a birth or death" }
                },
                new JobProfile
                {
                    Title = "Bank manager",
                    UrlName = "bank-manager",
                    Overview =
                        "Bank managers oversee the day-to-day operations of their branch, supervise staff and work to attract new customers.",
                    SkillList = new List<string> { "systems analysis"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string> { "communicating and implementing business, marketing and sales plans" }
                },
                new JobProfile
                {
                    Title = "Digital marketer",
                    UrlName = "digital-marketer",
                    Overview = "Online marketing executive, digital marketing executive, internet marketing officer, digital marketing officer",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> { "developing market research surveys and working with customers in focus groups" }
                },
                new JobProfile
                {
                    Title = "Financial adviserr",
                    UrlName = "financial-adviser",
                    Overview =
                        "Financial advisers help people and organisations to choose investments, savings, pensions, mortgages or insurance products.",
                    SkillList = new List<string> { "decision making", "systems analysis"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string> { "research and analytical skills for looking at financial markets and products" }
                },
                new JobProfile
                {
                    Title = "Marketing manager",
                    UrlName = "marketing-manager",
                    Overview = "Marketing managers plan how to promote products, services or brands and oversee all marketing activity.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> { "researching and analysing market trends and your target markets" }
                },
                new JobProfile
                {
                    Title = "Stockbroker",
                    UrlName = "stockbroker",
                    Overview =
                        "Stockbrokers manage their clients&#39; investments by trading stocks, shares and other financial products to get the best return.",
                    SkillList = new List<string> { "systems analysis"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string> { "researching markets and the latest trading figures" }
                },
                new JobProfile
                {
                    Title = "Dental hygienist",
                    UrlName = "dental-hygienist",
                    Overview = "Dental hygienists offer advice, information and treatments to prevent and treat tooth decay and gum disease.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> { "demonstrating tooth brushing and flossing to individuals and groups" }
                },
                new JobProfile
                {
                    Title = "GP",
                    UrlName = "gp",
                    Overview =
                        "General practitioners (GPs) are doctors who provide medical services to people in their practice.",
                    SkillList = new List<string> {"active listening", "systems analysis"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string> { "eferring patients to specialist consultants for tests and further diagnosis" }
                },
                new JobProfile
                {
                    Title = "Healthcare assistant",
                    UrlName = "healthcare-assistant",
                    Overview = "Healthcare assistants help look after patients in hospitals or in patients’ own homes.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> { "helping patients shower and get dressed" }
                },
                new JobProfile
                {
                    Title = "Midwife",
                    UrlName = "midwife",
                    Overview =
                        "Midwives support pregnant women and their babies before, during and after, childbirth.",
                    SkillList = new List<string> {"active listening", "speaking"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string>{ "giving pregnant women advice on issues like healthy eating" }
                },
                new JobProfile
                {
                    Title = "Paramedic",
                    UrlName = "paramedic",
                    Overview = "Paramedics deal with emergencies, giving people life-saving medical help.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> { "using electric shock equipment (a defibrillator) to resuscitate patients" }
                }
                ,
                new JobProfile
                {
                    Title = "Pharmacist",
                    UrlName = "pharmacist",
                    Overview = "Pharmacists provide expert advice on the use and supply of medicines and medical appliances.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"written comprehension"},
                    TaskItems = new List<string> {"dispensing medicines in a high street or supermarket pharmacy"}
                },
                new JobProfile
                {
                    Title = "Psychotherapist",
                    UrlName = "psychotherapist",
                    Overview =
                        "Psychotherapists use talking techniques and therapies to help people who are distressed, or have mental health problems.",
                    SkillList = new List<string> {"speaking", "active listening"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string> { "encouraging them to talk about emotional or relationship problems" }
                },
                new JobProfile
                {
                    Title = "Baker",
                    UrlName = "baker",
                    Overview = "Bakers make bread, cakes and pastries using machines or by hand.",
                    SkillList = new List<string> {"decision making", "active Listening"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string> { "measuring out large quantities of ingredients" }
                },
                new JobProfile
                {
                    Title = "Counter service assistant",
                    UrlName = "counter-service-assistant",
                    Overview =
                        "Counter service assistants greet, serve and take payment from customers buying food and drink.",
                    SkillList = new List<string> {"active listening", "speaking"},
                    AbilityList = new List<string> {"information ordering"},
                    TaskItems = new List<string> { "keeping eating and serving areas clean and tidy" }
                },
                new JobProfile
                {
                    Title = "Waiting staff",
                    UrlName = "waiting-staff",
                    Overview = "Waiting staff serve customers in restaurants and cafes by taking orders and payment, serving food and preparing tables.",
                    SkillList = new List<string> { "active Listening", "initiative and teamworking skills"},
                    AbilityList = new List<string> {"written comprehension", "the ability to remain calm under pressure at busy times"},
                    TaskItems = new List<string> { "greeting customers as they arrive and showing them to their table", "giving out menus and taking orders for food and drink" }
                }
            };
        }
    }
}