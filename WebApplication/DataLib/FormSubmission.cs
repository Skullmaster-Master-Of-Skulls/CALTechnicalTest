//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.DataLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class FormSubmission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormSubmission()
        {
            this.DisabilityTypes = new HashSet<DisabilityType>();
        }
    
        public int Id { get; set; }
        public string Email { get; set; }
        public string AdditionalAccessibilityRequirements { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LevelOfStudy { get; set; }
        public string PreferredPronoun { get; set; }
        public bool International { get; set; }
        public bool Consent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisabilityType> DisabilityTypes { get; set; }
    }
}
