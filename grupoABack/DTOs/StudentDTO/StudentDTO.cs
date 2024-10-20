namespace grupoABack.DTOs.StudentDTO
{
    public class CreateStudentDTO
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string AcademicRegistration { get; set; }
        public string Email { get; set; }
    }

    public class UpdateStudentDTO : CreateStudentDTO
    {
        public Guid Id { get; set; }
    }
}
