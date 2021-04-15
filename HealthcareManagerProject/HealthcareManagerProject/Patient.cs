using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareManagerProject
{
    public class Patient
    {
        public string Name { get; private set; }
        public int Healthcare { get; private set; }
       

        public Patient(string Name, int Healthcare)
        {
            this.Name = Name;
            this.Healthcare = Healthcare;
        }

        public void SetName(string Name)
        {
            this.Name = Name;
        }

        public void SetHealthcare(int Healthcare)
        {
            this.Healthcare = Healthcare;
        }

    }
}
