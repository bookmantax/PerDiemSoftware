//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExcelTest2
{
    using System;
    using System.Collections.Generic;
    
    public partial class CityPerDiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CityPerDiem()
        {
            this.YearPerDiems = new HashSet<YearPerDiem>();
        }
    
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AirportCode { get; set; }
        public int Meals { get; set; }
        public int Lodging { get; set; }
        public int Total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YearPerDiem> YearPerDiems { get; set; }
    }
}