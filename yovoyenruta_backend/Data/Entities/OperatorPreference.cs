using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class OperatorPreference
{
    [Key]
    public Guid id { get; set; }

    public Guid? operator_id { get; set; }

    public Guid? route_id { get; set; }

    public int? priority { get; set; }

    [Column(TypeName = "text")]
    public string? comments { get; set; }

    [ForeignKey("operator_id")]
    [InverseProperty("operator_preferences")]
    public virtual Operator? _operator { get; set; }

    [ForeignKey("route_id")]
    [InverseProperty("operator_preferences")]
    public virtual Route? route { get; set; }
}
