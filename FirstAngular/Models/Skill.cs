using System.Collections.Generic;

namespace FirstAngular.Models
{
    public partial class Skill
    {
        public Skill()
        {
            PersonSkill = new HashSet<PersonSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Years { get; set; }

        public ICollection<PersonSkill> PersonSkill { get; set; }
    }
}