using System.Collections.Generic;

namespace FirstAngular.Models
{
    public partial class Location
    {
        public Location()
        {
            JobLocation = new HashSet<JobLocation>();
            PersonLocation = new HashSet<PersonLocation>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string CityCounty { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public ICollection<JobLocation> JobLocation { get; set; }
        public ICollection<PersonLocation> PersonLocation { get; set; }
    }
}