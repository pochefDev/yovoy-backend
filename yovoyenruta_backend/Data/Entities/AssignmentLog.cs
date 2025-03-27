using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

[Table("assignment_log")]
public partial class AssignmentLog
{
    [Key]
    public Guid id { get; set; }

    public Guid? route_id { get; set; }

    public Guid? vehicle_id { get; set; }

    public Guid? operator_id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? date { get; set; }

    [Column(TypeName = "text")]
    public string? reason { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? result { get; set; }

    [ForeignKey("operator_id")]
    [InverseProperty("assignment_logs")]
    public virtual Operator? _operator { get; set; }

    [ForeignKey("route_id")]
    [InverseProperty("assignment_logs")]
    public virtual Route? route { get; set; }

    [ForeignKey("vehicle_id")]
    [InverseProperty("assignment_logs")]
    public virtual Vehicle? vehicle { get; set; }
}
