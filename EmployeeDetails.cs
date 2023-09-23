using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ManagementApp
{
    public partial class EmployeeDetails : Form
    {

        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        private int employeeID, userID;
        private Int32 count1;
        private Int32 count2;
        private bool isBlocked;
        private DataTable dataTableUser, dataTable;

        private void getUserData()
        {
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
        }

        private void getEmployeeData()
        {
            isBlocked = false;
            dataTable = null;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT FirstName, Surname, Department, BirthDate, Pesel, Street, Apartment, Postcode, City, Permission," +
                    "               PhoneNumber, Email, IsBlocked FROM employee " +
                    "               WHERE EmployeeID = @employeeID", con);
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                adapt.Fill(dataTable);
                con.Close();

                labelName.Text = dataTable.Rows[0]["FirstName"].ToString();
                labelSurname.Text = dataTable.Rows[0]["Surname"].ToString();
                if (dataTable.Rows[0]["Department"] != DBNull.Value)
                {
                    labelDept.Text = dataTable.Rows[0]["Department"].ToString();
                    labelPos.Text = dataTable.Rows[0]["Permission"].ToString();
                }
                else
                {
                    labelDept.Text = "Not assigned";
                    labelPos.Text = "Not assigned";
                }

                DateTime birthDate = (DateTime)dataTable.Rows[0]["BirthDate"];
                labelBirth.Text = birthDate.ToString("yyyy-MM-dd");
                labelPesel.Text = dataTable.Rows[0]["Pesel"].ToString();
                if (dataTable.Rows[0]["Apartment"] != DBNull.Value)
                {
                    labelRes.Text = dataTable.Rows[0]["Street"].ToString() + "/" + dataTable.Rows[0]["Apartment"].ToString();
                }
                else
                {
                    labelRes.Text = dataTable.Rows[0]["Street"].ToString();
                }
                labelRes.Text += ", " + dataTable.Rows[0]["Postcode"].ToString() + " " + dataTable.Rows[0]["City"].ToString();

                if (dataTable.Rows[0]["PhoneNumber"] == DBNull.Value)
                {
                    labelPhone.Text = "Not specified";
                }
                else
                {
                    labelPhone.Text = dataTable.Rows[0]["PhoneNumber"].ToString();
                }

                if (dataTable.Rows[0]["Email"] == DBNull.Value)
                {
                    labelEmail.Text = "Not specified";
                }
                else
                {
                    labelEmail.Text = dataTable.Rows[0]["Email"].ToString();
                }

                if (Convert.ToBoolean(dataTable.Rows[0]["IsBlocked"]) == true)
                {
                    buttonBlock.Text = "Unlock Account";
                    isBlocked = true;
                }
                else
                {
                    isBlocked = false;
                }



                cmd = new SqlCommand("SELECT DISTINCT task.TaskName, task.DueDate, task.Priority, task.TaskStatus FROM task " +
                    "               INNER JOIN assigned_task ON assigned_task.TaskID = task.TaskID" +
                    "               WHERE assigned_task.EmployeeID = @employeeID" +
                    "               AND ProjectID IS NULL", con);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                con.Open();
                adapt = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                adapt.Fill(dataTable);
                dataTasks.DataSource = dataTable;
                con.Close();


                cmd = new SqlCommand("SELECT DISTINCT PROJECT.ProjectName, PROJECT.ProjectDue, PROJECT.ProjectPriority, PROJECT.PROJECTStatus " +
                    "               FROM PROJECT " +
                    "               INNER JOIN ASSIGNED_PROJECT ON assigned_PROJECT.ProjectID = PROJECT.ProjectID" +
                    "               WHERE ASSIGNED_PROJECT.EmployeeID = @employeeID" +
                    "               OR ProjectLeader = @pesel", con);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmd.Parameters.AddWithValue("@pesel", labelPesel.Text);
                con.Open();
                adapt = new SqlDataAdapter(cmd);
                dataTable = new DataTable();
                adapt.Fill(dataTable);
                dataProj.DataSource = dataTable;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public EmployeeDetails(int employeeID, int userID)
        {
            InitializeComponent();
            this.employeeID = employeeID;
            this.userID = userID;
            dataTasks.RowHeadersVisible = false;
            dataProj.RowHeadersVisible = false;
            getEmployeeData();
            
            if(dataTableUser != null && dataTable != null)
            {
                if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && dataTable.Rows[0]["Permission"].ToString() == "Manager")
                {
                    buttonAssign.Enabled = false;
                    buttonDelete.Enabled = false;
                    buttonEdit.Enabled = false;
                    buttonPassReset.Enabled = false;
                    buttonBlock.Enabled = false;
                }
                else if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                {
                    buttonBlock.Visible = false;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to remove this employee from database?\nThis action cannot be reverted.";
            string title = "Delete employee?";
            var res = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                isBlocked = true;
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd;
                    con.Open();

                    cmd = new SqlCommand("DELETE FROM assigned_task WHERE EmployeeID = @employeeID", con);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE FROM ASSIGNED_PROJECT WHERE EmployeeID = @employeeID", con);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE PROJECT SET ProjectLeader = NULL WHERE ProjectLeader = @pesel", con);
                    cmd.Parameters.AddWithValue("@pesel", labelPesel.Text);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT COUNT(*) FROM employee", con);
                    count1 = (Int32)cmd.ExecuteScalar();

                    cmd = new SqlCommand("DELETE FROM Login WHERE EmployeeID = @employeeID", con);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE FROM employee WHERE EmployeeID = @employeeID", con);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT COUNT(*) FROM employee", con);
                    count2 = (Int32)cmd.ExecuteScalar();

                    if(count1 == count2 + 1)
                    {
                        MessageBox.Show("Deletion successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete, please close this window and try again. If the problem persists contact administrator.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            AssignTask assignTask = new AssignTask(employeeID, userID);
            assignTask.ShowDialog();
            timerRefresh_Tick(sender, e);
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            getEmployeeData();
        }

        private string generatePassword()
        {
            string generatedPassword = "";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                generatedPassword = generatedPassword + chars[random.Next(chars.Length)];
            }
            return generatedPassword;
        }

        private void buttonPassReset_Click(object sender, EventArgs e)
        {
            string password = null;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("UPDATE Login Set Pswrd = @password, WHERE EmployeeID = @empID", con);
                password = generatePassword();
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@empID", employeeID);
                con.Open();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(password != null)
            {
                MessageBox.Show("New password: " + password +"\nPassword coppied to clipboard.", "Reset success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetText(password);
            }
            else
            {
                MessageBox.Show("Password could not be reset, please try again.", "Reset failure.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee(userID, employeeID);
            addEmployee.ShowDialog();
            timerRefresh_Tick(sender, e);
        }

        private void dataTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow dataRow in dataTasks.Rows)
            {
                if ((DateTime)dataRow.Cells["DueDate"].Value < DateTime.Now)
                {
                    dataRow.Cells["DueDate"].Style.ForeColor = Color.DarkRed;
                }
                else if (((DateTime)dataRow.Cells["DueDate"].Value - DateTime.Now).TotalDays < 1)
                {
                    dataRow.Cells["DueDate"].Style.ForeColor = Color.Orange;
                }
            }
        }

        private void buttonProjects_Click(object sender, EventArgs e)
        {
            AssignProject assignProject = new AssignProject(employeeID, userID);
            assignProject.ShowDialog();
            timerRefresh_Tick(sender, e);
        }

        private void buttonBlock_Click(object sender, EventArgs e)
        {
            if(isBlocked == false)
            {
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("UPDATE EMPLOYEE SET IsBlocked = 1 WHERE EmployeeID = @employeeID", con);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    buttonBlock.Text = "Unlock Account";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("UPDATE EMPLOYEE SET IsBlocked = 0 WHERE EmployeeID = @employeeID", con);
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    buttonBlock.Text = "Block Account";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            timerCheckChanges_Tick(sender, e);
        }

        private void timerCheckChanges_Tick(object sender, EventArgs e)
        {
            getEmployeeData();
        }
    }
}
