namespace FirstAngular.Models
{
    public partial class PersonCert
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CertId { get; set; }

        public Cert Cert { get; set; }
        public Person Person { get; set; }
    }
}