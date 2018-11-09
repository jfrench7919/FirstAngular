using System.Collections.Generic;

namespace FirstAngular.Models
{
    public partial class Education
    {
        public Education()
        {
            PersonEducation = new HashSet<PersonEducation>();
        }

        public int Id { get; set; }
        public string Institution { get; set; }
        public int StartDateYear { get; set; }
        public int StartDateMonth { get; set; }
        public int? EndDateYear { get; set; }
        public int? EndDateMonth { get; set; }
        public string DiplomaTypes { get; set; }
        public string Phone { get; set; }

        public ICollection<PersonEducation> PersonEducation { get; set; }
    }
}