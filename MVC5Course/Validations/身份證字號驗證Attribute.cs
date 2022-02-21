using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaiwanNo1.Validation;

namespace MVC5Course.Validations
{
    public class 身份證字號驗證Attribute : DataTypeAttribute
    {
        public 身份證字號驗證Attribute() : base(DataType.Text)
        {
            ErrorMessage = "請輸入合法的身份證字號";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string TwId = value as string;
            if (TwId == null)
            {
                return false;
            }

            return TwId.IsTwIdValid();
        }
    }
}