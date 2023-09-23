using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ManagementApp
{
    public partial class PositionChange : Form
    {

        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        private int employeeID; 
        protected Dictionary<int, string> dictionary;
        private string position, permission;
        public PositionChange(int employeeID, Dictionary<int, string> dictionary, string position, string permission)
        {
            InitializeComponent();
            this.employeeID = employeeID;
            this.dictionary = dictionary;
            this.position = position;
            this.permission = permission;

            if(permission == "Manager")
            {
                List<string> dataSource = new List<string>();
                dataSource.Add("Not assigned");
                dataSource.Add("Employee");
                comboBoxRoles.DataSource = dataSource;
            }

            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select Surname, FirstName FROM EMPLOYEE WHERE EmployeeID = @employeeID", con);
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            labelName.Text = dataTable.Rows[0]["Surname"].ToString() + " " + dataTable.Rows[0]["FirstName"].ToString();
            comboBoxRoles.Text = position;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            dictionary[employeeID] = comboBoxRoles.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
