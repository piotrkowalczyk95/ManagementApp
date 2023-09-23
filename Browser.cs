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
    public partial class Browser : Form
    {
        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        public bool exit, isInitialized = false;
        public Login login;
        public int userID;
        private DataTable dataTableUser;
        private List<string> dataSourceDept;
        private List<string> dataSourcePosition;
        private List<string> dataSourceStatus;
        private List<string> dataSourcePriority;
        private List<string> dataSourceStatusProject;

        private void getEmployees()
        {
            datagridEmp.RowHeadersVisible = false;
            datagridEmp.AutoGenerateColumns = false;
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmdEmp = null;
                string queryString = "Select Surname, FirstName, Department, Permission, IsBlocked, EmployeeID" +
                "                           from employee where (Lower(FirstName) LIKE " +
                "                           CONCAT('%', Lower(@searchEmp), '%') " +
                "                           OR Lower(Surname) LIKE " +
                "                           CONCAT('%', Lower(@searchEmp), '%'))";

                if (comboBoxDept.SelectedItem.ToString() != "All" && comboBoxDept.SelectedItem.ToString() != "Not assigned")
                {
                    queryString += " AND DEPARTMENT = @department";
                }
                else if(comboBoxDept.SelectedItem.ToString() == "Not assigned")
                {
                    queryString += " AND DEPARTMENT IS NULL";
                }
                else
                {
                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                    {
                        queryString += " AND (DEPARTMENT IS NULL OR DEPARTMENT = @mgmtDepartment)";
                    }
                }

                if (comboBoxPosition.SelectedItem.ToString() != "All" && comboBoxPosition.SelectedItem.ToString() != "Not assigned")
                {
                    queryString += " AND (Permission = @position AND PERMISSION != 'Administrator')";
                }
                else if (comboBoxPosition.SelectedItem.ToString() == "Not assigned")
                {
                    queryString += " AND (PERMISSION IS NULL)";
                }
                else
                {
                    queryString += " AND (PERMISSION IS NULL OR PERMISSION != 'Administrator')";
                }

                if (!checkBoxBlocked.Checked)
                {
                    queryString += " AND ISBLOCKED = 0";
                }

                cmdEmp = new SqlCommand(queryString, con);
                if(dataTableUser.Rows[0]["Department"] != DBNull.Value)
                {
                    cmdEmp.Parameters.AddWithValue("@mgmtDepartment", dataTableUser.Rows[0]["Department"].ToString());
                }
                cmdEmp.Parameters.AddWithValue("@searchEmp", textboxSearchEmp.Text.ToLower());
                cmdEmp.Parameters.AddWithValue("@department", comboBoxDept.SelectedItem.ToString());
                cmdEmp.Parameters.AddWithValue("@position", comboBoxPosition.SelectedItem.ToString());
                con.Open();
                SqlDataAdapter adaptEmp = new SqlDataAdapter(cmdEmp);
                DataTable empData = new DataTable();
                adaptEmp.Fill(empData);
                con.Close();
                datagridEmp.ReadOnly = true;
                empData.Columns.Add("AccStatus", typeof(string));
                foreach (DataRow dataRow in empData.Rows)
                {
                    if (dataRow["Department"] == DBNull.Value)
                    {
                        dataRow["Department"] = "Not assigned";
                    }
                    if(dataRow["Permission"] == DBNull.Value)
                    {
                        dataRow["Permission"] = "Not assigned";
                    }
                    if ((bool)dataRow["IsBlocked"] == false)
                    {
                        dataRow["AccStatus"] = "Active";
                    }
                    else
                    {
                        dataRow["AccStatus"] = "Blocked";
                    }
                }
                datagridEmp.DataSource = empData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
        
        private void getDepartments()
        {
            comboBoxDept.SelectedItem = dataTableUser.Rows[0]["Department"];
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmdDept = new SqlCommand("Select DepartmentName, DepartmentDesc, DepartmentID" +
                    "                           from Department where (Lower(DepartmentName) LIKE " +
                    "                           CONCAT('%', Lower(@searchDept), '%')) ", con);
                cmdDept.Parameters.AddWithValue("@searchDept", textBoxSearchDept.Text);
                con.Open();
                SqlDataAdapter adaptDept = new SqlDataAdapter(cmdDept);
                DataTable deptData = new DataTable();
                adaptDept.Fill(deptData);
                dataGridDept.ReadOnly = true;
                dataGridDept.DataSource = deptData;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getDepartmentInfo()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmdDept = new SqlCommand("Select DepartmentName, DepartmentDesc, DepartmentID FROM DEPARTMENT" +
                    "                           WHERE DEPARTMENTNAME = @department ", con);
                cmdDept.Parameters.AddWithValue("@department", dataTableUser.Rows[0]["Department"].ToString());
                con.Open();
                SqlDataAdapter adaptDept = new SqlDataAdapter(cmdDept);
                DataTable deptData = new DataTable();
                adaptDept.Fill(deptData);
                con.Close();

                labelName.Text = deptData.Rows[0]["DepartmentName"].ToString();
                if(deptData.Rows[0]["DepartmentDesc"] != DBNull.Value)
                {
                    labelDesc.Text = deptData.Rows[0]["DepartmentDesc"].ToString();
                }
                else
                {
                    labelDesc.Text = "Not specified";
                }                

                cmdDept = new SqlCommand("SELECT FIRSTNAME, SURNAME, PHONENUMBER, EMAIL, PHONEVISIBLE, EMAILVISIBLE FROM EMPLOYEE " +
                    "                       WHERE PERMISSION = 'MANAGER'" +
                    "                       AND DEPARTMENT = @department", con);
                cmdDept.Parameters.AddWithValue("@department", dataTableUser.Rows[0]["Department"].ToString());
                con.Open();
                adaptDept = new SqlDataAdapter(cmdDept);
                DataTable deptMgmt = new DataTable();
                adaptDept.Fill(deptMgmt);
                con.Close();
                foreach(DataRow dataRow in deptMgmt.Rows)
                {
                    if(dataTableUser.Rows[0]["Permission"].ToString() == "Employee")
                    {
                        if (Convert.ToBoolean(dataRow["PhoneVisible"]) == false || (dataRow["PhoneNumber"] == DBNull.Value))
                        {
                            dataRow["PhoneNumber"] = "Hidden/Not specified";
                        }
                        if (Convert.ToBoolean(dataRow["EmailVisible"]) == false || (dataRow["Email"] == DBNull.Value))
                        {
                            dataRow["Email"] = "Hidden/Not specified";
                        }
                        
                    }
                    else
                    {
                        if ((dataRow["PhoneNumber"] == DBNull.Value))
                        {
                            dataRow["PhoneNumber"] = "Hidden/Not specified";
                        }
                        if ((dataRow["Email"] == DBNull.Value))
                        {
                            dataRow["Email"] = "Hidden/Not specified";
                        }
                    }
                }
                dataGridViewMgmt.DataSource = deptMgmt;
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
                SqlConnection con = new SqlConnection(connString);

                string queryString = "Select TaskName, DueDate, Priority, TaskStatus, Department, TASK.TaskID FROM TASK ";
                if (dataTableUser.Rows[0]["Permission"].ToString() == "Employee" || dataTableUser.Rows[0]["Permission"] == DBNull.Value)
                {
                    comboBoxDeptTask.SelectedItem = "All";
                    comboBoxDeptTask.Enabled = false;
                    queryString += "INNER JOIN ASSIGNED_TASK ON TASK.TaskID = ASSIGNED_TASK.TaskID";
                }
                queryString += " WHERE Lower(TaskName) Like CONCAT('%', Lower(@searchTask), '%') ";

                if (comboBoxDeptTask.SelectedItem.ToString() != "All" && comboBoxDeptTask.SelectedItem.ToString() != "Not assigned")
                {
                    queryString += "AND Department = @department ";
                }
                else if (comboBoxDeptTask.SelectedItem.ToString() == "Not assigned")
                {
                    queryString += "AND DEPARTMENT IS NULL ";
                }

                if (comboBoxStatusTask.SelectedItem.ToString() != "All")
                {
                    queryString += "AND TASKSTATUS = @status ";
                }

                if (comboBoxPriorityTask.SelectedItem.ToString() != "All")
                {
                    queryString += "AND Priority = @priority";
                }
                queryString += " AND ProjectID IS NULL";
                if (dataTableUser.Rows[0]["Permission"].ToString() == "Employee" || dataTableUser.Rows[0]["Permission"] == DBNull.Value)
                {
                    queryString += " AND ASSIGNED_TASK.EmployeeID = @userID";
                }
                SqlCommand cmdTask = new SqlCommand(queryString, con);
                cmdTask.Parameters.AddWithValue("@searchTask", textboxSearchTask.Text);
                cmdTask.Parameters.AddWithValue("@department", comboBoxDeptTask.SelectedItem.ToString());
                cmdTask.Parameters.AddWithValue("@status", comboBoxStatusTask.SelectedItem.ToString());
                cmdTask.Parameters.AddWithValue("@priority", comboBoxPriorityTask.SelectedItem.ToString());
                cmdTask.Parameters.AddWithValue("@userID", userID);
                con.Open();
                SqlDataAdapter adaptTask = new SqlDataAdapter(cmdTask);
                DataTable taskData = new DataTable();
                adaptTask.Fill(taskData);
                con.Close();
                if (taskData.Columns["TASK.TaskID"] != null)
                {
                    taskData.Columns["TASK.TaskID"].ColumnName = "TaskID";
                }
                foreach (DataRow dataRow in taskData.Rows)
                {
                    if (dataRow["Department"] == DBNull.Value)
                    {
                        dataRow["Department"] = "Not assigned";
                    }
                }
                datagridTask.ReadOnly = true;
                
                datagridTask.DataSource = taskData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getProjects()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);

                string queryString = "Select ProjectName, ProjectDue, ProjectPriority, ProjectStatus, Department, PROJECT.ProjectID FROM PROJECT ";
                if (dataTableUser.Rows[0]["Permission"].ToString() == "Employee" || dataTableUser.Rows[0]["Permission"] == DBNull.Value)
                {
                    comboBoxDeptProj.SelectedItem = "All";
                    comboBoxDeptProj.Enabled = false;
                    queryString += " INNER JOIN ASSIGNED_PROJECT ON PROJECT.ProjectID = ASSIGNED_PROJECT.ProjectID";
                }
                queryString += " WHERE Lower(ProjectName) Like CONCAT('%', Lower(@searchProject), '%') ";

                if (comboBoxDeptTask.SelectedItem.ToString() != "All" && comboBoxDeptTask.SelectedItem.ToString() != "Not assigned")
                {
                    queryString += "AND Department = @department ";
                }
                else if (comboBoxDeptTask.SelectedItem.ToString() == "Not assigned")
                {
                    queryString += "AND DEPARTMENT IS NULL ";
                }

                if (comboBoxStatusTask.SelectedItem.ToString() != "All")
                {
                    queryString += "AND PROJECTSTATUS = @status ";
                }

                if (comboBoxPriorityTask.SelectedItem.ToString() != "All")
                {
                    queryString += "AND Priority = @priority";
                }
                if (dataTableUser.Rows[0]["Permission"].ToString() == "Employee" || dataTableUser.Rows[0]["Permission"] == DBNull.Value)
                {
                    queryString += " AND ASSIGNED_PROJECT.EmployeeID = @userID";
                }
                SqlCommand cmdTask = new SqlCommand(queryString, con);
                cmdTask.Parameters.AddWithValue("@searchProject", textboxSearchTask.Text);
                cmdTask.Parameters.AddWithValue("@department", comboBoxDeptTask.SelectedItem.ToString());
                cmdTask.Parameters.AddWithValue("@status", comboBoxStatusTask.SelectedItem.ToString());
                cmdTask.Parameters.AddWithValue("@priority", comboBoxPriorityTask.SelectedItem.ToString());
                cmdTask.Parameters.AddWithValue("@userID", userID);
                con.Open();
                SqlDataAdapter adaptTask = new SqlDataAdapter(cmdTask);
                DataTable projectData = new DataTable();
                adaptTask.Fill(projectData);
                con.Close();
                if (projectData.Columns["PROJECT.ProjectID"] != null)
                {
                    projectData.Columns["PROJECT.ProjectID"].ColumnName = "ProjectID";
                }
                foreach (DataRow dataRow in projectData.Rows)
                {
                    if (dataRow["Department"] == DBNull.Value)
                    {
                        dataRow["Department"] = "Not assigned";
                    }
                }
                datagridProject.ReadOnly = true;

                datagridProject.DataSource = projectData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkAssignment()
        {
            if (Convert.ToBoolean(dataTableUser.Rows[0]["NewTask"]) == true)
            {
                MessageBox.Show("Your account had new tasks added. Check if they are still availible.", "New tasks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("UPDATE EMPLOYEE SET NewTask = 0 WHERE EmployeeID = @userID", con);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dataTableUser = GetData.getUserData(connString, userID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (Convert.ToBoolean(dataTableUser.Rows[0]["NewProject"]) == true)
            {
                MessageBox.Show("Your account had new projects added. Check if they are still availible.", "New projects", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("UPDATE EMPLOYEE SET NewProject = 0 WHERE EmployeeID = @userID", con);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dataTableUser = GetData.getUserData(connString, userID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public Browser(Login login, int userID)
        {
            InitializeComponent();

            exit = false;
            this.login = login;
            this.userID = userID;

            dataTableUser = GetData.getUserData(connString, userID);

            getListDept();

            dataSourcePosition = new List<string> { "All", "Employee", "Manager", "Not assigned" };
            dataSourceStatus = new List<string> { "All", "Pending", "Active", "Verifying", "To be fixed", "Done", "Accepted" };
            dataSourcePriority = new List<string> { "All", "Low", "Medium", "High" };
            dataSourceStatusProject = new List<string> { "All", "Pending", "Active", "To be fixed", "Done", "Accepted" };

            comboBoxDept.DataSource = dataSourceDept;
            comboBoxDeptTask.DataSource = dataSourceDept;
            comboBoxDeptProj.DataSource = dataSourceDept;
            comboBoxPosition.DataSource = dataSourcePosition;
            comboBoxStatusTask.DataSource = dataSourceStatus;
            comboBoxPriorityTask.DataSource = dataSourcePriority;
            comboBoxStatusProj.DataSource = dataSourceStatusProject;
            comboBoxPriorityProj.DataSource = dataSourcePriority;

            datagridEmp.RowHeadersVisible = false;
            datagridTask.RowHeadersVisible = false;
            dataGridDept.RowHeadersVisible = false;

            if (dataTableUser.Rows[0]["Permission"].ToString() == "Employee" || dataTableUser.Rows[0]["Permission"] == null)
            {
                tabControl.TabPages.RemoveByKey("EmpTab");
                tabControl.TabPages.RemoveByKey("DeptTab");
                if(dataTableUser.Rows[0]["Department"] == null)
                {
                    tabControl.TabPages.RemoveByKey("DeptTabInfo");
                    comboBoxDeptTask.Text = "Not assigned";
                    comboBoxDeptTask.Enabled = false;
                    comboBoxDeptProj.Text = "Not assigned";
                    comboBoxDeptProj.Enabled = false;
                }
                else
                {
                    buttonEditDept.Enabled = false;
                    buttonEditEmp.Enabled = false;
                }
                buttonCreateTask.Visible = false;
                buttonAddProject.Visible = false;
            }
            else if(dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
            {
                tabControl.TabPages.RemoveByKey("DeptTab");
                checkBoxBlocked.Enabled = false;
                checkBoxBlocked.Visible = false;
                comboBoxDeptTask.SelectedItem = dataTableUser.Rows[0]["Department"];
                comboBoxDeptTask.Enabled = false;
                comboBoxDeptProj.SelectedItem = dataTableUser.Rows[0]["Department"];
                comboBoxDeptProj.Enabled = false;
                datagridEmp.Columns["AccStatus"].Visible = false;
            }
            else
            {
                tabControl.TabPages.RemoveByKey("DeptTabInfo");
            }

            checkAssignment();

            tabChange();

            isInitialized = true;
        }

        private void tabChange()
        {
            if (tabControl.SelectedTab.Name == "EmpTab")
            {
                getEmployees();
            }
            else if (tabControl.SelectedTab.Name == "DeptTab")
            {
                getDepartments();
            }
            else if (tabControl.SelectedTab.Name == "TaskTab")
            {
                getTasks();
            }
            else if (tabControl.SelectedTab.Name == "DeptTabInfo")
            {
                getDepartmentInfo();
            }
            else if(tabControl.SelectedTab.Name == "ProjTab")
            {
                getProjects();
            }
        }

        private void textboxSearchEmp_TextChanged(object sender, EventArgs e)
        {
            getEmployees();
        }

        private void textboxSearchTask_TextChanged(object sender, EventArgs e)
        {
            getTasks();
        }

        private void textboxSearchDept_TextChanged(object sender, EventArgs e)
        {
            getDepartments();
        }

        private void textBoxProject_TextChanged(object sender, EventArgs e)
        {
            getProjects();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            const string message = "Are you sure you want to log out?";
            const string title = "Log out";
            var res = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                login.Show();
                exit = true;
                this.Close();
            }
        }

        private void buttonLogOut2_Click(object sender, EventArgs e)
        {
            buttonLogOut_Click(sender, e);
        }

        private void Browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message = "Are you sure you want to log out?";
            const string title = "Log out";
            if(exit == false)
            {
                var res = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    login.Show();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee(userID);
            addEmployee.ShowDialog();
            tabChange();
        }

        private void buttonCreateTask_Click(object sender, EventArgs e)
        {
            AddTask addTask = new AddTask(userID);
            addTask.ShowDialog();
            tabChange();
        }

        private void buttonAddDept_Click(object sender, EventArgs e)
        {
            AddDepartment addDepartment = new AddDepartment();
            addDepartment.ShowDialog();
            tabChange();
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            AddProject addProject = new AddProject(userID);
            addProject.ShowDialog();
            tabChange();
        }

        private void datagridTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                TaskDetails taskDetails = new TaskDetails((int)senderGrid["TaskID", e.RowIndex].Value, userID);
                taskDetails.ShowDialog();
                tabChange();
            }
        }

        private void datagridEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                EmployeeDetails employeeDetails = new EmployeeDetails((int)senderGrid["EmployeeID", e.RowIndex].Value, userID);
                employeeDetails.ShowDialog();
                tabChange();
            }
        }

        private void dataGridDept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DepartmentDetails departmentDetails = new DepartmentDetails((int)senderGrid["DepartmentID", e.RowIndex].Value, userID);
                departmentDetails.ShowDialog();
                tabChange();
            }
        }

        private void dataGridProj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                ProjectDetails projectDetails = new ProjectDetails((int)senderGrid["ProjectID", e.RowIndex].Value, userID);
                projectDetails.ShowDialog();
                tabChange();
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            tabControl_SelectedIndexChanged(sender, e);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                tabChange();
                checkAssignment();
            }
        }

        private void buttonEditEmp_Click(object sender, EventArgs e)
        {
            DepartmentEditEmp departmentEditEmp = new DepartmentEditEmp(dataTableUser.Rows[0]["Department"].ToString(), userID);
            departmentEditEmp.ShowDialog();
            tabChange();
        }

        private void comboBoxDept_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxDept.SelectedItem.ToString() == "Not assigned")
            {
                dataSourcePosition = new List<string> { "All", "Employee", "Manager", "Not assigned" };
                comboBoxPosition.DataSource = dataSourcePosition;
                comboBoxPosition.SelectedItem = "Not assigned";
                comboBoxPosition.Enabled = false;
            }
            else if (comboBoxDept.SelectedItem.ToString() == "All")
            {
                dataSourcePosition = new List<string> { "All", "Employee", "Manager", "Not assigned" };
                comboBoxPosition.DataSource = dataSourcePosition;
                comboBoxPosition.Enabled = true;
            }
            else
            {
                dataSourcePosition = new List<string> { "All", "Employee", "Manager" };
                comboBoxPosition.DataSource = dataSourcePosition;
                comboBoxPosition.Enabled = true;
            }
            tabChange();
        }

        private void buttonEditDept_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT DepartmentID FROM DEPARTMENT" +
                    "                           WHERE DepartmentName = @department", con);
                cmd.Parameters.AddWithValue("@department", dataTableUser.Rows[0]["Department"].ToString());
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.Close();
                if (dataTable != null)
                {
                    AddDepartment addDepartment = new AddDepartment((int)(dataTable.Rows[0]["DepartmentID"]), userID);
                    addDepartment.ShowDialog();
                    tabChange();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void datagridTask_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(datagridTask.Rows.Count > 0)
            {
                foreach (DataGridViewRow dataRow in datagridTask.Rows)
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
            if(datagridProject.Rows.Count > 0)
            {
                foreach (DataGridViewRow dataRow in datagridProject.Rows)
                {
                    if ((DateTime)dataRow.Cells["ProjectDue"].Value < DateTime.Now)
                    {
                        dataRow.Cells["ProjectDue"].Style.ForeColor = Color.DarkRed;
                    }
                    else if (((DateTime)dataRow.Cells["ProjectDue"].Value - DateTime.Now).TotalDays < 1)
                    {
                        dataRow.Cells["ProjectDue"].Style.ForeColor = Color.Orange;
                    }
                }
            } 
        }
    }
}
