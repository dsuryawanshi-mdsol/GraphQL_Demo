namespace GraphQL.Models
{
    /// <summary>
    /// Product data model
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int OrderId { get; set; }
    }
}
