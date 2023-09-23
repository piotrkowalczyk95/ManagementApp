using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ExtensionMethods;

namespace ManagementApp
{
    public partial class AssignTask : Form
    {
        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        private int employeeID, userID, select;
        private Int32 count1;
        private Int32 count2;
        private bool isInitialized = false;
        private bool isProject = false;
        Dictionary<int, bool> keyValuePairs;
        DataTable dataTableUser, dataTable;
        List<string> dataSourceDept, dataSourceStatus;

        private void getListDept()
        {
            try
            {
                dataSourceDept = new List<string>();
                dataSourceDept.Add("All");
                if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("SELECT DepartmentName FROM DEPARTMENT", con);
                    DataTable dataTable = new DataTable();
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        dataSourceDept.Add(dataRow["DepartmentName"].ToString());
                    }
                }
                else
                {
                    dataSourceDept.Add(dataTableUser.Rows[0]["Department"].ToString());
                }
                dataSourceDept.Add("Not assigned");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getTasks()
        {
            try
            {
                SqlCommand cmd = null;
                SqlConnection con = new SqlConnection(connString);
                dataTable = new DataTable();
                
                if (select == 1)
                {
                    string queryString = "Select TaskName, Priority, DueDate, TaskStatus, Department, TaskID FROM TASK " +
                        "                           where (Lower(TaskName) LIKE " +
                        "                           CONCAT('%', Lower(@searchTask), '%'))";
                    buttonAll.BackColor = Color.CornflowerBlue;
                    buttonAll.ForeColor = Color.White;
                    buttonAssigned.BackColor = DefaultBackColor;
                    buttonAssigned.ForeColor = DefaultForeColor;
                    buttonNotAssigned.BackColor = DefaultBackColor;
                    buttonNotAssigned.ForeColor = DefaultForeColor;
                    if (comboBoxDepartment.SelectedItem.ToString() != "All" && comboBoxDepartment.SelectedItem.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                    }
                    else if(comboBoxDepartment.SelectedItem.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL";
                    }
                    if(comboBoxStatus.SelectedItem.ToString() != "All")
                    {
                        queryString += " AND (TaskStatus = @status AND TaskStatus != 'Accepted'";
                    }
                    queryString += " AND ProjectID IS NULL";
                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@searchTask", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@status", comboBoxStatus.SelectedItem.ToString());
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();
                    foreach(DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["Department"] == DBNull.Value)
                        {
                            dataRow["Department"] = "Not assigned";
                        }
                    }
                    dataTask.ReadOnly = true;
                    dataTask.AutoGenerateColumns = false;
                    dataTask.DataSource = dataTable;
                }
                else if (select == 2)
                {
                    string queryString = "Select TaskName, Priority, DueDate, TaskStatus, Department, TASK.TaskID FROM TASK " +
                        "                           INNER JOIN ASSIGNED_TASK " +
                        "                           ON TASK.TaskID = ASSIGNED_TASK.TaskID " +
                        "                           AND ASSIGNED_TASK.EmployeeID = @employeeID" +
                        "                           where (Lower(TaskName) LIKE " +
                        "                           CONCAT('%', Lower(@searchTask), '%'))";
                    buttonAssigned.BackColor = Color.CornflowerBlue;
                    buttonAssigned.ForeColor = Color.White;
                    buttonAll.BackColor = DefaultBackColor;
                    buttonAll.ForeColor = DefaultForeColor;
                    buttonNotAssigned.BackColor = DefaultBackColor;
                    buttonNotAssigned.ForeColor = DefaultForeColor;

                    if (comboBoxDepartment.SelectedItem.ToString() != "All" && comboBoxDepartment.SelectedItem.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                    }
                    else if (comboBoxDepartment.SelectedItem.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL";
                    }
                    if (comboBoxStatus.SelectedItem.ToString() != "All")
                    {
                        queryString += " AND (TaskStatus = @status AND TaskStatus != 'Accepted')";
                    }
                    queryString += " AND ProjectID IS NULL";
                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@searchTask", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@status", comboBoxStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();
                    if(dataTable.Columns["TASK.TaskID"] != null)
                    {
                        dataTable.Columns["TASK.TaskID"].ColumnName = "TaskID";
                    }
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (keyValuePairs.ContainsKey((int)dataRow["TaskID"]))
                        {
                            if (keyValuePairs[(int)dataRow["TaskID"]] == false)
                            {
                                dataRow.Delete();
                            }
                        }
                    }
                    dataTable.AcceptChanges();

                    DataTable dataTable1 = new DataTable();
                    foreach (KeyValuePair<int, bool> keyValuePair in keyValuePairs)
                    {
                        if (keyValuePair.Value == true)
                        {
                            queryString = "Select TaskName, Priority, DueDate, TaskStatus, Department, TaskID FROM TASK " +
                            "                           WHERE NOT EXISTS(SELECT NULL FROM ASSIGNED_TASK " +
                            "                           WHERE TASK.TaskID = ASSIGNED_TASK.TaskID" +
                            "                           AND ASSIGNED_TASK.EmployeeID = @employeeID) " +
                            "                           AND (Lower(TaskName) LIKE " +
                            "                           CONCAT('%', Lower(@searchTask), '%'))" +
                            "                           AND TaskID = @taskID";

                            if (comboBoxDepartment.SelectedItem.ToString() != "All" && comboBoxDepartment.SelectedItem.ToString() != "Not assigned")
                            {
                                queryString += " AND Department = @department";
                            }
                            else if (comboBoxDepartment.SelectedItem.ToString() == "Not assigned")
                            {
                                queryString += " AND DEPARTMENT IS NULL";
                            }
                            if (comboBoxStatus.SelectedItem.ToString() != "All")
                            {
                                queryString += " AND (TaskStatus = @status)";
                            }
                            else
                            {
                                queryString += " AND TaskStatus != 'Accepted'";
                            }
                            queryString += " AND ProjectID IS NULL";
                            cmd = new SqlCommand(queryString, con);
                            cmd.Parameters.AddWithValue("@searchTask", textboxSearch.Text);
                            cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                            cmd.Parameters.AddWithValue("@status", comboBoxStatus.Text.ToString());
                            cmd.Parameters.AddWithValue("@taskID", keyValuePair.Key);
                            cmd.Parameters.AddWithValue("@employeeID", employeeID);
                            con.Open();
                            adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dataTable1);
                            con.Close();

                            DataRow dataRow = dataTable.NewRow();
                            if (dataTable1.Rows.Count > 0)
                            {
                                dataRow = dataTable1.Rows[0];
                                dataTable.ImportRow(dataRow);
                            }
                        }

                    }

                    foreach(DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["Department"] == DBNull.Value)
                        {
                            dataRow["Department"] = "Not assigned";
                        }
                    }

                    dataTask.ReadOnly = true;
                    dataTask.DataSource = dataTable;

                    if(dataTask.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow dataGridViewRow in dataTask.Rows)
                        {
                            dataGridViewRow.Cells["SelectTask"].Value = true;
                        }
                    }
                    
                }
                else if (select == 3)
                {
                    string queryString = "Select TaskName, Priority, DueDate, TaskStatus, Department, TaskID" +
                        "                           FROM TASK " +
                        "                           WHERE NOT EXISTS(SELECT NULL FROM ASSIGNED_TASK " +
                        "                           WHERE TASK.TaskID = ASSIGNED_TASK.TaskID" +
                        "                           AND ASSIGNED_TASK.EmployeeID = @employeeID) " +
                        "                           AND (Lower(TaskName) LIKE " +
                        "                           CONCAT('%', Lower(@searchTask), '%'))";
                    buttonNotAssigned.BackColor = Color.CornflowerBlue;
                    buttonNotAssigned.ForeColor = Color.White;
                    buttonAll.BackColor = DefaultBackColor;
                    buttonAll.ForeColor = DefaultForeColor;
                    buttonAssigned.ForeColor = DefaultForeColor;
                    buttonAssigned.BackColor = DefaultBackColor;
                    if (comboBoxDepartment.SelectedItem.ToString() != "All" && comboBoxDepartment.SelectedItem.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                    }
                    else if (comboBoxDepartment.SelectedItem.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL";
                    }
                    if (comboBoxStatus.SelectedItem.ToString() != "All")
                    {
                        queryString += "AND (TaskStatus = @status AND TaskStatus != 'Accepted'";
                    }
                    queryString += " AND ProjectID IS NULL";
                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@searchTask", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@status", comboBoxStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (keyValuePairs.ContainsKey((int)dataRow["TaskID"]))
                        {
                            if (keyValuePairs[(int)dataRow["TaskID"]] == true)
                            {
                                dataRow.Delete();
                            }
                        }
                    }
                    dataTable.AcceptChanges();

                    DataTable dataTable1 = new DataTable();
                    foreach (KeyValuePair<int, bool> keyValuePair in keyValuePairs)
                    {
                        if (keyValuePair.Value == false)
                        {
                            queryString = "Select TaskName, Priority, DueDate, TaskStatus, Department, t.TaskID " +
                                "           FROM [TASK] t " +
                                "           INNER JOIN ASSIGNED_TASK a" +
                                "           ON t.TaskID = a.TaskID " +
                                "           AND a.EmployeeID = @employeeID" +
                                "           where (Lower(TaskName) LIKE " +
                                "           CONCAT('%', Lower(@searchTask), '%'))" +
                                "           AND t.TaskID = @taskID";
                            if (comboBoxDepartment.SelectedItem.ToString() != "All" && comboBoxDepartment.SelectedItem.ToString() != "Not assigned")
                            {
                                queryString += " AND Department = @department";
                            }
                            else if (comboBoxDepartment.SelectedItem.ToString() == "Not assigned")
                            {
                                queryString += " AND DEPARTMENT IS NULL";
                            }
                            if (comboBoxStatus.SelectedItem.ToString() != "All")
                            {
                                queryString += " AND (TaskStatus = @status)";
                            }
                            else
                            {
                                queryString += " AND TaskStatus != 'Accepted'";
                            }
                            queryString += " AND ProjectID IS NULL";
                            cmd = new SqlCommand(queryString, con);
                            cmd.Parameters.AddWithValue("@searchTask", textboxSearch.Text);
                            cmd.Parameters.AddWithValue("@department", comboBoxDepartment.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@status", comboBoxStatus.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@taskID", keyValuePair.Key);
                            cmd.Parameters.AddWithValue("@employeeID", employeeID);
                            con.Open();
                            adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(dataTable1);
                            con.Close();
                            if (dataTable1.Columns["t.TaskID"] != null)
                            {
                                dataTable1.Columns["t.TaskID"].ColumnName = "TaskID";
                            }
                            DataRow dataRow = dataTable.NewRow();
                            if(dataTable1.Rows.Count > 0)
                            {
                                dataRow = dataTable1.Rows[0];
                                dataTable.ImportRow(dataRow);
                            }
                        }
                    }

                    foreach(DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["Department"] == DBNull.Value)
                        {
                            dataRow["Department"] = "Not assigned";
                        }
                    }

                    dataTask.ReadOnly = true;
                    dataTask.DataSource = dataTable;

                    if (dataTask.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow dataGridViewRow in dataTask.Rows)
                        {
                            dataGridViewRow.Cells["SelectTask"].Value = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public AssignTask(int employeeID, int userID)
        {
            InitializeComponent();
            this.employeeID = employeeID;
            this.userID = userID;
            dataTask.Columns["TaskID"].Visible = false;
            select = 1;

            dataTableUser = GetData.getUserData(connString, userID);
            keyValuePairs = new Dictionary<int, bool>();

            if(dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
            {
                comboBoxDepartment.Text = dataTableUser.Rows[0]["Department"].ToString();
                comboBoxDepartment.Enabled = false;
            }
            else
            {
                getListDept();

                comboBoxDepartment.DataSource = dataSourceDept;
            }
            
            dataSourceStatus = new List<string> { "All", "Pending", "Active", "Verifying", "To be fixed", "Done"};
            comboBoxStatus.DataSource = dataSourceStatus;

            getTasks();
            isInitialized = true;
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            try
            {
                //Create SqlConnection
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT COUNT(*) FROM assigned_task", con);
                con.Open();
                count1 = (Int32)cmd.ExecuteScalar();
                con.Close();
                int countTemp = 0;
                foreach (KeyValuePair<int, bool> keyValuePair in keyValuePairs)
                {
                    if (keyValuePair.Value == true)
                    {
                        Int32 count;
                        cmd = new SqlCommand("Select COUNT(*) FROM ASSIGNED_TASK WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@taskID", keyValuePair.Key);
                        con.Open();
                        count = (Int32)cmd.ExecuteScalar();
                        con.Close();
                        cmd = new SqlCommand("Insert INTO ASSIGNED_TASK(TaskID, EmployeeID)" +
                            "                   VALUES(@taskID, @employeeID)", con);
                        cmd.Parameters.AddWithValue("@taskID", keyValuePair.Key);
                        cmd.Parameters.AddWithValue("employeeID", employeeID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        if (count == 0)
                        {
                            cmd = new SqlCommand("Update TASK SET TaskStatus = 'Active' WHERE TaskID = @taskID", con);
                            cmd.Parameters.AddWithValue("@taskID", keyValuePair.Key);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        cmd = new SqlCommand("UPDATE EMPLOYEE SET NewTask = 1 WHERE EMPLOYEEID = @employeeID", con);
                        cmd.Parameters.AddWithValue("employeeID", employeeID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        countTemp++;
                    }
                    else
                    {
                        cmd = new SqlCommand("DELETE FROM ASSIGNED_TASK" +
                            "                   WHERE TaskID = @taskID" +
                            "                   AND EmployeeID = @employeeID", con);
                        cmd.Parameters.AddWithValue("@taskID", keyValuePair.Key);
                        cmd.Parameters.AddWithValue("employeeID", employeeID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        countTemp--;
                    }
                }
                
                cmd = new SqlCommand("SELECT COUNT(*) FROM assigned_task", con);
                con.Open();
                count2 = (Int32)cmd.ExecuteScalar();
                con.Close();
                if (count1 + countTemp == count2)
                {
                    string message = "Successuly assigned task(s) to the employee.";
                    string title = "Success";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    string message = "Something went wrong.";
                    string title = "Failure";
                    MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textboxSearch_TextChanged(object sender, EventArgs e)
        {
            timerRefresh_Tick(sender, e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
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

        private void dataTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = this.dataTask.Columns[e.ColumnIndex].Name;
            if (Convert.ToBoolean(dataTask.Rows[e.RowIndex].Cells["SelectTask"].EditedFormattedValue) == false && e.RowIndex >= 0 && columnName == "SelectTask")
            {
                dataTask.Rows[e.RowIndex].Cells["SelectTask"].Value = true;
                keyValuePairs[(int)dataTask.Rows[e.RowIndex].Cells["TaskID"].Value] = (bool)dataTask.Rows[e.RowIndex].Cells["SelectTask"].Value;
                timerRefresh_Tick(sender, e);
            }
            else if (Convert.ToBoolean(dataTask.Rows[e.RowIndex].Cells["SelectTask"].EditedFormattedValue) == true && e.RowIndex >= 0 && columnName == "SelectTask")
            { 
                if (dataTask.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "Pending" || dataTask.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "Active")
                {
                    dataTask.Rows[e.RowIndex].Cells["SelectTask"].Value = false;
                    keyValuePairs[(int)dataTask.Rows[e.RowIndex].Cells["TaskID"].Value] = (bool)dataTask.Rows[e.RowIndex].Cells["SelectTask"].Value;
                }
                else
                {
                    MessageBox.Show("You cannot remove employees that were part of task that is either completed of is being fixed.", "Cannot remove",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                timerRefresh_Tick(sender, e);
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                getTasks();
            }
        }

        private void dataTask_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                foreach (DataGridViewRow dataRow in dataTask.Rows)
                {
                    if ((DateTime)dataRow.Cells["DueDate"].Value < DateTime.Now)
                    {
                        dataRow.Cells["DueDate"].Style.ForeColor = Color.DarkRed;
                    }
                    else if (((DateTime)dataRow.Cells["DueDate"].Value - DateTime.Now).TotalDays < 1)
                    {
                        dataRow.Cells["DueDate"].Style.ForeColor = Color.Orange;
                    }
                    if (keyValuePairs.ContainsKey((int)dataRow.Cells["TaskID"].Value))
                    {
                        dataRow.Cells["SelectTask"].Value = keyValuePairs[(int)dataRow.Cells["TaskID"].Value];
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM ASSIGNED_TASK WHERE TaskID = @taskID AND EmployeeID = @employeeID", con);
                        cmd.Parameters.AddWithValue("@taskID", (int)dataRow.Cells["TaskID"].Value);
                        cmd.Parameters.AddWithValue("@employeeID", employeeID);
                        con.Open();
                        Int32 checkBox = (Int32)cmd.ExecuteScalar();
                        con.Close();
                        if (checkBox > 0)
                        {

                            dataRow.Cells["SelectTask"].Value = true;
                        }
                        else
                        {
                            dataRow.Cells["SelectTask"].Value = false;
                        }
                    } 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            select = 1;
            timerRefresh_Tick(sender, e);
        }

        private void buttonAssigned_Click(object sender, EventArgs e)
        {
            select = 2;
            timerRefresh_Tick(sender, e);
        }

        private void buttonNotAssigned_Click(object sender, EventArgs e)
        {
            select = 3;
            timerRefresh_Tick(sender, e);
        }

        private void buttonSubmitClose_Click(object sender, EventArgs e)
        {
            buttonAssign_Click(sender, e);
            this.Close();
        }
    }
}
