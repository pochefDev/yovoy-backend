using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Vehicle
{
    [Key]
    public Guid id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? license_plate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? model { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? type { get; set; }

    public int? capacity { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? size { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? status { get; set; }

    public Guid? terminal_id { get; set; }

    public bool? is_active { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? brand { get; set; }

    [InverseProperty("vehicle")]
    public virtual ICollection<AssignmentLog> assignment_logs { get; set; } = new List<AssignmentLog>();

    [InverseProperty("vehicle")]
    public virtual ICollection<Maintenance> maintenances { get; set; } = new List<Maintenance>();

    [InverseProperty("vehicle")]
    public virtual ICollection<Shift> shifts { get; set; } = new List<Shift>();

    [ForeignKey("terminal_id")]
    [InverseProperty("vehicles")]
    public virtual Terminal? terminal { get; set; }

    [InverseProperty("vehicle")]
    public virtual ICollection<Trip> trips { get; set; } = new List<Trip>();

    [InverseProperty("vehicle")]
    public virtual ICollection<VehicleAvailability> vehicle_availabilities { get; set; } = new List<VehicleAvailability>();

    [InverseProperty("vehicle")]
    public virtual ICollection<VehicleFeature> vehicle_features { get; set; } = new List<VehicleFeature>();
}
