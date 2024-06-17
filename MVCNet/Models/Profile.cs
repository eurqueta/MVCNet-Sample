namespace MVCNet.Models
{
    public class Profile()
    {
        public int IdProfile { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
