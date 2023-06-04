using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_1_List
{
    public class City : IComparable<City>
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public override string ToString()
        {
            return $"City name is {this.Name}. Population is {this.Population}.";
        }
        public int CompareTo(City? other)
        {
            return Population.CompareTo(other.Population);
        }
    }
}
