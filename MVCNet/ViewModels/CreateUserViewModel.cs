using System.ComponentModel.DataAnnotations;

namespace MVCNet.ViewModels
{
    public class CreateUserViewModel
    {
        [Display(Name = "Nombre")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Perfil")]
        [Required]
        public int ProfileId { get; set; }
    }
}
