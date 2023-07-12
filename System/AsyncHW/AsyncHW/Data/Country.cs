using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncHW.Data
{
    public class Country
    {
        public Country() { }
        public Country(string name, uint yearFounded, string govermentType, string mapImageLink, uint population, uint area, double gdp)
        {
            Name = name;
            YearFounded = yearFounded;
            GovernmentType = govermentType;
            MapImageLink = mapImageLink;
            Population = population;
            Area = area;
            GDP = gdp;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public uint YearFounded { get; set; }
        public string GovernmentType { get; set; }
        public string MapImageLink { get; set; }
        public uint Population { get; set; }
        public uint Area { get; set; }
        public double GDP { get; set; }
        public string CurrentRuler { get; set; }
        public string NationalAnthem { get; set; }
    }
}
