using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefClimate")]
    public partial class C_RefClimate
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte InitialWeather { get; set; }

        [Key]
        [Column(Order = 2)]
        public byte InitialAmount { get; set; }

        [Key]
        [Column(Order = 3)]
        public byte ChangeWeather { get; set; }

        [Key]
        [Column(Order = 4)]
        public byte Division { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Duration { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DurationVariance { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte Snowfall { get; set; }

        [Key]
        [Column(Order = 8)]
        public byte SnowfallVariance { get; set; }

        [Key]
        [Column(Order = 9)]
        public byte ProbSnow { get; set; }

        [Key]
        [Column(Order = 10)]
        public byte Rainfall { get; set; }

        [Key]
        [Column(Order = 11)]
        public byte RainfallVariance { get; set; }

        [Key]
        [Column(Order = 12)]
        public byte ProbRain { get; set; }
    }
}
