using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeApplication
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        public interface IEmployee
        {
            string FirstName { get; set; }
            string LastName { get; set; }
            string Department { get; set; }
            string JobTitle { get; set; }
            double BasicSalary { get; set; }

            void ComputeSalary(int hoursWorked, double ratePerHour);
        }

        public class PartTimeEmployee : IEmployee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Department { get; set; }
            public string JobTitle { get; set; }
            public double BasicSalary { get; set; }

            public PartTimeEmployee(string fName, string lName, string dept, string job)
            {
                FirstName = fName;
                LastName = lName;
                Department = dept;
                JobTitle = job;
                BasicSalary = 0;
            }

            public void ComputeSalary(int hoursWorked, double ratePerHour)
            {
                BasicSalary = hoursWorked * ratePerHour;
              
            }

            public double GetSalary()
            {
           
                return BasicSalary;
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            string firstname = txtFirst.Text;
            string lastname = txtLast.Text;
            string department = txtDepartment.Text;
            string jobtitle = txtJob.Text;
            int hoursWorked = Convert.ToInt32(txtTotalHrs.Text);
            double rate = Convert.ToDouble(txtRate.Text);

            PartTimeEmployee partTime = new PartTimeEmployee(firstname, lastname, department, jobtitle);
            partTime.ComputeSalary(hoursWorked, rate);

           
            lblFirst.Text = firstname;
            lblLast.Text = lastname;
            lblSalary.Text = $"{partTime.GetSalary():F2}";
            lblDepartment.Text = department;
            lblJob.Text = jobtitle;

            txtFirst.Clear();
            txtLast.Clear();
            txtJob.Clear();
            txtDepartment.Clear();
            txtTotalHrs.Clear();
            txtRate.Clear();



        }
    }
}
