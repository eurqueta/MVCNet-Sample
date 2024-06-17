using System.ComponentModel.DataAnnotations;

namespace MVCNet.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ProfileId {  get; set; }
    }
}
