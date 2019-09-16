namespace CruiseDealAuthAndErd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CusEmail { get; set; }

        public int? AdminId { get; set; }

        public int CruiseId { get; set; }

        public int BookState { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BookDate { get; set; }

        public virtual Administrator Administrator { get; set; }

        public virtual Cruise Cruise { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
