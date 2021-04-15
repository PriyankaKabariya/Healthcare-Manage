using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareManagerProject
{
    public static class PatientFile
    {
        public static List<Patient> allPatientList = new List<Patient>()
        {
            new Patient("Arwen Herring", 1000000),
            new Patient("Jad Aguirre",1000001),
            new Patient("Natasha Escobar", 1000002),
            new Patient("Aamna Potter", 1000003),
            new Patient("Nichola Brook", 1000004),
            new Patient("Jasper Vickers",1000005),
            new Patient("Keeley West", 1000006),
            new Patient("Jaime Quintero", 1000007)
        };
    }
}
