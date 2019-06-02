using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Employees
    {
        DatabaseHelper db = new DatabaseHelper();
        public DataTable GetEmployeeID()
        {
            DataTable dd;
            string q = "Select EmployeeID from Employees";
            dd = db.Search(q);
            return dd;
        }

        public String GetEmployeeName1(int id)
        {
            DataTable dd;
            string q = "Select FirstName from Employees where EmployeeID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public String GetEmployeeName2(int id)
        {
            DataTable dd;
            string q = "Select LastName from Employees where EmployeeID="+ id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public String GetContact1(int id)
        {
            DataTable dd;
            string q = "Select Contact1 from Employees where EmployeeID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public String GetContact2(int id)
        {
            DataTable dd;
            string q = "Select Contact2 from Employees where EmployeeID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public String GetEmail(int id)
        {
            DataTable dd;
            string q = "Select Email from Employees where EmployeeID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public String GetCNIC(int id)
        {
            DataTable dd;
            string q = "Select CNIC from Employees where EmployeeID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public DataTable GetAll()
        {
            DataTable dd;
            string q = "Select EmployeeID,FirstName+' '+LastName as Name,Contact1,Contact2,email,CNIC from Employees";
            dd = db.Search(q);
            return dd;
        }



    }
}
