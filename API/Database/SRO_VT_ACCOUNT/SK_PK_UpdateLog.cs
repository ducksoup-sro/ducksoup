using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_ACCOUNT
{
    public partial class SK_PK_UpdateLog
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JID { get; set; }

        [StringLength(15)]
        public string UserName { get; set; }

        public int? CharID { get; set; }

        [StringLength(15)]
        public string CharName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageItemID { get; set; }

        public int? Silk_Own { get; set; }

        public int? Silk_Before { get; set; }

        public int? Silk_After { get; set; }

        public long? Gold_Remain { get; set; }

        public long? Gold_Before { get; set; }

        public long? Gold_After { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IP { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime RegDate { get; set; }

        public long? Serial64 { get; set; }

        public int? ShardID { get; set; }

        [StringLength(10)]
        public string ServiceCode { get; set; }

        [Column("_Strength")]
        public int? C_Strength { get; set; }

        [Column("_Intellect")]
        public int? C_Intellect { get; set; }

        [Column("_CurLevel")]
        public int? C_CurLevel { get; set; }

        [Column("_Statpoint")]
        public int? C_Statpoint { get; set; }

        [Column("_NewName")]
        [StringLength(12)]
        public string C_NewName { get; set; }

        [Column("_OldPetName")]
        [StringLength(12)]
        public string C_OldPetName { get; set; }

        [Column("_NewPetName")]
        [StringLength(12)]
        public string C_NewPetName { get; set; }

        [Column("_NewStatPoint")]
        public int? C_NewStatPoint { get; set; }

        [Column("_NewLevel")]
        public int? C_NewLevel { get; set; }

        [Column("_NewStrength")]
        public int? C_NewStrength { get; set; }

        [Column("_NewIntellect")]
        public int? C_NewIntellect { get; set; }

        [Column("_Skill_Own")]
        public int? C_Skill_Own { get; set; }

        [Column("_Skill_Before")]
        public int? C_Skill_Before { get; set; }

        [Column("_Skill_After")]
        public int? C_Skill_After { get; set; }

        [Column("_Item_BH")]
        [StringLength(200)]
        public string C_Item_BH { get; set; }
    }
}
