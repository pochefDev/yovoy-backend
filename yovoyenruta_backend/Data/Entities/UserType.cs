using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class UserType
{
    [Key]
    public Guid id { get; set; }

    [Column("user_type")]
    [StringLength(50)]
    [Unicode(false)]
    public string? user_type1 { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? description { get; set; }

    [InverseProperty("user_type")]
    public virtual ICollection<User> users { get; set; } = new List<User>();
}
