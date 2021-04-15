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
    /// Interaction logic for PatientVisitPharmacy.xaml
    /// </summary>
    public partial class PatientVisitPharmacy : Page
    {
        object mainPage;
        string patientName;
        public PatientVisitPharmacy(object _mainPage, string patientName)
        {
            InitializeComponent();

            mainPage = _mainPage;
            this.patientName = patientName;

            txtHeading.Text = this.patientName +" shops at the pharmacy";

            dataGrid1.ItemsSource = MedicationForSaleList.allMedicationForSaleList;
            comboBox1.ItemsSource = Pharmacists.allPharmacistsList;

        }

        private void btnExitPharmacy_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Content = mainPage;
        }

        private void btnDrugInfo_Click(object sender, RoutedEventArgs e)
        {
            Object selectedObject = dataGrid1.SelectedItem;
            if (selectedObject != null)
            {
                MedicationForSale selectedMedication = (MedicationForSale)dataGrid1.SelectedItem;
                string drug = selectedMedication.Drug;
                float unitPrice = selectedMedication.UnitPrice;
                if (selectedMedication.RequiresPrescription == false)
                {
                    MessageBox.Show("-Medication Name : " + drug + "\n-Unit Price : " + unitPrice +
                        "\n-This medication does not require a prescription.\n" +
                        "-Dosage Instruction : 1 to 2 capsules every 4 to 6 hours as needed.");
                }
                else if (selectedMedication.RequiresPrescription == true)
                {
                    MessageBox.Show("-Medication Name : " + drug + "\n-Unit Price : " + unitPrice +
                        "\n-This medication requires a prescription.\n" +
                        "-Please refer to your prescription for dosage instruction.\n"+
                        "-You may be eligible for a partial or full reimbursement for this" +
                        " medication depending upon your insurance coverage. " +
                        "Please inquire with your provider for more detail.");
                }
            }
            else
            {
                MessageBox.Show("Please select a Drug for Info!", "ERROR!!!");
            }
        }

        private void btnPurchase_Click(object sender, RoutedEventArgs e)
        {
            Object selectedObject = dataGrid1.SelectedItem;
            if (selectedObject != null)
            {
                MedicationForSale selectedMedication = (MedicationForSale)dataGrid1.SelectedItem;
                string drug = selectedMedication.Drug;
                float unitPrice = selectedMedication.UnitPrice;
                if (selectedMedication.RequiresPrescription == false)
                {
                    MessageBox.Show(patientName + " has purchased a bottle of " + drug + " for $ " + unitPrice + ".");
                }
                else if (selectedMedication.RequiresPrescription == true && comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("This is a prescription medication, so pharmacist assistance is required.\n" +
                        "Please select a pharmacist to help fill the prescription.");
                }
                else if (selectedMedication.RequiresPrescription == true && comboBox1.SelectedItem != null && StoreData.medication == drug)
                {
                    int a = StoreData.refill--;
                    if (a > 0)
                    {
                        MessageBox.Show("Pharmacist " + comboBox1.SelectedItem + " has helped " + patientName + " fill their prescription for " + drug + ".\n" +
                            patientName + " has purchased a bottle of " + comboBox1.SelectedItem + " for $ " + unitPrice + ".\n" +
                            "This prescription has " + a + " refills remaining.");
                    }
                    else if (a==0)
                    {
                        MessageBox.Show("Pharmacist " + comboBox1.SelectedItem + " has helped " + patientName + " fill their prescription for " + drug + ".\n" +
                           patientName + " has purchased a bottle of " + comboBox1.SelectedItem + " for $ " + unitPrice + ".\n" +
                           "This prescription has no more refills. A new prescription will need to be acquired before this drug is purchased again.");
                    }
                    else if(a<0)
                    {
                        MessageBox.Show("Pharmacist " + comboBox1.SelectedItem + " says " + patientName + " does not have a prescription for " + drug + ".\n" +
                        "Please visit a doctor and request an appropriate prescription.");
                    }
                }
                else if(selectedMedication.RequiresPrescription == true && comboBox1.SelectedItem != null)
                {
                    MessageBox.Show("Pharmacist "+comboBox1.SelectedItem+" says "+patientName+" does not have a prescription for "+drug+".\n" +
                        "Please visit a doctor and request an appropriate prescription.");
                }
                
            }
            else
            {
                MessageBox.Show("Please select a Drug for Purchase!", "ERROR!!!");
            }
        }
    }
}
