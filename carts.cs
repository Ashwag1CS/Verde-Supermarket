namespace Verde_Supermarket
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class carts
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string orderNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pID { get; set; }

        [StringLength(50)]
        public string pName { get; set; }

        public double? pPrice { get; set; }

        public int? quantity { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string pBrand { get; set; }

        [StringLength(50)]
        public string pCategory { get; set; }

        public virtual customer customer { get; set; }
    }
}
