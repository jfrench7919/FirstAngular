using System.Collections.Generic;

namespace FirstAngular.Models
{
    public partial class Person
    {
        public Person()
        {
            JobManager = new HashSet<JobManager>();
            PersonCert = new HashSet<PersonCert>();
            PersonEducation = new HashSet<PersonEducation>();
            PersonJob = new HashSet<PersonJob>();
            PersonLocation = new HashSet<PersonLocation>();
            PersonReferencePerson = new HashSet<PersonReference>();
            PersonReferenceRefPerson = new HashSet<PersonReference>();
            PersonSkill = new HashSet<PersonSkill>();
            PersonUrl = new HashSet<PersonUrl>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }

        public ICollection<JobManager> JobManager { get; set; }
        public ICollection<PersonCert> PersonCert { get; set; }
        public ICollection<PersonEducation> PersonEducation { get; set; }
        public ICollection<PersonJob> PersonJob { get; set; }
        public ICollection<PersonLocation> PersonLocation { get; set; }
        public ICollection<PersonReference> PersonReferencePerson { get; set; }
        public ICollection<PersonReference> PersonReferenceRefPerson { get; set; }
        public ICollection<PersonSkill> PersonSkill { get; set; }
        public ICollection<PersonUrl> PersonUrl { get; set; }
    }
}