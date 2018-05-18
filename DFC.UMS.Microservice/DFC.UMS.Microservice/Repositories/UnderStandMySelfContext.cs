using DFC.UMS.Microservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DFC.UMS.Microservice.Repositories
{
    public class UnderStandMySelfContext : DbContext
    {

        public UnderStandMySelfContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public UnderStandMySelfContext(DbContextOptions options)
            : base(options)
        {
        }

        public IConfiguration Configuration { get; }

        public DbSet<StepAnswer> StepAnswers { get; set; }
        public DbSet<StepDetail> StepDetails { get; set; }
    }
}
