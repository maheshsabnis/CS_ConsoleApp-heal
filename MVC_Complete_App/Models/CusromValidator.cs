using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Complete_App.Models
{
    public class NumericNonNegativeAttribute : ValidationAttribute
    {
        /// <summary>
        /// The 'value' parameter will read the value of the property
        /// on which this validator class is applied
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) < 0)
            {
                return false; // invalid value
            }
            return true; // value is valid
        }
    }
}