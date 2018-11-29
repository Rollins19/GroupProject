//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroupProject.Models
{
    using System;
    using System.Collections.Generic;
     using System.ComponentModel.DataAnnotations;

     public partial class Manifest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manifest()
        {
            this.PaymentInfoes = new HashSet<PaymentInfo>();
        }
    
        [Display (Name = "Manifest Id")]
        public int ManifestID { get; set; }
        [Display (Name = "Passenger Id")]
        public int PassengerID { get; set; }
        [Display (Name = "Flight Number")]
        public int FlightNum { get; set; }
        [Display (Name = "Ticket Number")]
        public int TicketNum { get; set; }
        [Display (Name = "Seat Number")]
        public string SeatNum { get; set; }
    
        public virtual FlightInfo FlightInfo { get; set; }
        public virtual PassengerInfo PassengerInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentInfo> PaymentInfoes { get; set; }
    }
}
