using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

[Index("email", Name = "UQ__users__AB6E6164EA563539", IsUnique = true)]
public partial class User
{
    [Key]
    public Guid id { get; set; }

    public Guid user_type_id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string name { get; set; }

    [StringLength(255)]
    [Unicode(true)]
    public string email { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? phone { get; set; }

    [StringLength(255)]
    [Unicode(true)]
    public string password_hash { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string role { get; set; }

    public bool is_active { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? creation_date { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? enrollment_date { get; set; }

    [InverseProperty("user")]
    public virtual ICollection<Operator> operators { get; set; } = new List<Operator>();

    [InverseProperty("user")]
    public virtual ICollection<Rating> ratings { get; set; } = new List<Rating>();

    [ForeignKey("user_type_id")]
    [InverseProperty("users")]
    public virtual UserType? user_type { get; set; }
}
