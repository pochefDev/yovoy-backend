using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Maintenance
{
    [Key]
    public Guid id { get; set; }

    public Guid? vehicle_id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? scheduled_date { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? actual_date { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? type { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? status { get; set; }

    [Column(TypeName = "text")]
    public string? notes { get; set; }

    [ForeignKey("vehicle_id")]
    [InverseProperty("maintenances")]
    public virtual Vehicle? vehicle { get; set; }
}
