using System.ComponentModel.DataAnnotations;

namespace Task_MOPMAR.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PAssword { get; set; }
        public bool RememberMe { get; set; }
    }
}
