namespace NetCoreBase.Application.Features.Items.Queries.GetAllItems
{
    public class GetAllItemsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}