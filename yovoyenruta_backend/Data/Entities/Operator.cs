using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Operator
{
    [Key]
    public Guid id { get; set; }

    public Guid? user_id { get; set; }

    public Guid? shift_id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? operator_number { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? service_zone { get; set; }

    public int? years_experience { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? current_status { get; set; }

    public double? salary { get; set; }

    public bool? is_active { get; set; }

    [InverseProperty("_operator")]
    public virtual ICollection<AssignmentLog> assignment_logs { get; set; } = new List<AssignmentLog>();

    [InverseProperty("_operator")]
    public virtual ICollection<OperatorAchievement> operator_achievements { get; set; } = new List<OperatorAchievement>();

    [InverseProperty("_operator")]
    public virtual ICollection<OperatorPreference> operator_preferences { get; set; } = new List<OperatorPreference>();

    [InverseProperty("_operator")]
    public virtual ICollection<Rating> ratings { get; set; } = new List<Rating>();

    [ForeignKey("shift_id")]
    [InverseProperty("operators")]
    public virtual Shift? shift { get; set; }

    [InverseProperty("_operator")]
    public virtual ICollection<Trip> trips { get; set; } = new List<Trip>();

    [ForeignKey("user_id")]
    [InverseProperty("operators")]
    public virtual User? user { get; set; }
}
