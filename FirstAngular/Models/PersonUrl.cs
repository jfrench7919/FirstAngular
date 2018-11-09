namespace FirstAngular.Models
{
    public partial class PersonUrl
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int UrlId { get; set; }

        public Person Person { get; set; }
        public Url Url { get; set; }
    }
}