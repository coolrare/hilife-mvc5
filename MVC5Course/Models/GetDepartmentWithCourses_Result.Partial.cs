namespace MVC5Course.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(GetDepartmentWithCourses_ResultMetaData))]
    public partial class GetDepartmentWithCourses_Result
    {
    }
    
    public partial class GetDepartmentWithCourses_ResultMetaData
    {
        [Required]
        public int CourseID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Title { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public System.DateTime OpenDate { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string DepartmentName { get; set; }
        public Nullable<System.DateTime> DepartmentStartDate { get; set; }
    }
}
