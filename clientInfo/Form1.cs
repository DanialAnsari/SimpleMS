using ConsoleApplication1;
using System;
using System.Data;
using System.Windows.Forms;

namespace clientInfo
{
    public partial class Form1 : Form
    {

        Client cs = new Client();
        DatabaseHelper db = new DatabaseHelper();
        public Form1()
        {
            InitializeComponent();

            DataTable dt = cs.GetAll();

            cLientGrid.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
            int id = Convert.ToInt32(cID.Text);
            string FirstName = cFN.Text;
            string LastName = cLN.Text;
            string contact1 = cContact1.Text;
            string contact2;
            if (cContact2.Equals("")) {
                contact2 = null;
            }
             contact2 = cContact2.Text;
            string email = cEmail.Text;
            string Address = cAddress.Text;
            string comment = cComment.Text;
            string Date = cDate.Text;

           
                db.insertUpdateDelete("Insert into client Values(" + id + ",'" + FirstName + "','" + LastName + "','" + contact1 + "','" + contact2 + "','" + email + "','"+Address+"','" + comment + "','" + Date + "')");
                MessageBox.Show("Data Added Sucessfully");
                DataTable dt = cs.GetAll();

                cLientGrid.DataSource = dt;

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            
            }

        private void cLientGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int current = cLientGrid.CurrentRow.Index;

                int id = Convert.ToInt32(cLientGrid.Rows[current].Cells[0].Value);

                cID.Text = Convert.ToString(id);
                cFN.Text = cs.GetClientName(id);
                cLN.Text = cs.GetClientName2(id);
                cContact1.Text = cs.GetNumber1(id);
                cContact2.Text = cs.GetNumber2(id);
                cEmail.Text = cs.Getemail(id);
                cDate.Text = cs.GetDate(id);
                cAddress.Text = cs.GetAdress(id);
                cComment.Text = cs.GetAdress(id);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            }

        private void delete_Click(object sender, EventArgs e)
        {
            

            try
            {
                int id = Convert.ToInt32(cID.Text);
                db.insertUpdateDelete("Delete from client where ClientID=" + id);
                MessageBox.Show("The selected Entry has been Deleted");
                cID.Text = "";
                cFN.Text = "";
                cLN.Text = "";
                cContact1.Text = "";
                cContact2.Text = "";
                cEmail.Text = "";
                cAddress.Text = "";
                cComment.Text = "";

                DataTable dt = cs.GetAll();

                cLientGrid.DataSource = dt;
            }
            catch (Exception ex) {
                MessageBox.Show(Convert.ToString(ex));
            }

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ConfoirmedClient sh = new ConfoirmedClient();
            this.Hide();
            sh.ShowDialog();
            this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
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
            catch (Exception ex) {
                MessageBox.Show(Convert.ToString(ex));
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

        private void cID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cContact1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void cContact2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cID.Text);
                db.insertUpdateDelete("Update client set FirstName='" + cFN.Text + "',LastName='" + cLN.Text + "',Number#1=" + cContact1.Text + ",Number#2='" + cContact2.Text + "',email='" + cEmail.Text + "',Address='" + cAddress.Text + "',Comment='" + cComment.Text + "',Date='" + cDate.Text + "' where ClientID=" + id);
                MessageBox.Show("Update Sucessful");
                cID.Text = "";
                cFN.Text = "";
                cLN.Text = "";
                cContact1.Text = "";
                cContact2.Text = "";
                cEmail.Text = "";
                cAddress.Text = "";
                cComment.Text = "";

                DataTable dt = cs.GetAll();

                cLientGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }
    }
}
