namespace MarkSecuritiesDataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("olympic.vIsAAA")]
    public partial class vIsAAA
    {
        [Column(TypeName = "date")]
        public DateTime? LastDate { get; set; }

        [Key]
        [StringLength(11)]
        public string SecurityCode { get; set; }

        [StringLength(35)]
        public string SecurityName { get; set; }

        [StringLength(3)]
        public string SecurityType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IBLCProfile { get; set; }

        [StringLength(12)]
        public string ISIN { get; set; }

        public bool? IsAAA { get; set; }
    }
}
