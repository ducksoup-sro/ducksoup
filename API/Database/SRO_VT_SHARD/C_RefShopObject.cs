using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database.SRO_VT_SHARD
{
    [Table("_RefShopObject")]
    public partial class C_RefShopObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public C_RefShopObject()
        {
            C_RefMappingShopGroup = new HashSet<C_RefMappingShopGroup>();
            C_RefMappingShopWithTab = new HashSet<C_RefMappingShopWithTab>();
            C_RefPackageItem = new HashSet<C_RefPackageItem>();
            C_RefPricePolicyOfItem = new HashSet<C_RefPricePolicyOfItem>();
            C_RefRewardPolicyToSellPackageItem = new HashSet<C_RefRewardPolicyToSellPackageItem>();
            C_RefShop = new HashSet<C_RefShop>();
            C_RefShopGoods = new HashSet<C_RefShopGoods>();
            C_RefShopGroup = new HashSet<C_RefShopGroup>();
            C_RefAccessPermissionOfShop = new HashSet<C_RefAccessPermissionOfShop>();
            C_RefConditionToBuyScrapItem = new HashSet<C_RefConditionToBuyScrapItem>();
            C_RefConditionToSellPackageItem = new HashSet<C_RefConditionToSellPackageItem>();
            C_RefConditionToSellScrapItem = new HashSet<C_RefConditionToSellScrapItem>();
            C_RefRewardPolicyToBuyScrapItem = new HashSet<C_RefRewardPolicyToBuyScrapItem>();
            C_RefRewardPolicyToSellScrapItem = new HashSet<C_RefRewardPolicyToSellScrapItem>();
            C_RefScrapOfPackageItem = new HashSet<C_RefScrapOfPackageItem>();
            C_RefShopTab = new HashSet<C_RefShopTab>();
            C_RefShopTabGroup = new HashSet<C_RefShopTabGroup>();
            C_RefTreatItemOfShop = new HashSet<C_RefTreatItemOfShop>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(129)]
        public string CodeName128 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefMappingShopGroup> C_RefMappingShopGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefMappingShopWithTab> C_RefMappingShopWithTab { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefPackageItem> C_RefPackageItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefPricePolicyOfItem> C_RefPricePolicyOfItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefRewardPolicyToSellPackageItem> C_RefRewardPolicyToSellPackageItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefShop> C_RefShop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefShopGoods> C_RefShopGoods { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefShopGroup> C_RefShopGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefAccessPermissionOfShop> C_RefAccessPermissionOfShop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefConditionToBuyScrapItem> C_RefConditionToBuyScrapItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefConditionToSellPackageItem> C_RefConditionToSellPackageItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefConditionToSellScrapItem> C_RefConditionToSellScrapItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefRewardPolicyToBuyScrapItem> C_RefRewardPolicyToBuyScrapItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefRewardPolicyToSellScrapItem> C_RefRewardPolicyToSellScrapItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefScrapOfPackageItem> C_RefScrapOfPackageItem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefShopTab> C_RefShopTab { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefShopTabGroup> C_RefShopTabGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_RefTreatItemOfShop> C_RefTreatItemOfShop { get; set; }
    }
}
