﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Group2DBEntities : DbContext
    {
        public Group2DBEntities()
            : base("name=Group2DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FlightInfo> FlightInfoes { get; set; }
        public virtual DbSet<Manifest> Manifests { get; set; }
        public virtual DbSet<PassengerInfo> PassengerInfoes { get; set; }
        public virtual DbSet<PaymentInfo> PaymentInfoes { get; set; }
    }
}
