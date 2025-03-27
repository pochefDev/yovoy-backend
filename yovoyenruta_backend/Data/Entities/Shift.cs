using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Shift
{
    [Key]
    public Guid id { get; set; }

    public Guid? vehicle_id { get; set; }

    public Guid? route_id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? scheduled_start { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? scheduled_end { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? actual_start { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? actual_end { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? attendance_status { get; set; }

    public bool? auto_assigned { get; set; }

    [InverseProperty("shift")]
    public virtual ICollection<Operator> operators { get; set; } = new List<Operator>();

    [ForeignKey("route_id")]
    [InverseProperty("shifts")]
    public virtual Route? route { get; set; }

    [ForeignKey("vehicle_id")]
    [InverseProperty("shifts")]
    public virtual Vehicle? vehicle { get; set; }
}
