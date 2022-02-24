namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {
    }
    
    public partial class DepartmentMetaData
    {
        [Required]
        public int DepartmentID { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        [Range(1000, 99999)]
        public decimal Budget { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }
        
        public byte[] RowVersion { get; set; }
    
        public virtual ICollection<Course> Course { get; set; }
        public virtual Person Person { get; set; }
    }

    public partial class DepartmentEdit
    {
        [Required]
        public int DepartmentID { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        [Range(1000, 99999)]
        public decimal Budget { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime StartDate { get; set; }

        public Nullable<int> InstructorID { get; set; }
    }
}
