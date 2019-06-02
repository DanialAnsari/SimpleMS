using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    class DatabaseHelper
    {
        public SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public DatabaseHelper()
        {
            string connectionString = "Data Source=LAPTOP-N3NU3IOC;Initial Catalog=Rezone;Integrated Security=True";
            conn = new SqlConnection(connectionString);
            SqlConnection sc = new SqlConnection("");

        }

        public bool insertUpdateDelete(string query)
        {
            try
            {
                cmd = new SqlCommand(query, conn);
                conn.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    conn.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            conn.Close();
            return false;

        }

        public DataTable Search(string q)
        {
            try
            {
                cmd = new SqlCommand(q, conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return null;
        }

        public string[] insertIngridcombox(string field, string table)
        {
            string[] list = new string[10];

            conn.Open();


            string strCmd2 = "select " + field + " from " + table;
            SqlCommand cmd2 = new SqlCommand(strCmd2, conn);
            SqlDataReader myreader;
            myreader = cmd2.ExecuteReader();
            int i = 0;
            while (myreader.Read())
            {

                list[i] = Convert.ToString(myreader[0]);
                i++;
            }
            while (i < list.Length)
            {
                list[i] = "";
                i++;
            }

            myreader.Close();
            conn.Close();
            return list;


        } 

        //public bool insertDataWithImage(string v, PictureBox p, string q)
        //  {
        //      try
        //      {
        //          conn.Open();
        //          if (v == null)
        //          {
        //              cmd = new SqlCommand(q, conn);
        //          }
        //          else
        //          {
        //              byte[] img = null;
        //              FileStream fs = new FileStream(v, FileMode.Open, FileAccess.Read);
        //              BinaryReader br = new BinaryReader(fs);
        //              img = br.ReadBytes((int)fs.Length);

        //              cmd = new SqlCommand(q, conn);
        //              cmd.Parameters.Add("@img", img);


        //          }

        //          int count = cmd.ExecuteNonQuery();
        //          if (count > 0)
        //          {
        //              conn.Close();
        //              return true;
        //          }

        //      }
        //      catch (Exception ex)
        //      {
                  
        //      }
        //      conn.Close();
        //      return false;
        //  }   
    }
}

