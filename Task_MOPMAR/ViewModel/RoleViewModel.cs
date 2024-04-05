using System.ComponentModel.DataAnnotations;

namespace Task_MOPMAR.ViewModel
{
    public class RoleViewModel
    {
        [Required,MaxLength(50)]
        public string RoleName { get; set; }
    }
}
