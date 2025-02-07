namespace NetCoreBase.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}