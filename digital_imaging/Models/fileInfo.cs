//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace digital_imaging.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class fileInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fileInfo()
        {
            this.user_auditTrail = new HashSet<user_auditTrail>();
        }
    
        public int id { get; set; }
        public string fileUniqueID { get; set; }
        public string imageList { get; set; }
        public Nullable<System.DateTime> pro_date { get; set; }
        public string rumNum { get; set; }
        public Nullable<int> fileType_id { get; set; }
        public Nullable<int> uenType_id { get; set; }
        public string uenValue { get; set; }
        public Nullable<int> docType_id { get; set; }
        public Nullable<int> status { get; set; }
        public string maker { get; set; }
        public string chacker { get; set; }
        public string genPDF { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
    
        public virtual docType docType { get; set; }
        public virtual fileType fileType { get; set; }
        public virtual uenType uenType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_auditTrail> user_auditTrail { get; set; }
    }
}