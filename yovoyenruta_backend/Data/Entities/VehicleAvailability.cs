using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

[Table("vehicle_availability")]
public partial class VehicleAvailability
{
    [Key]
    public Guid id { get; set; }

    public Guid? vehicle_id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? day_of_week { get; set; }

    public TimeOnly? start_time { get; set; }

    public TimeOnly? end_time { get; set; }

    public bool? is_active { get; set; }

    [ForeignKey("vehicle_id")]
    [InverseProperty("vehicle_availabilities")]
    public virtual Vehicle? vehicle { get; set; }
}
