using NetCoreBase.Domain.Common;

namespace NetCoreBase.Domain.Entities
{
    public class Item : BaseFullEntity
    {
        public required string Name { get; set; }
    }
}
