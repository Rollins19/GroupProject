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

     public partial class FlightInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FlightInfo()
        {
            this.Manifests = new HashSet<Manifest>();
        }
    
        public int FlightNum { get; set; }
        [Display(Name ="Departure Airport")]
        public string DepartureAirport { get; set; }
        [Display(Name ="Arrival Airport")]
        public string ArrivalAirport { get; set; }
        [Display(Name ="Departure Time")]
        public System.TimeSpan DepartureTime { get; set; }
        [Display(Name = "Arrival Time")]
        public System.TimeSpan ArrivalTime { get; set; }
        [Display(Name = "Departure Date")]
        public System.DateTime DepartureDate { get; set; }
        [Display(Name ="Flight Capacity")]
        public int FlightCapacity { get; set; }
        [Display(Name ="Single Ticket Price")]
        public decimal SingleTicketPrice { get; set; }
        [Display(Name ="Flight Status")]
        public string FlightStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manifest> Manifests { get; set; }
    }
}
