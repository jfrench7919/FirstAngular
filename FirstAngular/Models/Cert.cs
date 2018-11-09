using System.Collections.Generic;

namespace FirstAngular.Models
{
    public partial class Cert
    {
        public Cert()
        {
            PersonCert = new HashSet<PersonCert>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ExpirationYear { get; set; }
        public int ExpirationMonth { get; set; }

        public ICollection<PersonCert> PersonCert { get; set; }
    }
}