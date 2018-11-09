namespace FirstAngular.Models
{
    public partial class JobLocation
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int LocationId { get; set; }

        public Job Job { get; set; }
        public Location Location { get; set; }
    }
}