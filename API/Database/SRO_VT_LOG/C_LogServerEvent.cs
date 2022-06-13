using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_LOG
{
    [Table("_LogServerEvent")]
    public partial class C_LogServerEvent
    {
        public int ID { get; set; }

        public DateTime EventTime { get; set; }

        public int ServerEventID { get; set; }

        public byte LogType { get; set; }

        [StringLength(128)]
        public string strDesc { get; set; }
    }
}
