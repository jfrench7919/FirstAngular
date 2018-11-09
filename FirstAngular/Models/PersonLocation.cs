namespace FirstAngular.Models
{
    public partial class PersonLocation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }
        public Person Person { get; set; }
    }
}