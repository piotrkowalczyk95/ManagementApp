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
    public partial class DepartmentEditEmp : Form
    {
        private string departmentName;
        private bool isInitialized = false;
        Dictionary<int, string> dictionaryPermission;
        private int userID;
        private DataTable dataTableUser;

        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        private void getEmployees()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = null;
                string queryString = "Select Surname, FirstName, Permission, EmployeeID" +
                    "                           from EMPLOYEE where (Lower(FirstName) LIKE" +
                    "                           CONCAT('%', Lower(@search), '%') " +
                    "                           OR Lower(Surname) LIKE " +
                    "                           CONCAT('%', Lower(@search), '%'))";

                if (comboBoxView.Text == "All")
                {
                    queryString += " AND (Department IS NULL OR" +
                    "                Department = @department)" +
                    "                AND (Permission != 'Administrator'" +
                    "                OR Permission IS NULL)" +
                    "                AND ISBLOCKED = 0";
                }
                else if (comboBoxView.Text == "Employed in the department")
                {
                    queryString += " AND (Permission = 'Employee' OR " +
                    "                Permission = 'Manager') AND" +
                    "                Department = @department " +
                    "                AND ISBLOCKED = 0";
                }
                else if (comboBoxView.Text == "Employee" || comboBoxView.Text == "Manager")
                {
                    queryString += " AND (Permission = @permission) AND " +
                    "                Department = @department" +
                    "                AND ISBLOCKED = 0";
                }
                else if (comboBoxView.Text == "Not assigned")
                {
                    queryString += " AND Department IS null" +
                    "               AND PERMISSION IS NULL" +
                    "               AND ISBLOCKED = 0";
                }

                cmd = new SqlCommand(queryString, con);
                if (cmd != null)
                {
                    cmd.Parameters.AddWithValue("@search", textBoxSearch.Text);
                    cmd.Parameters.AddWithValue("@department", departmentName);
                    cmd.Parameters.AddWithValue("@permission", comboBoxView.Text);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewEmp.ReadOnly = true;
                    con.Close();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["Permission"] == DBNull.Value)
                        {
                            dataRow["Permission"] = "Not assigned";
                        }
                        if (dictionaryPermission.ContainsKey((int)dataRow["EmployeeID"]))
                        {
                            dataRow["Permission"] = dictionaryPermission[(int)dataRow["EmployeeID"]];
                        }
                        if (comboBoxView.Text == "Employed in the department")
                        {
                            if (dataRow["Permission"].ToString() == "Not assigned")
                            {
                                dataRow.Delete();
                                continue;
                            }
                        }
                        else if (comboBoxView.Text == "Employee")
                        {
                            if (dataRow["Permission"].ToString() != "Employee")
                            {
                                dataRow.Delete();
                                continue;
                            }
                        }
                        else if (comboBoxView.Text == "Manager")
                        {
                            if (dataRow["Permission"].ToString() != "Manager")
                            {
                                dataRow.Delete();
                                continue;
                            }
                        }
                        else if (comboBoxView.Text == "Not assigned")
                        {
                            if (dataRow["Permission"].ToString() != "Not assigned")
                            {
                                dataRow.Delete();
                                continue;
                            }
                        }
                        if (dataTableUser.Rows[0]["EmployeeID"] == dataRow["EmployeeID"])
                        {
                            dataRow.Delete();
                            continue;
                        }
                        dataTable.AcceptChanges();
                    }
                    foreach (var keyValuePair in dictionaryPermission)
                    {
                        cmd = new SqlCommand("Select Surname, FirstName, Permission, EmployeeID FROM EMPLOYEE" +
                            "                   WHERE (Lower(FirstName) LIKE" +
                    "                           CONCAT('%', Lower(@search), '%') " +
                    "                           OR Lower(Surname) LIKE " +
                    "                           CONCAT('%', Lower(@search), '%'))" +
                    "                           AND EmployeeID = @employeeID", con);
                        cmd.Parameters.AddWithValue("@employeeID", keyValuePair.Key);
                        cmd.Parameters.AddWithValue("@search", textBoxSearch.Text);
                        adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable1 = new DataTable();
                        adapter.Fill(dataTable1);
                        if(dataTable1.Rows.Count == 1)
                        {
                            if (dictionaryPermission.ContainsKey((int)dataTable1.Rows[0]["EmployeeID"]))
                            {
                                dataTable1.Rows[0]["Permission"] = dictionaryPermission[(int)dataTable1.Rows[0]["EmployeeID"]];
                            }
                        }
                        else
                        {
                            continue;
                        }
                        if (comboBoxView.Text == "Employed in the department" && (keyValuePair.Value == "Employee" || keyValuePair.Value == "Manager"))
                        {
                            DataRow dataRow = dataTable.NewRow();
                            dataRow = dataTable1.Rows[0];
                            dataTable.ImportRow(dataRow);
                        }
                        else if (comboBoxView.Text == "Employee" && keyValuePair.Value == "Employee")
                        {
                            DataRow dataRow = dataTable.NewRow();
                            dataRow = dataTable1.Rows[0];
                            dataTable.ImportRow(dataRow);
                        }
                        else if (comboBoxView.Text == "Manager" && keyValuePair.Value == "Manager")
                        {
                            DataRow dataRow = dataTable.NewRow();
                            dataRow = dataTable1.Rows[0];
                            dataTable.ImportRow(dataRow);
                        }
                        else if (comboBoxView.Text == "Not assigned" && keyValuePair.Value == "Not assigned")
                        {
                            DataRow dataRow = dataTable.NewRow();
                            dataRow = dataTable1.Rows[0];
                            dataTable.ImportRow(dataRow);
                        }
                    }
                    dataGridViewEmp.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DepartmentEditEmp(string departmentName, int userID)
        {
            InitializeComponent();
            this.departmentName = departmentName;
            this.userID = userID;
            dataGridViewEmp.RowHeadersVisible = false;
            dictionaryPermission = new Dictionary<int, string>();
            comboBoxView.SelectedItem = "All";
            dataTableUser = GetData.getUserData(connString, userID);

            isInitialized = true;

            getEmployees();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                
                foreach (KeyValuePair<int, string> keyValuePair in dictionaryPermission)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE EMPLOYEE SET Department = @department, Permission = @permission " +
                        "                           WHERE EmployeeID = @employeeID", con);

                    if(keyValuePair.Value == "Not assigned")
                    {
                        cmd.Parameters.AddWithValue("@department", DBNull.Value);
                        cmd.Parameters.AddWithValue("@permission", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@department", departmentName);
                        cmd.Parameters.AddWithValue("@permission", keyValuePair.Value);
                    }
                    cmd.Parameters.AddWithValue("@employeeID", keyValuePair.Key);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Successfuly commited changes!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this window?\nUnsubmitted changes will be lost.", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void dataGridViewEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if(dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && senderGrid["Position", e.RowIndex].Value.ToString() == "Manager")
                {
                    MessageBox.Show("Cannot edit other managers.", "Action not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    PositionChange positionChange;
                    if (senderGrid["Position", e.RowIndex].Value == DBNull.Value)
                    {
                        positionChange = new PositionChange((int)senderGrid["EmployeeID", e.RowIndex].Value, dictionaryPermission, "Not assigned", (string)dataTableUser.Rows[0]["Permission"]);
                    }
                    else
                    {
                        positionChange = new PositionChange((int)senderGrid["EmployeeID", e.RowIndex].Value, dictionaryPermission, (string)senderGrid["Position", e.RowIndex].Value, 
                                        (string)dataTableUser.Rows[0]["Permission"]);
                    }
                    positionChange.ShowDialog();
                    timerRefresh_Tick(sender, e);
                }
            }
        }

        private void comboBoxView_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerRefresh_Tick(sender, e);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            timerRefresh_Tick(sender, e);
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                getEmployees();
            }
        }

        private void buttonSubmitClose_Click(object sender, EventArgs e)
        {
            buttonSubmit_Click(sender, e);
            this.Close();
        }
    }
}
