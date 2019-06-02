using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Complian
    {
        DatabaseHelper db = new DatabaseHelper();
        public DataTable GetComplainID()
        {
            DataTable dd;
            string q = "Select ComplainID from Complain";
            dd = db.Search(q);
            return dd;
        }

        public String GetComplain(int id)
        {
            DataTable dd;
            string q = "Select Complain from Complain where ComplainID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public string GetClientName(int id) {
            DataTable dd;
            string q = "Select FirstName from client inner join clientconfoirmed on client.clientid=clientconfoirmed.clientid inner join Complain on clientconfoirmed.clientID=Complain.Clientid where ComplainID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public string GetClientName2(int id)
        {
            DataTable dd;
            string q = "Select LastName from client inner join clientconfoirmed on client.clientid=clientconfoirmed.clientid inner join Complain on clientconfoirmed.clientID=Complain.Clientid where ComplainID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public String GetStatus(int id)
        {
            DataTable dd;
            string q = "Select Status from Complain where ComplainID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0]  [0]);
            return name;
        }

        public String GetDate(int id)
        {
            DataTable dd;
            string q = "Select DateOfComplain from Complain where ComplainID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public DataTable GetAll()
        {
            DataTable dd;
            string q = "Select ComplainID,Complain,DateOfComplain,Status,ClientID from Complain";
            dd = db.Search(q);
            return dd;
        }

    }
}
