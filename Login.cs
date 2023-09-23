using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ManagementApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textboxUsername.Text == "" || textboxPassword.Text == "")
            {
                MessageBox.Show("Please provide Username and Password");
                return;
            }


            try
            {
                //Create SqlConnection
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select * from login where Username=@username and Pswrd=@password", con);
                cmd.Parameters.AddWithValue("@username", textboxUsername.Text);
                cmd.Parameters.AddWithValue("@password", textboxPassword.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapt.Fill(dataTable);
                con.Close();
                int count = dataTable.Rows.Count;
                if (count == 1)
                {
                    if (dataTable.Rows[0]["EmployeeID"] != DBNull.Value)
                    {
                        cmd = new SqlCommand("Select IsBlocked FROM EMPLOYEE WHERE EmployeeID = @employeeID", con);
                        cmd.Parameters.AddWithValue("@employeeID", (int)dataTable.Rows[0]["EmployeeID"]);
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable loginTable = new DataTable();
                        adapter.Fill(loginTable);
                        con.Close();
                       
                        if (loginTable.Rows[0]["IsBlocked"] != DBNull.Value)
                        {
                            if ((bool)loginTable.Rows[0]["IsBlocked"] == true)
                            {
                                MessageBox.Show("Account blocked. Login denied.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        bool loginFlag = (bool)dataTable.Rows[0]["LoginFlag"];
                        if (loginFlag == false)
                        {
                            PasswordChange passwordChange = new PasswordChange(textboxUsername.Text, textboxPassword.Text, connString);
                            passwordChange.ShowDialog();
                            textboxPassword.Text = null;
                        }
                        else
                        {
                            this.Hide();
                            Browser browser = new Browser(this, (int)dataTable.Rows[0]["EmployeeID"]);
                            browser.Show();
                            textboxUsername.Text = null;
                            textboxPassword.Text = null;
                        }
                    }
                    else
                    {
                        this.Hide();
                        Browser browser = new Browser(this, -1);
                        browser.Show();
                        textboxUsername.Text = null;
                        textboxPassword.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
