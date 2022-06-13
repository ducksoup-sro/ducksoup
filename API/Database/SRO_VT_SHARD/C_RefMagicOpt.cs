using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefMagicOpt")]
    public partial class C_RefMagicOpt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefMagicOpt()
        {
            C_RefMagicOptByItemOptLevel = new HashSet<C_RefMagicOptByItemOptLevel>();
        }

        public int Service { get; set; }

        public short ID { get; set; }

        [Required]
        [StringLength(129)]
        public string MOptName128 { get; set; }

        [Required]
        [StringLength(8)]
        public string AttrType { get; set; }

        public int MLevel { get; set; }

        public float Prob { get; set; }

        public int Weight { get; set; }

        public int Param1 { get; set; }

        public int Param2 { get; set; }

        public int Param3 { get; set; }

        public int Param4 { get; set; }

        public int Param5 { get; set; }

        public int Param6 { get; set; }

        public int Param7 { get; set; }

        public int Param8 { get; set; }

        public int Param9 { get; set; }

        public int Param10 { get; set; }

        public int Param11 { get; set; }

        public int Param12 { get; set; }

        public int Param13 { get; set; }

        public int Param14 { get; set; }

        public int Param15 { get; set; }

        public int Param16 { get; set; }

        public int ExcFunc1 { get; set; }

        public int ExcFunc2 { get; set; }

        public int ExcFunc3 { get; set; }

        public int ExcFunc4 { get; set; }

        public int ExcFunc5 { get; set; }

        public int ExcFunc6 { get; set; }

        [Required]
        [StringLength(129)]
        public string AvailItemGroup1 { get; set; }

        public int ReqClass1 { get; set; }

        [Required]
        [StringLength(129)]
        public string AvailItemGroup2 { get; set; }

        public int ReqClass2 { get; set; }

        [Required]
        [StringLength(129)]
        public string AvailItemGroup3 { get; set; }

        public int ReqClass3 { get; set; }

        [Required]
        [StringLength(129)]
        public string AvailItemGroup4 { get; set; }

        public int ReqClass4 { get; set; }

        [Required]
        [StringLength(129)]
        public string AvailItemGroup5 { get; set; }

        public int ReqClass5 { get; set; }

        [StringLength(129)]
        public string AvailItemGroup6 { get; set; }

        public int? ReqClass6 { get; set; }

        [StringLength(129)]
        public string AvailItemGroup7 { get; set; }

        public int? ReqClass7 { get; set; }

        [StringLength(129)]
        public string AvailItemGroup8 { get; set; }

        public int? ReqClass8 { get; set; }

        [StringLength(129)]
        public string AvailItemGroup9 { get; set; }

        public int? ReqClass9 { get; set; }

        [StringLength(129)]
        public string AvailItemGroup10 { get; set; }

        public int? ReqClass10 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefMagicOptByItemOptLevel> C_RefMagicOptByItemOptLevel { get; set; }
    }
}
