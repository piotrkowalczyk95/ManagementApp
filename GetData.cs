using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ExtensionMethods
{
    public static class GetData
    {
        public static DataTable getUserData(string connString, int userID)
        {
            DataTable dataTableUser = null;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select * FROM EMPLOYEE WHERE EmployeeID = @employeeID", con);
                cmd.Parameters.AddWithValue("@employeeID", userID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dataTableUser = new DataTable();
                adapter.Fill(dataTableUser);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(dataTableUser != null)
            {
                return dataTableUser;
            }
            else
            {
                return null;
            }
        }

        public static DataTable getProjectByID(string connString, int projectID)
        {
            DataTable dataTableProject = null;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select *" +
                    "                           FROM PROJECT " +
                    "                           WHERE ProjectID = @projectID", con);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dataTableProject = new DataTable();
                adapter.Fill(dataTableProject);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(dataTableProject != null)
            {
                return dataTableProject;
            }
            else
            {
                return null;
            }
        }

        public static DataTable getTaskByID(string connString, int taskID)
        {
            DataTable dataTableProject = null;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select *" +
                    "                           FROM TASK " +
                    "                           WHERE TaskID = @taskID", con);
                cmd.Parameters.AddWithValue("@taskID", taskID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dataTableProject = new DataTable();
                adapter.Fill(dataTableProject);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (dataTableProject != null)
            {
                return dataTableProject;
            }
            else
            {
                return null;
            }
        }
    }
}
