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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //int comboBoxIndex = 0;
        public MainWindow()
        {
            InitializeComponent();

            dataGrid1.ItemsSource = PatientFile.allPatientList;
            comboBox1.ItemsSource = DoctorFile.allDoctorList;

        }

        public void RefreshDataGrid()
        {
            dataGrid1.ItemsSource = null;
            dataGrid1.ItemsSource = PatientFile.allPatientList;
        }

        void EmptyInputFields()
        {
            txtPatientFirstName.Text = "";
            txtPatientLastName.Text = "";
            txtDoctorFirstName.Text = "";
            txtDoctorLastName.Text = "";
        }
        int Healthcare = 1000007;
        private void btnAddNewPatient_Click(object sender, RoutedEventArgs e)
        {
            if(txtPatientFirstName.Text=="")
            {
                MessageBox.Show("Please enter the new patient's first name!!!", "ERROR!!!");
            }
            else if(txtPatientLastName.Text=="")
            {
                MessageBox.Show("Please enter the new patient's last name!!!", "ERROR!!!");
            }
            else if(txtPatientFirstName.Text != "" && txtPatientLastName.Text != "")
            {
                Healthcare++;
                string Name = txtPatientFirstName.Text + " " + txtPatientLastName.Text;
                Patient patientDetail = new Patient(Name, Healthcare);
                PatientFile.allPatientList.Add(patientDetail);
                MessageBox.Show("New patient file for " + Name + " has been created and added to the system.", "Successfully Added!!!");
                RefreshDataGrid();
                EmptyInputFields();
            }
        }

        private void btnRemovePatient_Click(object sender, RoutedEventArgs e)
        {
            Object selectedObject = dataGrid1.SelectedItem;
            if (selectedObject != null)
            {
                Patient selectedPerson = (Patient)dataGrid1.SelectedItem;
                string removeName = selectedPerson.Name;

                MessageBoxResult result = MessageBox.Show("Do you really want to remove " + removeName, "Remove??", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    PatientFile.allPatientList.Remove(selectedPerson);
                    RefreshDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a patient to remove!", "ERROR!!!");
            }
        }

        public void RefreshComboBox()
        {
            int comboBoxIndex = comboBox1.SelectedIndex;
            comboBox1.ItemsSource = null;
            comboBox1.ItemsSource = DoctorFile.allDoctorList;

            if (DoctorFile.allDoctorList.Count > comboBoxIndex)
            {
                comboBox1.SelectedIndex = comboBoxIndex;
            }
            //comboBox1.ItemsSource = DoctorFile.allDoctorList;
        }
        private void btnAddNewDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (txtDoctorFirstName.Text == "")
            {
                MessageBox.Show("Please enter the new doctor's first name!!!", "ERROR!!!");
            }
            else if (txtDoctorLastName.Text == "")
            {
                MessageBox.Show("Please enter the new doctor's last name!!!", "ERROR!!!");
            }
            else if (txtDoctorFirstName.Text != "" && txtDoctorLastName.Text != "")
            {
                string Name = "Dr. " + txtDoctorFirstName.Text + " " + txtDoctorLastName.Text;
                //Doctor doctorDetail = new Doctor(Name);
                //DoctorFile.allDoctorList.Add(doctorDetail);

                DoctorFile.allDoctorList.Add(Name);

                MessageBox.Show(Name + " has been created and added to the doctor registry.", "Successfully Added!!!");
                RefreshComboBox();
                EmptyInputFields();
            }
        }

        private void btnRemoveDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string name = comboBox1.SelectedItem.ToString();

                MessageBoxResult result = MessageBox.Show("Do you really want to remove " + name, "Remove??", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show(name + " has been removed from the doctor registry.");
                    DoctorFile.allDoctorList.Remove(name);
                    RefreshComboBox();
                }
                
            }
            else
            {
                MessageBox.Show("Please select a doctor to remove.", "ERROR!!!");
            }
        }

        private void btnPatientVisitDoctor_Click(object sender, RoutedEventArgs e)
        {
            //Object selectedObject = dataGrid1.SelectedItem;
            string name;
            if (dataGrid1.SelectedItem == null)
            {
                MessageBox.Show("Please select which patient is visiting the doctor.", "ERROR!!!");
            }
            else if (comboBox1.SelectedItem == null)
            {
                Patient selectedPerson = (Patient)dataGrid1.SelectedItem;
                name = selectedPerson.Name;
                MessageBox.Show("Please select a doctor for "+ name + " to visit.", "ERROR!!!");
            }
            else if(dataGrid1.SelectedItem != null && comboBox1.SelectedItem != null)
            {
                Patient selectedPerson = (Patient)dataGrid1.SelectedItem;
                name = selectedPerson.Name;
                Page patientVisitsDoctor = new PatientVisitsDoctor(this.Content, name, comboBox1.SelectedItem.ToString());
                this.Content = patientVisitsDoctor;
            }
        }

        private void btnPatientVisitPharmacy_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem == null)
            {
                MessageBox.Show("Please select a patient!!!", "ERROR!!!");
            }
            else if (dataGrid1.SelectedItem != null)
            {
                Patient selectedPerson = (Patient)dataGrid1.SelectedItem;
                string patientName = selectedPerson.Name;

                Page patientVisitPharmacy = new PatientVisitPharmacy(this.Content, patientName);
                this.Content = patientVisitPharmacy;
            }
        }
    }
}
