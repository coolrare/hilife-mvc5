namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(Department_Insert_ResultMetaData))]
    public partial class Department_Insert_Result : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
        }
    }

    public partial class Department_Insert_ResultMetaData
    {
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }
    }
}
