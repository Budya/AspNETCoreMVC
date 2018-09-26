using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17ValidationgApp.Models
{
    public class PersonNameAttribute : ValidationAttribute
    {
        // array for "good names" storing
        private string[] _names;

        public PersonNameAttribute(string[] names)
        {
            _names = names;
        }

        public override bool IsValid(object value)
        {
            if (_names.Contains(value.ToString()))
                return true;

            return false;
        }

    }
}
