namespace ShopCourses.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int CourseId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }

        public virtual Course Course { get; set; }
        public virtual Order Order { get; set; }
    }
}