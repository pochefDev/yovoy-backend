using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

[Index("trip_id", Name = "UQ__incident__302A5D9F281CDF4B", IsUnique = true)]
public partial class Incident
{
    [Key]
    public Guid id { get; set; }

    public Guid? trip_id { get; set; }

    [StringLength(255)]
    public string? details { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? date { get; set; }

    [ForeignKey("trip_id")]
    [InverseProperty("incident")]
    public virtual Trip? trip { get; set; }
}
