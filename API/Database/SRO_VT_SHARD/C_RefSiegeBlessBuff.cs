using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefSiegeBlessBuff")]
    public partial class C_RefSiegeBlessBuff
    {
        public byte Service { get; set; }

        [Key]
        public int BlessID { get; set; }

        public int FortressID { get; set; }

        public int RefBlessBuffID { get; set; }

        public long? NeedGold { get; set; }

        public int? NeedGP { get; set; }

        public virtual C_RefSiegeFortress C_RefSiegeFortress { get; set; }

        public virtual C_RefSkill C_RefSkill { get; set; }
    }
}
