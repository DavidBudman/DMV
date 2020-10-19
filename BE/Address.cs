using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
namespace BE
{
    public class Address : IComparable<Address>
    {
        public String Street { get; set; }
        public int Number { get; set; }
        public String City { get; set; }

        public Address (String s, int n, String c)
        {
            this.Street = s;
            this.Number = n;
            this.City = c;
        }
        
        public Address(Address other)
        {
            Street = other.Street;
            Number = other.Number;
            City = other.City;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, {2}", Number, Street, City);
        }

        public int CompareTo(Address other)
        {
            int r = City.CompareTo(other.City);
            if (r == 0)
            {
                r = Street.CompareTo(other.Street);
            }
            if (r == 0)
            {
                r = Number.CompareTo(other.Number);
            }
            return r;
        }

    

    }
}
