namespace Task_MOPMAR.Models
{
    public class Village
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Village name is required")]
        [StringLength(50, ErrorMessage = "Village name cannot exceed 50 characters")]
        public string Name { get; set; }
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
        public int CenterId { get; set; }
        public Center Center { get; set; }
    }
}
