using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareManagerProject
{
    public class MedicationForSale
    {
        public string Drug { get; private set; }
        public float UnitPrice { get; private set; }
        public bool RequiresPrescription { get; private set; }

        public MedicationForSale(string Drug, float UnitPrice, bool RequiresPrescription)
        {
            this.Drug = Drug;
            this.UnitPrice = UnitPrice;
            this.RequiresPrescription = RequiresPrescription;
        }

        public void SetDrug(string Drug)
        {
            this.Drug = Drug;
        }

        public void SetUnitPrice(float UnitPrice)
        {
            this.UnitPrice = UnitPrice;
        }

        public void SetRequiresPrescription(bool RequiresPrescription)
        {
            this.RequiresPrescription = RequiresPrescription;
        }

    }
}
