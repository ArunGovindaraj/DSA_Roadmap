namespace DSARoadmap.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; }
    }
}
