using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UtiliSense.Gas.Data.Models;

[Table("GasConsumption")]
public partial class GasConsumption
{
    [Key]
    public int GasConsumptionId { get; set; }

    public DateOnly ConsumptionDate { get; set; }

    [Column("GasConsumptionCCF")]
    public int GasConsumptionCcf { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string AvgTemp { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string HighTemp { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string LowTemp { get; set; } = null!;

    public DateOnly BillingMonth { get; set; }
}
