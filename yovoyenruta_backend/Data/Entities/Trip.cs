using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Trip
{
    [Key]
    public Guid id { get; set; }

    public Guid? operator_id { get; set; }

    public Guid? vehicle_id { get; set; }

    public Guid? route_id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? start_time { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? end_time { get; set; }

    [ForeignKey("operator_id")]
    [InverseProperty("trips")]
    public virtual Operator? _operator { get; set; }

    [InverseProperty("trip")]
    public virtual Incident? incident { get; set; }

    [ForeignKey("route_id")]
    [InverseProperty("trips")]
    public virtual Route? route { get; set; }

    [ForeignKey("vehicle_id")]
    [InverseProperty("trips")]
    public virtual Vehicle? vehicle { get; set; }
}
