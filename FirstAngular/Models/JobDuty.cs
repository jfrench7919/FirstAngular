namespace FirstAngular.Models
{
    public partial class JobDuty
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int DutyId { get; set; }

        public Duty Duty { get; set; }
        public Job Job { get; set; }
    }
}