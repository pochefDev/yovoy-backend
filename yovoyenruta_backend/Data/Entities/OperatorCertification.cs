using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace yovoyenruta_backend.Data.Entities;

[Keyless]
public partial class OperatorCertification
{
    public Guid? operator_id { get; set; }

    public Guid? certification_id { get; set; }

    public DateOnly? obtained_date { get; set; }

    public bool? is_valid { get; set; }

    [ForeignKey("operator_id")]
    public virtual Operator? _operator { get; set; }

    [ForeignKey("certification_id")]
    public virtual Certification? certification { get; set; }
}
