namespace MarkSecuritiesDataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pershing.vIsAAA")]
    public partial class vIsAAA1
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string CUSIP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(126)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(9)]
        public string StructuredProductIndicator { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool IsStructuredProduct { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsAAA { get; set; }
    }
}
