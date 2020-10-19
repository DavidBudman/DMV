using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
namespace BE
{
    public class Name
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public Name(String f, String l)
        {
            this.FirstName = f;
            this.LastName = l;
        }
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
