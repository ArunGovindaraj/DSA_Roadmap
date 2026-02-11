namespace DSA_Roadmap.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // Pending, Completed
        public DateTime CreatedOn { get; set; }
    }
}
