using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KrMicro.Core.Models.Abstraction;

public abstract class BaseModel
{
    [Key] [Column("id")] public short? Id { get; set; }
}

public abstract class BaseModelWithAudit : BaseModel
{
    [Column("created_at")] public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

public enum Status
{
    Available = 1,
    Disable = 0
}

public abstract class BaseModelWithTracking : BaseModel
{
    [Column("status")] public Status Status { get; set; }
}

public abstract class BaseModelWithAuditAndTracking : BaseModel
{
    [Column("created_at")] public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }

    [Column("status")] public Status? Status { get; set; }
}