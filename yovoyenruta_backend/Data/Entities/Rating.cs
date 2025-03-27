using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Rating
{
    [Key]
    public Guid id { get; set; }

    public Guid? operator_id { get; set; }

    public Guid? user_id { get; set; }

    public int? stars { get; set; }

    [Column(TypeName = "text")]
    public string? comment { get; set; }

    public int? waiting_time_minutes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? date { get; set; }

    [ForeignKey("operator_id")]
    [InverseProperty("ratings")]
    public virtual Operator? _operator { get; set; }

    [ForeignKey("user_id")]
    [InverseProperty("ratings")]
    public virtual User? user { get; set; }
}
