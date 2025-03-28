using NetCoreBase.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace NetCoreBase.Domain.Entities
{
    public class Warehouse : BaseFullEntity
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required int Capacity { get; set; }
    }
}