namespace MVCNet.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int? ProfileId { get; set; }
        public Profile? Profile { get; set; }
    }
}
