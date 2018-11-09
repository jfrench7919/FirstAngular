namespace FirstAngular.Models
{
    public partial class PersonEducation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int EducationId { get; set; }

        public Education Education { get; set; }
        public Person Person { get; set; }
    }
}