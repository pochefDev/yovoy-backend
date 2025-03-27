using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class VehicleFeature
{
    [Key]
    public Guid id { get; set; }

    public Guid? vehicle_id { get; set; }

    public Guid? feature_id { get; set; }

    [ForeignKey("feature_id")]
    [InverseProperty("vehicle_features")]
    public virtual Feature? feature { get; set; }

    [ForeignKey("vehicle_id")]
    [InverseProperty("vehicle_features")]
    public virtual Vehicle? vehicle { get; set; }
}
