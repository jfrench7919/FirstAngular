using System.Collections.Generic;

namespace FirstAngular.Models
{
    public partial class Duty
    {
        public Duty()
        {
            JobDuty = new HashSet<JobDuty>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<JobDuty> JobDuty { get; set; }
    }
}