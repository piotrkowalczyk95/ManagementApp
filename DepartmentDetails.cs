using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ExtensionMethods;

namespace ManagementApp
{
    public partial class DepartmentDetails : Form
    {

        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        int departmentID, userID;
        Int32 count1, count2;
        DataTable dataTableUser;

        public DepartmentDetails(int departmentID, int userID)
        {
            InitializeComponent();
            this.departmentID = departmentID;
            this.userID = userID;
            dataTableUser = ExtensionMethods.GetData.getUserData(connString, userID);
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT DepartmentName, DepartmentDesc FROM DEPARTMENT WHERE DepartmentID = @deptID", con);
                cmd.Parameters.AddWithValue("@deptID", departmentID);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapt.Fill(dataTable);

                labelName.Text = dataTable.Rows[0]["DepartmentName"].ToString();
                labelDesc.Text = dataTable.Rows[0]["DepartmentDesc"].ToString();

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(dataTableUser.Rows[0]["Permission"].ToString() == "Employee")
            {
                buttonDelete.Visible = false;
                buttonEdit.Visible = false;
                buttonEditEmp.Visible = false;
                buttonDelete.Enabled = false;
                buttonEdit.Enabled = false;
                buttonEditEmp.Enabled = false;
            }
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            AddDepartment addDepartment = new AddDepartment(departmentID, userID);
            addDepartment.ShowDialog();
            timerCheckChanges_Tick(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this department from database?\nThis action cannot be reverted.",
                "Delete department?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes)
            {
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd, cmdEmp;
                    con.Open();
                    cmd = new SqlCommand("SELECT COUNT(*) FROM DEPARTMENT", con);
                    count1 = (Int32)cmd.ExecuteScalar();
                    con.Close();

                    cmd = new SqlCommand("DELETE FROM DEPARTMENT WHERE DepartmentID = @deptID", con);
                    cmdEmp = new SqlCommand("UPDATE EMPLOYEE SET Department = NULL WHERE Department = @deptName", con);
                    cmd.Parameters.AddWithValue("@deptID", departmentID);
                    cmdEmp.Parameters.AddWithValue("deptName", labelName.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    cmdEmp.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("SELECT COUNT(*) FROM DEPARTMENT", con);
                    count2 = (Int32)cmd.ExecuteScalar();
                    con.Close();

                    if(count1 == count2 + 1)
                    {
                        MessageBox.Show("Deletion successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dialogResult = MessageBox.Show("Do you want to delete unfinished tasks and projects that were assigned to this department?", "Task and projects",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dialogResult == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("Delete FROM Task WHERE DEPARTMENT = @department AND TaskStatus != 'Accepted'", con);
                        cmd.Parameters.AddWithValue("@department", labelName.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        cmd = new SqlCommand("Delete FROM Project WHERE DEPARTMENT = @department ProjectStatus != 'Accepted'", con);
                        cmd.Parameters.AddWithValue("@department", labelName.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        cmd = new SqlCommand("UPDATE TASK SET DEPARTMENT = @nullVal WHERE DEPARTMENT = @department AND TaskStatus != 'Accepted'", con);
                        cmd.Parameters.AddWithValue("@nullVal", DBNull.Value);
                        cmd.Parameters.AddWithValue("@department", labelName.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        cmd = new SqlCommand("UPDATE PROJECT SET DEPARTMENT = @nullVal WHERE DEPARTMENT = @department AND TaskStatus != 'Accepted'", con);
                        cmd.Parameters.AddWithValue("@nullVal", DBNull.Value);
                        cmd.Parameters.AddWithValue("@department", labelName.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Dispose();
            }
        }

        private void timerCheckChanges_Tick(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT DepartmentName, DepartmentDesc FROM DEPARTMENT WHERE DepartmentID = @deptID", con);
                cmd.Parameters.AddWithValue("@deptID", departmentID);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapt.Fill(dataTable);

                labelName.Text = dataTable.Rows[0]["DepartmentName"].ToString();
                labelDesc.Text = dataTable.Rows[0]["DepartmentDesc"].ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEditEmp_Click(object sender, EventArgs e)
        {
            DepartmentEditEmp departmentEditEmp = new DepartmentEditEmp(labelName.Text, userID);
            departmentEditEmp.ShowDialog();
        }
    }
}
