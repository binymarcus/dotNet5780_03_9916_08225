using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_03_9916_08225
{
    public class Host
    {
        private string hostName;
        private List<HostingUnit> units;

        public string HostName { get => hostName; set => hostName = value; }
        public List<HostingUnit> Units { get => units; set => units = value; }
    }
}
