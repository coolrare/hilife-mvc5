namespace MVC5Course.Models
{
    using MVC5Course.Validations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CourseMetadata))]
    public partial class Course : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.CourseID == default)
            {
                // Insert
            }
            else
            {
                // Update
            }

            yield return ValidationResult.Success;
        }

        // Buddy Class
        private class CourseMetadata
        {
            public int CourseID { get; set; }
            [Display(Name = "課程名稱")]
            [Required(ErrorMessage = "請輸入課程名稱")]
            //[身份證字號驗證]
            public string Title { get; set; }
            [Display(Name = "課程評價")]
            [Required(ErrorMessage = "設定課程評價({0})為必填欄位")]
            [Range(0, 5, ErrorMessage = "課程評價僅能輸入 0 ~ 5")]
            [UIHint("以星星顯示Credit欄位")]
            public int Credits { get; set; }
            [Display(Name = "部門名稱")]
            public int DepartmentID { get; set; }
            [Display(Name = "開課日期")]
            [Required(ErrorMessage = "請輸入開課日期")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            public System.DateTime OpenDate { get; set; }
            
            [Display(Name = "是否啟用")]
            public System.Boolean IsEnabled { get; set; }

        }
    }
}
