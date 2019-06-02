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
    public partial class ClientComplain : Form
    {

        DatabaseHelper db = new DatabaseHelper();
        Client ca = new Client();
       Confoirmedclient cc = new Confoirmedclient();
        Complian cs = new Complian();
        public ClientComplain()
        {
            InitializeComponent();

            try
            {
                DataTable dt = cs.GetAll();

                ccLientGrid.DataSource = dt;


                dt = cc.GetClientID();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ccID.Items.Add(dt.Rows[i]["ClientID"].ToString());

                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            }

        private void ccID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ccID_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            try
            {
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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Form1 sh = new Form1();
                this.Hide();
                sh.ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
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

            try
            {
                Employee sh = new Employee();
                this.Hide();
                sh.ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

        }

        private void add_Click(object sender, EventArgs e)
        {

            try
            {
                int clientID = Convert.ToInt32(ccID.Text);
                int compID = Convert.ToInt32(cCompID.Text);
                string Complain = cComplain.Text;
                string status = cStatus.Text;
                string Date = cDate.Text;

                string query = "Insert into Complain Values("+compID+",'"+Complain+"','"+clientID+"','"+status+"','"+Date+"')";
                db.insertUpdateDelete(query);
                MessageBox.Show("Insertion SucessFul");

                ccID.Text = "";
                cCompID.Text = "";
                cComplain.Text = "";
                cStatus.Text = "";
                cDate.Text = "";
                ccFN.Text = "";
                ccLN.Text = "";
                ccContact1.Text = "";
                ccEmail.Text = "";

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
                int clientid= Convert.ToInt32(ccLientGrid.Rows[current].Cells[4].Value);
                cCompID.Text = Convert.ToString(id);
                cComplain.Text = cs.GetComplain(id);
                cStatus.Text = cs.GetStatus(id);
                cDate.Text = cs.GetDate(id);
                ccID.Text = Convert.ToString(clientid);
                ccContact1.Text = ca.GetNumber1(clientid);
                ccEmail.Text = ca.Getemail(clientid);
                ccFN.Text = ca.GetClientName(clientid);
                ccLN.Text = ca.GetClientName2(clientid);
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cCompID.Text);

                string query = "Delete from complain where ComplainID=" + id;
                db.insertUpdateDelete(query);

                MessageBox.Show("Deletion SucessFul");

                ccID.Text = "";
                ccFN.Text = "";
                ccLN.Text = "";
                ccContact1.Text = "";
                ccEmail.Text = "";
                cCompID.Text = "";
                cStatus.Text = "";
                cComplain.Text = "";
                cDate.Text = "";
                


                DataTable dt = cs.GetAll();

                ccLientGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void cCompID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cCompID.Text);

                string query = "Update complain set Complain='"+cComplain.Text+"',status='"+cStatus.Text+"',ClientID="+Convert.ToInt32(ccID.Text)+",DateOfComplain='"+cDate.Text+"' where ComplainID=" + id;
                db.insertUpdateDelete(query);

                MessageBox.Show("Update SucessFul");

                ccID.Text = "";
                ccFN.Text = "";
                ccLN.Text = "";
                ccContact1.Text = "";
                ccEmail.Text = "";
                cCompID.Text = "";
                cStatus.Text = "";
                cComplain.Text = "";
                cDate.Text = "";



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
