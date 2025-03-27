using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yovoyenruta_backend.Data.Entities;

public partial class OperatorAchievement
{
    [Key]
    public Guid id { get; set; }

    public Guid? operator_id { get; set; }

    public Guid? achievement_id { get; set; }

    public DateOnly? obtained_date { get; set; }

    public int? percentage { get; set; }

    [ForeignKey("operator_id")]
    [InverseProperty("operator_achievements")]
    public virtual Operator? _operator { get; set; }

    [ForeignKey("achievement_id")]
    [InverseProperty("operator_achievements")]
    public virtual Achievement? achievement { get; set; }
}
