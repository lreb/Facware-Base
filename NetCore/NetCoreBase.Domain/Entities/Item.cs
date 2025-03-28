using NetCoreBase.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace NetCoreBase.Domain.Entities
{
    public class Item : BaseFullEntity
    {
        //[StringLength(100)]
        public required string Name { get; set; }
        //[StringLength(250)]
        public required string Description { get; set; }
        //[Required]
        public required decimal Price { get; set; }

    }
}
