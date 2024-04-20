using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtiliSense.Grid.Data.Models;

[Table("GridPowerConsumption")]
public partial class GridPowerConsumption
{
    [Key]
    public int GridPowerConsumptionId { get; set; }

    public DateOnly PowerConsumptionDate { get; set; }

    public TimeOnly ConsumptionStartTime { get; set; }

    public TimeOnly ConsumptionEndTime { get; set; }

    [Column("PowerConsumed_kWh", TypeName = "decimal(10, 2)")]
    public decimal PowerConsumedKWh { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Cost { get; set; }
}
