namespace Verde_Supermarket
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pID { get; set; }

        [StringLength(50)]
        public string pName { get; set; }

        [StringLength(50)]
        public string pCategory { get; set; }

        [StringLength(50)]
        public string pBrand { get; set; }

        public double? pPrice { get; set; }

        public int? quantity { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }
}
