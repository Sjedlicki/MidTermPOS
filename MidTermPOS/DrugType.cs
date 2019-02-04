using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermPOS
{
    class DrugType
    {
        public string DrugName;
        public string DrugInfo;
        public int PillCount;
        public double Price;

        public DrugType(string DrugName, double Price, string DrugInfo)
        {
            this.DrugName = DrugName;
            this.Price = Price;
            this.PillCount = 0;
            this.DrugInfo = DrugInfo;
        }
    }
}
