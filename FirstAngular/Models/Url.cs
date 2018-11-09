using System.Collections.Generic;

namespace FirstAngular.Models
{
    public partial class Url
    {
        public Url()
        {
            PersonUrl = new HashSet<PersonUrl>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url1 { get; set; }

        public ICollection<PersonUrl> PersonUrl { get; set; }
    }
}