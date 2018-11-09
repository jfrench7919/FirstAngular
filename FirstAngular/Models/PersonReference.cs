namespace FirstAngular.Models
{
    public partial class PersonReference
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RefPersonId { get; set; }

        public Person Person { get; set; }
        public Person RefPerson { get; set; }
    }
}