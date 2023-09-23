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
    public partial class AddDepartment : Form
    {

        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";
        Int32 count1, count2;

        public AddDepartment()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            cmd = new SqlCommand("SELECT COUNT(*) FROM DEPARTMENT", con);
            con.Open();
            count1 = (Int32)cmd.ExecuteScalar();
            con.Close();
        }

        private int departmentID = -1;
        private int userID;

        private DataTable dataTableUser;

        public AddDepartment(int departmentID, int userID)
        {
            InitializeComponent();
            this.departmentID = departmentID;
            this.userID = userID;
            dataTableUser = ExtensionMethods.GetData.getUserData(connString, userID);
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            cmd = new SqlCommand("SELECT COUNT(*) FROM DEPARTMENT", con);
            con.Open();
            count1 = (Int32)cmd.ExecuteScalar();
            con.Close();
            cmd = new SqlCommand("SELECT DepartmentName, DepartmentDesc FROM DEPARTMENT WHERE DepartmentID = @deptID", con);
            cmd.Parameters.AddWithValue("@deptID", departmentID);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapt.Fill(dataTable);

            textBoxName.Text = dataTable.Rows[0]["DepartmentName"].ToString();
            textBoxDesc.Text = dataTable.Rows[0]["DepartmentDesc"].ToString();

            if(dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
            {
                textBoxName.Enabled = false;
            }

            con.Close();
        }

        private void newDepartment()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);

                SqlCommand cmdCheck = new SqlCommand("SELECT * FROM DEPARTMENT WHERE DepartmentName = @deptName", con);
                cmdCheck.Parameters.AddWithValue("@deptName", textBoxName.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmdCheck);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                con.Close();
                if (count != 0)
                {
                    MessageBox.Show("Department with that name already exists.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO DEPARTMENT(DepartmentName, DepartmentDesc) VALUES(@deptName, @deptDesc)", con);
                    cmd.Parameters.AddWithValue("@deptName", textBoxName.Text);
                    if (textBoxDesc.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@deptDesc", "not specified");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@deptDesc", textBoxDesc.Text);
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    cmd = new SqlCommand("SELECT COUNT(*) FROM DEPARTMENT", con);
                    con.Open();
                    count2 = (Int32)cmd.ExecuteScalar();
                    con.Close();

                    if (count1 + 1 == count2)
                    {
                        MessageBox.Show("Successfuly added department to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add department to database.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editDepartment()
        {
            try
            {

                SqlConnection con = new SqlConnection(connString);

                SqlCommand cmdCheck = new SqlCommand("SELECT * FROM DEPARTMENT WHERE DepartmentName = @deptName", con);
                cmdCheck.Parameters.AddWithValue("@deptName", textBoxName.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmdCheck);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                con.Close();
                if (count > 1)
                {
                    MessageBox.Show("Department with that name already exists.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("UPDATE DEPARTMENT SET DepartmentName = @deptName, DepartmentDesc = @deptDesc WHERE DepartmentID = @deptID", con);
                    cmd.Parameters.AddWithValue("@deptName", textBoxName.Text);
                    if (textBoxDesc.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@deptDesc", "not specified");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@deptDesc", textBoxDesc.Text);
                    }
                    cmd.Parameters.AddWithValue("@deptID", departmentID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    cmd = new SqlCommand("SELECT COUNT(*) FROM DEPARTMENT", con);
                    con.Open();
                    count2 = (Int32)cmd.ExecuteScalar();
                    con.Close();

                    if (count1 == count2)
                    {
                        MessageBox.Show("Successfuly modified department!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to modify department.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text == "")
            {
                MessageBox.Show("Please, fill the department's name.", "No department name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textBoxDesc.Text == "")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure that you want to proceed with no description?", "Description", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if(departmentID == -1)
            {
                newDepartment();
            }
            else
            {
                editDepartment();
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
