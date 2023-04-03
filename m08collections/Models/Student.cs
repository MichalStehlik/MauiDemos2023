using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m08collections.Models
{
    internal class Student
    {
        private string _firstname;
        private string _lastname;

        public string FirstName {
            get { return _firstname; } 
            set { _firstname = value; } 
        }
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

    }
}
