using System.Collections.Generic;

namespace FirstAngular.Models
{
    public partial class Job
    {
        public Job()
        {
            JobDuty = new HashSet<JobDuty>();
            JobLocation = new HashSet<JobLocation>();
            JobManager = new HashSet<JobManager>();
            PersonJob = new HashSet<PersonJob>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int StartMonth { get; set; }
        public int? EndYear { get; set; }
        public int? EndMonth { get; set; }
        public string Description { get; set; }

        public ICollection<JobDuty> JobDuty { get; set; }
        public ICollection<JobLocation> JobLocation { get; set; }
        public ICollection<JobManager> JobManager { get; set; }
        public ICollection<PersonJob> PersonJob { get; set; }
    }
}