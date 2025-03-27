using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Route
{
    [Key]
    public Guid id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? name { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? origin { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? destination { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? zone { get; set; }

    public Guid? terminal_id { get; set; }

    public bool? is_active { get; set; }

    [InverseProperty("route")]
    public virtual ICollection<AssignmentLog> assignment_logs { get; set; } = new List<AssignmentLog>();

    [InverseProperty("route")]
    public virtual ICollection<OperatorPreference> operator_preferences { get; set; } = new List<OperatorPreference>();

    [InverseProperty("route")]
    public virtual ICollection<Shift> shifts { get; set; } = new List<Shift>();

    [ForeignKey("terminal_id")]
    [InverseProperty("routes")]
    public virtual Terminal? terminal { get; set; }

    [InverseProperty("route")]
    public virtual ICollection<Trip> trips { get; set; } = new List<Trip>();
}
