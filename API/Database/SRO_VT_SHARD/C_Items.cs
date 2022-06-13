using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_Items")]
    public partial class C_Items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_Items()
        {
            C_Chest = new HashSet<C_Chest>();
            C_InvCOS = new HashSet<C_InvCOS>();
            C_Inventory = new HashSet<C_Inventory>();
            C_InventoryForAvatar = new HashSet<C_InventoryForAvatar>();
            C_InventoryForLinkedStorage = new HashSet<C_InventoryForLinkedStorage>();
            C_OpenMarket = new HashSet<C_OpenMarket>();
        }

        [Key]
        public long ID64 { get; set; }

        public int RefItemID { get; set; }

        public byte? OptLevel { get; set; }

        public long? Variance { get; set; }

        public int Data { get; set; }

        [StringLength(64)]
        public string CreaterName { get; set; }

        public byte MagParamNum { get; set; }

        public long? MagParam1 { get; set; }

        public long? MagParam2 { get; set; }

        public long? MagParam3 { get; set; }

        public long? MagParam4 { get; set; }

        public long? MagParam5 { get; set; }

        public long? MagParam6 { get; set; }

        public long? MagParam7 { get; set; }

        public long? MagParam8 { get; set; }

        public long? MagParam9 { get; set; }

        public long? MagParam10 { get; set; }

        public long? MagParam11 { get; set; }

        public long? MagParam12 { get; set; }

        public long Serial64 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Chest> C_Chest { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_InvCOS> C_InvCOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Inventory> C_Inventory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_InventoryForAvatar> C_InventoryForAvatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_InventoryForLinkedStorage> C_InventoryForLinkedStorage { get; set; }

        public virtual C_ItemPool C_ItemPool { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_OpenMarket> C_OpenMarket { get; set; }
    }
}
