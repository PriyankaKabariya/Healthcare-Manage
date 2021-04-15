using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareManagerProject
{
    public static class MedicationForSaleList
    {
        public static List<MedicationForSale> allMedicationForSaleList = new List<MedicationForSale>()
        {
            new MedicationForSale("Insulin", 70.95f, true),
            new MedicationForSale("Adderall", 25.99f, true),
            new MedicationForSale("Vicodin", 111.99f, true),
            new MedicationForSale("Simvastatin", 64.05f, true),
            new MedicationForSale("Advil", 9.99f, false),
            new MedicationForSale("Polysporin", 12.95f, false),
            new MedicationForSale("Pepto-Bismol", 8.65f, false),
            new MedicationForSale("Benadry", 15.52f, false)
        };
    }
}
