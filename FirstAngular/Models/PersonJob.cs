namespace FirstAngular.Models
{
    public partial class PersonJob
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int JobId { get; set; }

        public Job Job { get; set; }
        public Person Person { get; set; }
    }
}