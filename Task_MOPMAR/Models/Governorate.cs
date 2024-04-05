namespace Task_MOPMAR.Models
{
    public class Governorate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Governorate name is required")]
        [StringLength(50, ErrorMessage = "Governorate name cannot exceed 50 characters")]
        public string Name { get; set; }
        public ICollection<Center> Centers { get; set; }
    }
}
