using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAcoount.Models
{
    public class Income
    {
        public Income(double value = 0)
        {
            this.Value = value;
            this.DateAcuired = DateTime.Now;
        }

        public static Income Parse(string json)
        {
            Income income = new Income();
            JObject jObject = JObject.Parse(json);
            income.Value = double.Parse((string)jObject["Value"]);
            income.DateAcuired = DateTime.Parse((string)jObject["DateAcuired"]);
            return income;
        }
        public DateTime DateAcuired { get; set; }

        public double Value { get; set; }
    }
}
