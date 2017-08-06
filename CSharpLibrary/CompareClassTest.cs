using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codepractice.CSharpLibrary
{
    public class CompareClassTest
    {
        public static void TestAdvanceFilter()
        {

            var firstSet = new List<TerminalBusiness> {
                                                          {new TerminalBusiness {TerminalId = 1 }},
                                                          {new TerminalBusiness {TerminalId = 2 } },
                                                          {new TerminalBusiness {TerminalId = 3 }},
                                                          {new TerminalBusiness {TerminalId = 4 }},
                                                          {new TerminalBusiness {TerminalId = 5 } },
                                                          {new TerminalBusiness {TerminalId = 6 }},
                                                      };

            var secondSet = new List<TerminalBusiness> {
                                                          {new TerminalBusiness {TerminalId = 1 }},
                                                          {new TerminalBusiness {TerminalId = 2 } },
                                                          {new TerminalBusiness {TerminalId = 3 }},
                                                          {new TerminalBusiness {TerminalId = 7 }},
                                                          {new TerminalBusiness {TerminalId = 8 } },
                                                          {new TerminalBusiness {TerminalId = 9 }},
                                                      };

            var unionSet = firstSet.Union(secondSet, new AdvanceFilterCompare());

            var disjointSet = firstSet.Except(secondSet, new AdvanceFilterCompare());

            Console.WriteLine("Union set is below");
            foreach (var terminal in unionSet)
            {
                Console.WriteLine("terminal ID :" + terminal.TerminalId);
            }
            Console.WriteLine("Disjoint Set is below");
            foreach (var terminal in disjointSet)
            {
                Console.WriteLine("terminal ID :" + terminal.TerminalId);
            }
        }
    }

    public class AdvanceFilterCompare : IEqualityComparer<TerminalBusiness>
    {
        public bool Equals(TerminalBusiness x, TerminalBusiness y)
        {
            //Check whether the objects are the same object. 
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether the products' properties are equal. 
            return x != null && y != null && x.TerminalId == y.TerminalId;
        }

        public int GetHashCode(TerminalBusiness obj)
        {
            //Get hash code for the TerminalId field if it is not null. 
            return obj.TerminalId == null ? 0 : obj.TerminalId.GetHashCode();
        }
    }

    public class TerminalBusiness
    {
        public int? TerminalId { get; set; }

        public string TerminalCode { get; set; }

        public string TerminalType { get; set; }
        public string MotherTerminals { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string TimeZone { get; set; }
        public string TimeZoneOffset { get; set; }

        public bool? IsDomicile { get; set; }
        public int? RelayTime { get; set; }
        public double? Latitude { get; set; }
       public double? Longitude { get; set; }
    }
}