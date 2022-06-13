using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefObjStruct")]
    public partial class C_RefObjStruct
    {
        public int ID { get; set; }

        public int Dummy_Data { get; set; }
    }
}
