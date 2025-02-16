

using System.ComponentModel.DataAnnotations;

namespace Okala.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    public long Id { get; set; }
}
