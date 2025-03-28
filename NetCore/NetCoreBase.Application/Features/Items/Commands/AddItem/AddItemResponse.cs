namespace NetCoreBase.Application.Features.Items.Commands.AddItem
{
    public class AddItemResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset Create { get; set; }
        public string? CreatedBy { get; set; }
    }
}