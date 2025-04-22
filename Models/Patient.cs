namespace HospitalPortal.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Age => DateTime.Now.Year - Dob.Year - (DateTime.Now.DayOfYear < Dob.DayOfYear ? 1 : 0);

    }

}
