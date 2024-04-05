namespace Task_MOPMAR.Models
{
    public class Employee
    { 
        public int Id { get; set; }

        [Required(ErrorMessage = "National ID is required")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "National ID must be 14 characters")]
        [RegularExpression(@"^[23]\d{13}$", ErrorMessage = "Invalid National ID")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle name is required")]
        [StringLength(50, ErrorMessage = "Middle name cannot exceed 50 characters")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(5000, 10000, ErrorMessage = "Salary must be between 5000 and 10000")]
        public decimal Salary { get; set; }

        public int GovernorateId { get; set; }
        public int CenterId { get; set; }
        public int VillageId { get; set; }

        public Governorate Governorate { get; set; }
        public Center Center { get; set; }
        public Village Village { get; set; }
    }
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
}

