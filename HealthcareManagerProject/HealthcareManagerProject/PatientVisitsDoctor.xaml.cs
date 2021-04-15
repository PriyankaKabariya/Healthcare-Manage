using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthcareManagerProject
{
    /// <summary>
    /// Interaction logic for PatientVisitsDoctor.xaml
    /// </summary>
    public partial class PatientVisitsDoctor : Page
    {
        object mainPage;
        string patientName, doctorName;

        public PatientVisitsDoctor(object _mainPage, string patientName, string doctorName)
        {
            InitializeComponent();
            mainPage = _mainPage;

            this.patientName = patientName;
            this.doctorName = doctorName;

            txtHeading.Text = this.patientName + " visits " + this.doctorName;

            comboBox1.ItemsSource = Medication.allMedicationList;
        }

        private void btnQuestion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The refill count indicates how many times this prescription " +
                "can be filled at the pharmacy before it needs to be renewed by the doctor.");
        }

        private void btnRequestPrescription_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select Medication!!!","ERROR!!!");
            }
            else if(txtRefill.Text == "" || txtRefill.Text == "0")
            {
                MessageBox.Show("Please enter number of refills!!!", "ERROR!!!");
            }
            else if (txtRefill.Text!="" && txtRefill.Text != "0" && comboBox1.SelectedItem != null)
            {
                MessageBox.Show(doctorName + "has prescribed " + comboBox1.SelectedItem.ToString() + " to " + patientName + ", with " + txtRefill.Text + " refills.");
            }

        }

        private void btnCompleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            if(txtRefill.Text != "" && txtRefill.Text != "0" && comboBox1.SelectedItem != null)
            {
                StoreData.medication = comboBox1.SelectedItem.ToString();
                StoreData.refill = int.Parse(txtRefill.Text);
            }
            ((MainWindow)Application.Current.MainWindow).Content = mainPage;
        }
    }
};
