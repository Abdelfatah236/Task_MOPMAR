namespace Task_MOPMAR.Models
{
    public class Center
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Center name is required")]
        [StringLength(50, ErrorMessage = "Center name cannot exceed 50 characters")]
        public string Name { get; set; }
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
        public ICollection<Village> Villages { get; set; }
    }
}
