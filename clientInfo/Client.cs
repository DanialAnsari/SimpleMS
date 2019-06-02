using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Client
    {
        DatabaseHelper db = new DatabaseHelper();
        public DataTable GetClientID()
        {
            DataTable dd;
            string q = "Select ClientID from client";
            dd = db.Search(q);
            return dd;

        }

        public string GetClientName(int id)
        {
            DataTable dd;
            string q = "Select FirstName from client where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);

            return name;

        }

        public string GetClientName2(int id)
        {
            DataTable dd;
            string q = "Select LastName from client where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);

            return name;

        }

        public string GetNumber1(int id)
        {
            DataTable dd;
            string q = "Select Number#1 from client where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);

            return name;

        }

        public string GetNumber2(int id)
        {
            DataTable dd;
            string q = "Select Number#2 from client where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);

            return name;

        }

        public string Getemail(int id)
        {
            DataTable dd;
            string q = "Select email from client where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);

            return name;

        }

        public string GetAdress(int id)
        {
            DataTable dd;
            string q = "Select Address from client where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);

            return name;

        }

        public string GetComment(int id)
        {
            DataTable dd;
            string q = "Select comment from client where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);

            return name;

        }

        public string GetDate(int id)
        {
            DataTable dd;
            string q = "Select Date from client where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }



        public DataTable GetAll()
        {
            DataTable dd;
            string q = "Select ClientID,FirstName,LastName,Number#1,Number#2,email,Date from client";
            dd = db.Search(q);
            return dd;


        }
    }

    public class Confoirmedclient
    {
        DatabaseHelper db = new DatabaseHelper();



        public DataTable GetClientID()
        {
            DataTable dd;
            string q = "Select ClientID from clientconfoirmed";
            dd = db.Search(q);
            return dd;

        }
        public string GetsoftwareType(int id) {
            DataTable dd;
            string q = "Select SoftwareType from clientconfoirmed where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public int GetRent_Purchase(int id) {
            DataTable dd;
            string q = "Select Rent_Purchase from clientconfoirmed where ClientID=" + id;
            dd = db.Search(q);
            int name = Convert.ToInt32(dd.Rows[0][0]);
            return name;
        }

        public int Maintainence(int id)
        {
            DataTable dd;
            string q = "Select Maintainence from clientconfoirmed where ClientID=" + id;
            dd = db.Search(q);
            int name = Convert.ToInt32(dd.Rows[0][0]);
            return name;
        }

        public string GetComment(int id)
        {
            DataTable dd;
            string q = "Select comment from clientconfoirmed where ClientID=" + id;
            dd = db.Search(q);
            String name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public string EmployeeName(int id)
        {
            DataTable dd;
            string q = "Select FirstName+LastName from Employees inner join clientconfoirmed on Employees.EmployeeID=clientconfoirmed.EmployeeID where ClientID=" + id;
            dd = db.Search(q);
            string name = Convert.ToString(dd.Rows[0][0]);
            return name;
        }

        public DataTable GetAll()
        {
            DataTable dd;
            string q = "Select client.ClientID,FirstName+' '+LastName as Name,Number#1,Number#2,email,Date,SoftwareType,Rent_Purchase,Maintainence,EmployeeID from client inner join clientconfoirmed on client.clientID=clientconfoirmed.clientID";
            dd = db.Search(q);
            return dd;
        }

    }
}
