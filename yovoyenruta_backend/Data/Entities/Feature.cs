using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Feature
{
    [Key]
    public Guid id { get; set; }

    [Column("feature")]
    [StringLength(50)]
    [Unicode(false)]
    public string? feature1 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? description { get; set; }

    [InverseProperty("feature")]
    public virtual ICollection<VehicleFeature> vehicle_features { get; set; } = new List<VehicleFeature>();
}
