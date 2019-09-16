namespace CruiseDealAuthAndErd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cruise")]
    public partial class Cruise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cruise()
        {
            Bookings = new HashSet<Booking>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepartDate { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartPort { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReturnDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Destination { get; set; }

        public int Seats { get; set; }

        public decimal Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
