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
        private string unitName;
        private int rooms;
        private bool isSwimmingPool;
        private List<DateTime> allOrders; // i think we need to actually do the get and set, unclear
        private List<string> uris; // same thing with this one
        /// <summary>
        /// getter and setter basic
        /// </summary>
        public string UnitName { get => unitName; set => unitName = value; }
        /// <summary>
        /// basic getter setter
        /// </summary>
        public int Rooms { get => rooms; set => rooms = value; }
        /// <summary>
        /// basic getter setter
        /// </summary>
        public bool IsSwimmingPool { get => isSwimmingPool; set => isSwimmingPool = value; }
        /// <summary>
        /// basic getter setter
        /// </summary>
        public List<DateTime> AllOrders { get => allOrders; set => allOrders = value; }
        /// <summary>
        /// basic getter setter
        /// </summary>
        public List<string> Uris { get => uris; set => uris = value; }
    }
}
