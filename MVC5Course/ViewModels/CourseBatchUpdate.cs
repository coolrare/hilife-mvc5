using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVC5Course.ViewModels
{
    public class CourseBatchUpdate
    {
        public int CourseID { get; set; }
        [Display(Name = "課程評價")]
        [Required(ErrorMessage = "設定課程評價({0})為必填欄位")]
        [Range(0, 5, ErrorMessage = "課程評價僅能輸入 0 ~ 5")]
        public int Credits { get; set; }
        [Display(Name = "開課日期")]
        [Required(ErrorMessage = "請輸入開課日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime OpenDate { get; set; }
    }
}