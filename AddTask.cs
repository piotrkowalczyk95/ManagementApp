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
    public partial class AddTask : Form
    {

        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";
        private Int32 count1;
        private Int32 count2;
        private int taskID = -1;
        private int userID;
        private DataTable dataTableUser;
        private DateTime saveDate;
        private DataTable dataTableProject;
        private string projectName = null;

        public AddTask(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            try
            {
                dataTableUser = GetData.getUserData(connString, userID);

                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT COUNT(*) FROM task", con);
                con.Open();
                count1 = (Int32)cmd.ExecuteScalar();
                con.Close();

                if(dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                {
                    cmd = new SqlCommand("Select DISTINCT DepartmentName FROM DEPARTMENT", con);
                    con.Open();
                    DataTable dataTableDept = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTableDept);
                    con.Close();
                    List<string> department = new List<string>();
                    department.Add("Not assigned");
                    if (dataTableDept.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dataTableDept.Rows)
                        {
                            department.Add(dataRow["DepartmentName"].ToString());
                        }
                    }
                    comboBoxDepartment.DataSource = department;
                    comboBoxDepartment.SelectedItem = "Not assigned";
                }
                else
                {
                    List<string> department = new List<string>();
                    department.Add(dataTableUser.Rows[0]["Department"].ToString());
                    comboBoxDepartment.DataSource = department;
                    comboBoxDepartment.SelectedIndex = 0;
                    comboBoxDepartment.Enabled = false;
                }
                comboboxPriority.SelectedIndex = 0;
                datetimeDue.MinDate = DateTime.Now;
                datetimeDue.Value = DateTime.Now;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public AddTask(string projectName)
        {
            InitializeComponent();
            this.projectName = projectName;
            getProject();
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT COUNT(*) FROM task", con);
                con.Open();
                count1 = (Int32)cmd.ExecuteScalar();
                con.Close();

                if (dataTableProject.Rows[0]["Department"] == DBNull.Value)
                {
                    cmd = new SqlCommand("Select DISTINCT DepartmentName FROM DEPARTMENT", con);
                    con.Open();
                    DataTable dataTableDept = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTableDept);
                    con.Close();
                    List<string> department = new List<string>();
                    department.Add("Not assigned");
                    if (dataTableDept.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dataTableDept.Rows)
                        {
                            department.Add(dataRow["DepartmentName"].ToString());
                        }
                    }
                    comboBoxDepartment.DataSource = department;
                    comboBoxDepartment.SelectedItem = "Not assigned";
                }
                else
                {
                    List<string> department = new List<string>();
                    department.Add(dataTableProject.Rows[0]["Department"].ToString());
                    comboBoxDepartment.DataSource = department;
                    comboBoxDepartment.SelectedIndex = 0;
                    comboBoxDepartment.Enabled = false;
                }
                if (dataTableProject.Rows[0]["ProjectType"].ToString() == "Scrum")
                {
                    datetimeDue.MinDate = DateTime.Now;
                    datetimeDue.Value = DateTime.Now;
                    datetimeDue.MaxDate = (DateTime)dataTableProject.Rows[0]["ProjectDue"];
                }
                else
                {
                    cmd = new SqlCommand("Select TOP 1 DueDate FROM Task " +
                        "               WHERE ProjectID = @projectID " +
                        "               ORDER BY DueDate DESC", con);
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    con.Close();
                    if(dataTable.Rows.Count > 0)
                    {
                        if (dataTable.Rows[0]["DueDate"] != DBNull.Value)
                        {
                            datetimeDue.MinDate = (DateTime)dataTable.Rows[0]["DueDate"];
                            datetimeDue.Value = (DateTime)dataTable.Rows[0]["DueDate"];
                        }
                    }
                    else
                    {
                        datetimeDue.MinDate = DateTime.Now;
                        datetimeDue.Value = DateTime.Now;
                    }
                    datetimeDue.MaxDate = (DateTime)dataTableProject.Rows[0]["ProjectDue"];
                }
                comboboxPriority.Text = dataTableProject.Rows[0]["ProjectPriority"].ToString();
                comboboxPriority.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public AddTask(int taskID, string projectName)
        {
            InitializeComponent();
            this.projectName = projectName;
            this.taskID = taskID;
            dataTableUser = GetData.getUserData(connString, userID);
            getProject();
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT TaskName, Priority, DueDate, Department, TaskDesc FROM TASK WHERE TaskID = @taskID", con);
                cmd.Parameters.AddWithValue("@taskID", taskID);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapt.Fill(dataTable);
                con.Close();
                dataTableUser = GetData.getUserData(connString, userID);
                textboxTaskName.Text = dataTable.Rows[0]["TaskName"].ToString();
                textboxTaskName.Enabled = false;
                textboxDesc.Text = dataTable.Rows[0]["TaskDesc"].ToString();

                if (dataTableProject.Rows[0]["Department"] == DBNull.Value)
                {
                    cmd = new SqlCommand("Select DISTINCT DepartmentName FROM DEPARTMENT", con);
                    con.Open();
                    DataTable dataTableDept = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTableDept);
                    con.Close();
                    List<string> department = new List<string>();
                    department.Add("Not assigned");
                    if (dataTableDept.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dataTableDept.Rows)
                        {
                            department.Add(dataRow["DepartmentName"].ToString());
                        }
                    }
                    comboBoxDepartment.DataSource = department;
                    comboBoxDepartment.SelectedItem = "Not assigned";
                }
                else
                {
                    comboBoxDepartment.Text = dataTableProject.Rows[0]["Department"].ToString();
                    comboBoxDepartment.SelectedItem = dataTableProject.Rows[0]["Department"].ToString();
                    comboBoxDepartment.Enabled = false;
                }
                if (dataTableProject.Rows[0]["ProjectType"].ToString() == "Scrum")
                {
                    datetimeDue.Value = (DateTime)dataTable.Rows[0]["DueDate"];
                    datetimeDue.MinDate = datetimeDue.Value;
                    saveDate = (DateTime)dataTable.Rows[0]["DueDate"];
                    datetimeDue.MaxDate = (DateTime)dataTableProject.Rows[0]["ProjectDue"];
                }
                else
                {
                    cmd = new SqlCommand("Select TOP 1 DueDate FROM TASK " +
                        "               WHERE ProjectID = @projectID " +
                        "               ORDER BY DueDate DESC", con);
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    con.Close();
                    datetimeDue.MinDate = (DateTime)dataTable.Rows[0]["DueDate"];
                    datetimeDue.Value = (DateTime)dataTable.Rows[0]["DueDate"];
                    cmd = new SqlCommand("Select ProjectSortNumber FROM TASK " +
                        "               WHERE TaskID = @taskID ", con);
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    dataTable = new DataTable();
                    con.Open();
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();
                    int sortNumber = (int)dataTable.Rows[0]["ProjectSortNumber"];

                    cmd = new SqlCommand("Select DueDate FROM TASK " +
                        "               WHERE ProjectID = @projectID" +
                        "               AND ProjectSortNumber = @sortNumber ", con);
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    cmd.Parameters.AddWithValue("@sortNumber", sortNumber + 1);
                    dataTable = new DataTable();
                    con.Open();
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();

                    if(dataTable.Rows.Count > 0)
                    {
                        datetimeDue.MaxDate = (DateTime)dataTable.Rows[0]["DueDate"];
                    }
                    else
                    {
                        datetimeDue.MaxDate = (DateTime)dataTableProject.Rows[0]["ProjectDue"];
                    }
                    
                }
                comboboxPriority.Text = dataTableProject.Rows[0]["ProjectPriority"].ToString();
                comboboxPriority.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public AddTask(int userID, int taskID)
        {
            InitializeComponent();
            this.userID = userID;
            this.taskID = taskID;
            this.Text = "Edit Task";
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                cmd = new SqlCommand("SELECT * FROM TASK WHERE TaskID = @taskID", con);
                cmd.Parameters.AddWithValue("@taskID", taskID);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapt.Fill(dataTable);
                con.Close();
                dataTableUser = GetData.getUserData(connString, userID);
                textboxTaskName.Text = dataTable.Rows[0]["TaskName"].ToString();
                comboboxPriority.Text = dataTable.Rows[0]["Priority"].ToString();
                datetimeDue.Value = (DateTime)dataTable.Rows[0]["DueDate"];
                datetimeDue.MinDate = datetimeDue.Value;
                saveDate = (DateTime)dataTable.Rows[0]["DueDate"];
                textboxDesc.Text = dataTable.Rows[0]["TaskDesc"].ToString();

                if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                {
                    cmd = new SqlCommand("Select DISTINCT DepartmentName FROM DEPARTMENT", con);
                    con.Open();
                    DataTable dataTableDept = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTableDept);
                    con.Close();
                    List<string> department = new List<string>();
                    department.Add("Not assigned");
                    if (dataTableDept.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dataTableDept.Rows)
                        {
                            department.Add(dataRow["DepartmentName"].ToString());
                        }
                    }
                    comboBoxDepartment.DataSource = department;
                    if(dataTable.Rows[0]["Department"] == DBNull.Value)
                    {
                        comboBoxDepartment.SelectedItem = "Not assigned";
                    }
                    else
                    {
                        comboBoxDepartment.SelectedItem = dataTable.Rows[0]["Department"];
                    }
                }
                else
                {
                    List<string> department = new List<string>();
                    department.Add("Not assigned");
                    department.Add(dataTableUser.Rows[0]["Department"].ToString());
                    comboBoxDepartment.DataSource = department;
                    if (dataTable.Rows[0]["Department"] == DBNull.Value)
                    {
                        comboBoxDepartment.SelectedItem = "Not assigned";
                    }
                    else
                    {
                        comboBoxDepartment.SelectedItem = dataTable.Rows[0]["Department"];
                    }
                }
                textboxTaskName.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void getProject()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select ProjectID, ProjectType, ProjectDue, ProjectPriority, Department FROM PROJECT " +
                    "                           WHERE ProjectName = @projectName" +
                    "                           AND ProjectStatus != 'Accepted'", con);
                cmd.Parameters.AddWithValue("@projectName", projectName);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dataTableProject = new DataTable();
                adapter.Fill(dataTableProject);
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void newTask()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                if(projectName != null)
                {
                    cmd = new SqlCommand("SELECT * FROM TASK WHERE TaskNAME = @taskName AND ProjectID = @projectID", con);
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                }
                else
                {
                    cmd = new SqlCommand("SELECT * FROM TASK WHERE TaskNAME = @taskName AND TaskStatus != 'Accepted'", con);
                }
                cmd.Parameters.AddWithValue("@taskName", textboxTaskName.Text);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.Close();
                if(dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Another active task with the same name already exists.", "Duplicate name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cmd = null;
                Int32 count = -1;
                if(projectName != null)
                {
                    cmd = new SqlCommand("SELECT COUNT(*) FROM TASK WHERE ProjectID = @projectID", con);
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    con.Open();
                    count = (Int32)cmd.ExecuteScalar();
                    con.Close();

                    if (textboxDesc.Text == "")
                    {
                        cmd = new SqlCommand("INSERT INTO TASK(TaskName, Priority, DueDate, TaskStatus, Department, ProjectID, ProjectSortNumber) " +
                            "               VALUES(@taskname, @priority, @duedate, @status, @department, @projID, @sortNumber)", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO TASK(TaskName, Priority, DueDate, TaskDesc, TaskStatus, Department, ProjectID, ProjectSortNumber) " +
                            "               VALUES(@taskname, @priority, @duedate, @desc, @status, @department, @projID, @sortNumber)", con);
                    }
                }
                else
                {
                    if (textboxDesc.Text == "")
                    {
                        cmd = new SqlCommand("INSERT INTO TASK(TaskName, Priority, DueDate, TaskStatus, Department) " +
                            "               VALUES(@taskname, @priority, @duedate, @status, @department)", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO TASK(TaskName, Priority, DueDate, TaskDesc, TaskStatus, Department) " +
                            "               VALUES(@taskname, @priority, @duedate, @desc, @status, @department)", con);
                    }
                }

                if (cmd != null)
                {
                    cmd.Parameters.AddWithValue("@taskname", textboxTaskName.Text);
                    cmd.Parameters.AddWithValue("@priority", comboboxPriority.Text);
                    cmd.Parameters.AddWithValue("@duedate", datetimeDue.Value);
                    cmd.Parameters.AddWithValue("@desc", textboxDesc.Text);
                    cmd.Parameters.AddWithValue("@status", "Pending");
                    if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        cmd.Parameters.AddWithValue("@department", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text);
                    }
                    if(dataTableProject.Rows[0]["ProjectID"] != DBNull.Value)
                    {
                        cmd.Parameters.AddWithValue("@projID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    }
                    if(count != -1)
                    {
                        cmd.Parameters.AddWithValue("@sortNumber", count + 1);
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                cmd = new SqlCommand("SELECT COUNT(*) FROM task", con);
                con.Open();
                count2 = (Int32)cmd.ExecuteScalar();
                con.Close();
                if (count1 + 1 == count2)
                {
                    MessageBox.Show("Successfuly added task to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add task to database.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editTask()
        {
            if (saveDate > datetimeDue.Value)
            {
                MessageBox.Show("New date cannot be set earlier than original.", "Date error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;

                cmd = new SqlCommand("SELECT * FROM TASK WHERE TaskNAME = @taskName AND TaskStatus != 'Accepted' AND TaskID != @taskID AND ProjectID != @projectID", con);
                cmd.Parameters.AddWithValue("@taskName", textboxTaskName.Text);
                cmd.Parameters.AddWithValue("@taskID", taskID);
                cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.Close();
                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Another active task with the same name already exists.", "Duplicate name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cmd = new SqlCommand("UPDATE TASK SET TaskName = @taskName, Priority = @priority, " +
                    "               DueDate = @dueDate, TaskDesc = @taskDesc, Department = @department" +
                    "               WHERE TaskID = @taskID", con);

                if (cmd != null)
                {
                    cmd.Parameters.AddWithValue("@taskname", textboxTaskName.Text);
                    cmd.Parameters.AddWithValue("@priority", comboboxPriority.Text);
                    cmd.Parameters.AddWithValue("@duedate", datetimeDue.Value);
                    if(textboxDesc.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@taskDesc", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@taskDesc", textboxDesc.Text);
                    }
                    cmd.Parameters.AddWithValue("@status", "Pending");
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    if(comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        cmd.Parameters.AddWithValue("@department", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text);
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Failed to edit task.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Successfuly editted the task!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void buttonSubit_Click(object sender, EventArgs e)
        {
            if (textboxTaskName.Text == "" || comboboxPriority.Text == "")
            {
                MessageBox.Show("Please fill all boxes marked with *");
                return;
            }

            if(taskID == -1)
            {
                newTask();
            }
            else
            {
                editTask();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this window?\nUnsubmitted changes will be lost.", 
                "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
 }
