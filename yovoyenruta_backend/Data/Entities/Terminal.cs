using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

public partial class Terminal
{
    [Key]
    public Guid id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? name { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? address { get; set; }

    public bool? is_active { get; set; }

    [InverseProperty("terminal")]
    public virtual ICollection<Route> routes { get; set; } = new List<Route>();

    [InverseProperty("terminal")]
    public virtual ICollection<Vehicle> vehicles { get; set; } = new List<Vehicle>();
}
