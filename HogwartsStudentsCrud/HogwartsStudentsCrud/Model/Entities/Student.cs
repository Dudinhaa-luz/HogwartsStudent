using HogwartsStudentsCrud.Data.Enums;

namespace HogwartsStudentsCrud.Model.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public BloodStatusTypeEnum BloodStatus { get; set; }
        public string Nationality { get; set; }
        public DateTime EnrollmentYear { get; set; }
        public GenderEnum Gender { get; set; }
        public string Bogeyman { get; set; }
        public string Wand { get; set; }
        public string Patron { get; set; }
        public HousesEnum House { get; set; }
    }
}
