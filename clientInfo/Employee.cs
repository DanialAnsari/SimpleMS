using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientInfo
{
    public partial class Employee : Form
    {
        Employees es = new Employees();
        DatabaseHelper db = new DatabaseHelper();
        public Employee()
        {
            try { 
            InitializeComponent();
            DataTable dt = es.GetAll();

            EmployeeGrid.DataSource = dt;
        }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }


}

        private void add_Click(object sender, EventArgs e)
        {
           

            try
            {
                int id = Convert.ToInt32(eID.Text);
                string FirstName = eFN.Text;
                string LastName = eLN.Text;
                string Number1 = eContact1.Text;
                string Number2 = eContact2.Text;
                string email = eEmail.Text;
                string CNIC = eCNIC.Text;
                string query = "Insert into Employees Values(" + id + ",'" + FirstName + "','" + LastName + "','" + Number1 + "','" + Number2 + "','" + email + "','" + CNIC + "')";
                db.insertUpdateDelete(query);
                MessageBox.Show("Insertion Sucessful");
                eID.Text = "";
                eFN.Text = "";
                eLN.Text = "";
                eContact1.Text = "";
                eContact2.Text = "";
                eEmail.Text = "";
                eCNIC.Text = "";

                DataTable dt = es.GetAll();

                EmployeeGrid.DataSource = dt;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void EmployeeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int current = EmployeeGrid.CurrentRow.Index;

            int id = Convert.ToInt32(EmployeeGrid.Rows[current].Cells[0].Value);

            eID.Text = Convert.ToString(id);
            eFN.Text = es.GetEmployeeName1(id);
            eLN.Text = es.GetEmployeeName2(id);
            eContact1.Text = es.GetContact1(id);
            eContact2.Text = es.GetContact2(id);
            eEmail.Text = es.GetEmail(id);
            eCNIC.Text = es.GetCNIC(id);
        }

        private void delete_Click(object sender, EventArgs e)
        {
           

            try
            {
                int id = Convert.ToInt32(eID.Text);

                string query = "Delete from Employees where EmployeeID=" + id;
                db.insertUpdateDelete(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                MessageBox.Show("Deletion SucessFul");

            eID.Text = "";
            eFN.Text = "";
            eLN.Text = "";
            eContact1.Text = "";
            eContact2.Text = "";
            eEmail.Text = "";
            eCNIC.Text = "";


            DataTable dt = es.GetAll();

            EmployeeGrid.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 sh = new Form1();
            this.Hide();
            sh.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            ConfoirmedClient sh = new ConfoirmedClient();
            this.Hide();
            sh.ShowDialog();
            this.Close();

        }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
}

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                ClientComplain sh = new ClientComplain();
                this.Hide();
                sh.ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

        }

        private void eID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void eFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void eLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void eContact1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void eContact2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(eID.Text);

                string query = "Update employees set FirstName='" + eFN.Text + "',LastName='" + eLN.Text + "',Contact1=" + eContact1.Text + ",Contact2='" + eContact2.Text + "',email='" + eEmail.Text + "',CNIC='" + eCNIC.Text + "' where EmployeeID=" + id;
                db.insertUpdateDelete(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Update SucessFul");

            eID.Text = "";
            eFN.Text = "";
            eLN.Text = "";
            eContact1.Text = "";
            eContact2.Text = "";
            eEmail.Text = "";
            eCNIC.Text = "";


            DataTable dt = es.GetAll();

            EmployeeGrid.DataSource = dt;
        }
    }
}