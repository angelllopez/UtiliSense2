using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UtiliSense.Solar.Data.Models;

[Table("SolarPowerActivity")]
public partial class SolarPowerActivity
{
    [Key]
    public int SolarPowerActivityId { get; set; }

    public DateOnly ActivityDate { get; set; }

    [Column("ProducedEnergy_kWh", TypeName = "decimal(10, 2)")]
    public decimal ProducedEnergyKWh { get; set; }

    [Column("UsedEnergy_kWh", TypeName = "decimal(10, 2)")]
    public decimal UsedEnergyKWh { get; set; }

    [Column("MaxACPowerProduced_kWh", TypeName = "decimal(10, 2)")]
    public decimal MaxAcpowerProducedKWh { get; set; }
}
