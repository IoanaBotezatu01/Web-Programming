namespace ProductsOrders.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string User { get; set; }
		public int ProductId { get; set; }
		public int	Quantity { get; set; }
		public Order() { }
		public Order( string user, int productId, int quantity)
		{
			User = user;
			ProductId = productId;
			Quantity = quantity;
		}
	}
}
