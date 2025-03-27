using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Certification
{
    [Key]
    public Guid id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? name { get; set; }

    [Column(TypeName = "text")]
    public string? description { get; set; }
}
