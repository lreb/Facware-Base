using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreBase.Domain.Common
{
    /// <summary>
    /// Base entity class
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id of the entity
        /// </summary>
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
