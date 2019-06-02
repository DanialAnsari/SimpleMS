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
    public partial class ConfoirmedClient : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        Client ca = new Client();
        Confoirmedclient cs = new Confoirmedclient();
        Employees es = new Employees();
        public ConfoirmedClient()
        {
         
            InitializeComponent();
            try
            {
                DataTable dt = cs.GetAll();

            ccLientGrid.DataSource = dt;

           
                 dt = ca.GetClientID();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                       ccID.Items.Add(dt.Rows[i]["ClientID"].ToString());

                    }
                }

                dt = es.GetAll();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ccEmp.Items.Add(dt.Rows[i]["Name"].ToString());

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void ccID_SelectedIndexChanged(object sender, EventArgs e)
        {

            try { 
            int id = Convert.ToInt32(ccID.Text);
            ccFN.Text = ca.GetClientName(id);
            ccLN.Text = ca.GetClientName2(id);
            ccContact1.Text = ca.GetNumber1(id);

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



}

        private void add_Click(object sender, EventArgs e)
        {

            try { 
            int id = Convert.ToInt32(ccID.Text);
            string SoftwareType = ccSoft.Text;
            int Rent = Convert.ToInt32(ccRent.Text);
            int Main = Convert.ToInt32(ccEmail.Text);

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void button1_Click(object sender, EventArgs e)
        {

            try { 
            Form1 sh = new Form1();
            this.Hide();
            sh.ShowDialog();
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            Employee sh = new Employee();
            this.Hide();
            sh.ShowDialog();
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ccID_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            try { 
            int id = Convert.ToInt32(ccID.Text);
            ccFN.Text = ca.GetClientName(id);
            ccLN.Text = ca.GetClientName2(id);
            ccContact1.Text = ca.GetNumber1(id);
            ccEmail.Text = ca.Getemail(id);
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

}

        private void add_Click_1(object sender, EventArgs e)
        {
           

            try
            {
                int id = Convert.ToInt32(ccID.Text);
                string type = ccSoft.Text;
                int rent = Convert.ToInt32(ccRent.Text);
                int main = Convert.ToInt32(ccMain.Text);
                DataTable dd;
                string q = "Select EmployeeID from Employees where FirstName+' '+LastName='" + ccEmp.Text + "'";
                dd = db.Search(q);
                int empid = Convert.ToInt32(dd.Rows[0][0]);

                q = "Insert into clientconfoirmed Values(" + id + ",'" + type + "'," + rent + "," + main + "," + empid + ")";

                db.insertUpdateDelete(q);
                MessageBox.Show("Insertion Sucessful");
                ccID.Text = "";
                ccFN.Text = "";
                ccLN.Text = "";
                ccEmail.Text = "";
                ccContact1.Text = "";
                ccRent.Text = "";
                ccMain.Text = "";
                ccSoft.Text = "";
                ccEmp.Text = "";

                DataTable dt = cs.GetAll();

                ccLientGrid.DataSource = dt;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        
        }

        private void ccLientGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int current = ccLientGrid.CurrentRow.Index;

                int id = Convert.ToInt32(ccLientGrid.Rows[current].Cells[0].Value);
                int empid = Convert.ToInt32(ccLientGrid.Rows[current].Cells[9].Value);
                string q = "Select FirstName+' '+LastName from Employees where EmployeeID=" + empid + "";
               DataTable dd = db.Search(q);
                String empName = Convert.ToString(dd.Rows[0][0]);

                ccID.Text = Convert.ToString(id);
                ccFN.Text = ca.GetClientName(id);
                ccLN.Text = ca.GetClientName2(id);
                ccContact1.Text = ca.GetNumber1(id);
                ccEmail.Text = ca.Getemail(id);
                ccSoft.Text = cs.GetsoftwareType(id);
                ccRent.Text = Convert.ToString(cs.GetRent_Purchase(id));
                ccMain.Text = Convert.ToString(cs.Maintainence(id));
                ccEmp.Text = empName;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            

            try
            {
                int id = Convert.ToInt32(ccID.Text);

                string query = "Delete from clientconfoirmed where clientID=" + id;
                db.insertUpdateDelete(query);

                MessageBox.Show("Deletion SucessFul");

                ccID.Text = "";
                ccFN.Text = "";
                ccLN.Text = "";
                ccContact1.Text = "";
                ccEmail.Text = "";
                ccSoft.Text = "";
                ccRent.Text = "";
                ccMain.Text = "";
                ccEmp.Text = "";


                DataTable dt = cs.GetAll();

                ccLientGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
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

        private void ccContact1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void ccFN_TextChanged(object sender, EventArgs e)
        {
           
           
            }


        

        private void ccLN_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void ccSoft_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ccRent_TextChanged(object sender, EventArgs e)
        {
         

        }

        private void ccMain_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void ccFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void ccLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void ccContact1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void ccRent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void ccMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ccID.Text);
                DataTable dd;
                string q = "Select EmployeeID from Employees where FirstName+' '+LastName='" + ccEmp.Text + "'";
                dd = db.Search(q);
                int empid = Convert.ToInt32(dd.Rows[0][0]);
                string query = "Update clientconfoirmed set SoftwareType='" + ccSoft.Text + "',Rent_Purchase='" + ccRent.Text + "',Maintainence=" + ccMain.Text + ",EmployeeID='" + empid + "' where clientID=" + id;
                db.insertUpdateDelete(query);

                MessageBox.Show("Update SucessFul");

                ccID.Text = "";
                ccFN.Text = "";
                ccLN.Text = "";
                ccContact1.Text = "";
                ccEmail.Text = "";
                ccSoft.Text = "";
                ccRent.Text = "";
                ccMain.Text = "";
                ccEmp.Text = "";


                DataTable dt = cs.GetAll();

                ccLientGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
