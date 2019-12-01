using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_03_9916_08225
{
    public class HostingUnit
    {
        //we need to decide whats private and whats public,m although the class is public...    
        public string UnitName;
        public int Rooms;
        public bool IsSwimmingPool;
        public List<DateTime> AllOrders { get; set; }// i think we need to actually do the get and set, unclear
        public List<string> Uris { get; set; }// same thing with this one

    }
}
