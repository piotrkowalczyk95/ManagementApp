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
    public partial class ProjectDetails : Form
    {
        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";
        private int projectID, userID;
        private bool isInitialized = false;
        DataTable dataTableUser;
        DataTable dataTableProject;

        private void getComments()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd, cmdCount;

                cmd = new SqlCommand("SELECT TOP 3 ProjectCommentID, ProjectCommentAuthor, ProjectCommentDate, ProjectComment " +
                    "               FROM PROJECT_COMMENT WHERE ProjectID = @projectID " +
                    "               ORDER BY ProjectCommentID DESC", con);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                cmdCount = new SqlCommand("SELECT COUNT(*) FROM PROJECT_COMMENT WHERE ProjectID = @projectID", con);
                cmdCount.Parameters.AddWithValue("@projectID", projectID);

                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTableComments = new DataTable();
                adapter.Fill(dataTableComments);
                Int32 count = (Int32)cmdCount.ExecuteScalar();
                con.Close();

                if (count > 3)
                {
                    buttonViewComments.Enabled = true;
                }

                dataGridViewComments.DataSource = dataTableComments;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getEmployees()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT Surname, FirstName, Department, PhoneNumber, PhoneVisible, Email, EmailVisible FROM EMPLOYEE" +
                    "                           INNER JOIN ASSIGNED_PROJECT" +
                    "                           ON EMPLOYEE.EmployeeID = ASSIGNED_PROJECT.EmployeeID" +
                    "                           WHERE ASSIGNED_PROJECT.ProjectID = @projectID", con);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.Close();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if ((bool)dataRow["PhoneVisible"] == false || dataRow["PhoneNumber"] == DBNull.Value)
                    {
                        dataRow["PhoneNumber"] = "Unavailable";
                    }
                    if ((bool)dataRow["EmailVisible"] == false || dataRow["Email"] == DBNull.Value)
                    {
                        dataRow["Email"] = "Unavailable";
                    }
                }
                dataEmp.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getLeader()
        {
            try
            {
                if(dataTableProject.Rows[0]["ProjectLeader"] != DBNull.Value)
                {
                    SqlConnection con = new SqlConnection(connString);

                    string queryString = "SELECT FirstName, Surname FROM EMPLOYEE WHERE PESEL = @projectLeader";

                    SqlCommand cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@projectLeader", dataTableProject.Rows[0]["ProjectLeader"].ToString());
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    con.Close();

                    labelLeader.Text = dataTable.Rows[0]["FirstName"].ToString() + " " + dataTable.Rows[0]["Surname"].ToString();
                }
                else
                {
                    labelLeader.Text = "No leader set";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getProjectByID()
        {
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
        }

        private void getProject()
        {
            getProjectByID();
            labelProjectName.Text = dataTableProject.Rows[0]["ProjectName"].ToString();
            labelPriority.Text = dataTableProject.Rows[0]["ProjectPriority"].ToString();
            DateTime dateTime = (DateTime)dataTableProject.Rows[0]["ProjectDue"];
            labelDue.Text = dateTime.ToString("dd-MM-yyyy");
            if (dataTableProject.Rows[0]["ProjectDesc"] == DBNull.Value)
            {
                labelDesc.Text = "Not specified";
            }
            else
            {
                labelDesc.Text = dataTableProject.Rows[0]["ProjectDesc"].ToString();
            } 
            labelProjectType.Text = dataTableProject.Rows[0]["ProjectType"].ToString();
        }

        private void getTasks()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);

                string queryString = "SELECT ProjectSortNumber, TaskName, DueDate, Priority, TaskStatus, Department, TaskID" +
                    "                   FROM TASK WHERE ProjectID = @projectID" +
                    "                   ORDER BY ProjectSortNumber ASC";
                
                SqlCommand cmdTask = new SqlCommand(queryString, con);
                cmdTask.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                SqlDataAdapter adaptTask = new SqlDataAdapter(cmdTask);
                DataTable taskData = new DataTable();
                adaptTask.Fill(taskData);
                con.Close();
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

        private void getStatus()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM TASK WHERE ProjectID = @projectID", con);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                Int32 countTotal = (Int32)cmd.ExecuteScalar();
                con.Close();

                cmd = new SqlCommand("SELECT COUNT(*) FROM TASK WHERE ProjectID = @projectID AND TaskStatus = 'Done'", con);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                Int32 countDone = (Int32)cmd.ExecuteScalar();
                con.Close();

                if(countTotal > 0)
                {
                    if (countTotal == countDone)
                    {
                        cmd = new SqlCommand("UPDATE PROJECT SET ProjectStatus = 'Done' WHERE ProjectID = @projectID", con);
                        cmd.Parameters.AddWithValue("@projectID", projectID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" || dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                        {
                            buttonAccept.Enabled = true;
                            buttonAccept.Visible = true;
                        }
                    }
                    else
                    {
                        if (dataTableProject.Rows[0]["ProjectStatus"].ToString() == "Done")
                        {
                            cmd = new SqlCommand("SELECT COUNT(*) FROM TASK WHERE ProjectID = @projectID AND TaskStatus = 'To be fixed'", con);
                            cmd.Parameters.AddWithValue("@projectID", projectID);
                            con.Open();
                            Int32 countTBF = (Int32)cmd.ExecuteScalar();
                            con.Close();
                            if(countTBF > 0)
                            {
                                cmd = new SqlCommand("UPDATE PROJECT SET ProjectStatus = 'To be fixed' WHERE ProjectID = @projectID", con);
                                cmd.Parameters.AddWithValue("@projectID", projectID);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                buttonAccept.Enabled = false;
                                buttonAccept.Visible = false;
                            }
                        }
                    }
                }
                getProjectByID();
                labelStatus.Text = dataTableProject.Rows[0]["ProjectStatus"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ProjectDetails(int projectID, int userID)
        {
            InitializeComponent();
            this.userID = userID;
            this.projectID = projectID;
            buttonViewComments.Enabled = false;
            dataTableUser = GetData.getUserData(connString, userID);
            buttonAccept.Enabled = false;
            buttonAccept.Visible = false;

            getProject();
            getTasks();
            getStatus();
            getLeader();
            getEmployees();
            getComments();
            
            if(dataTableProject.Rows[0]["ProjectStatus"].ToString() == "Accepted")
            {
                buttonTasks.Enabled = false;
                buttonEdit.Enabled = false;
                buttonDelete.Enabled = false;
                buttonEditEmp.Enabled = false;
                buttonAddComment.Enabled = false;
            }

            if(dataTableUser.Rows[0]["Permission"].ToString() == "Employee" || dataTableUser.Rows[0]["Permission"] == DBNull.Value)
            {
                buttonTasks.Enabled = false;
                buttonTasks.Visible = false;
                buttonEdit.Enabled = false;
                buttonEdit.Visible = false;
                buttonDelete.Enabled = false;
                buttonDelete.Visible = false;
                buttonEditEmp.Enabled = false;
                buttonEditEmp.Visible = false;
            }

            isInitialized = true;
        }

        private void buttonEditEmp_Click(object sender, EventArgs e)
        {
            AssignEmployee assignEmployee = new AssignEmployee(dataTableProject.Rows[0]["ProjectName"].ToString(), userID);
            assignEmployee.ShowDialog();
            getEmployees();
        }

        private void buttonTasks_Click(object sender, EventArgs e)
        {
            AddProjectTasks addProjectTasks = new AddProjectTasks(userID, dataTableProject.Rows[0]["ProjectName"].ToString());
            addProjectTasks.ShowDialog();
            getLeader();
            getTasks();
            getEmployees();
        }

        private void datagridTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                TaskDetails taskDetails = new TaskDetails((int)senderGrid["TaskID", e.RowIndex].Value, userID, projectID);
                taskDetails.ShowDialog();
                getProject();
                getTasks();
                getStatus();
            } 
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                getProject();
                getLeader();
                getEmployees();
                getComments();
                getTasks();
                getStatus();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            AddProject addProject = new AddProject(userID, projectID);
            addProject.ShowDialog();
            getProject();
            getTasks();
            getStatus();
        }

        private void buttonViewComments_Click(object sender, EventArgs e)
        {
            Comments comments = new Comments(projectID, userID, true);
            comments.ShowDialog();
            getComments();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to remove this task from database?\nThis action cannot be reverted.";
            string title = "Delete task?";
            var res = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                try
                {
                    
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd;
                    con.Open();

                    cmd = new SqlCommand("DELETE a FROM assigned_task a INNER JOIN TASK t" +
                        "               ON a.TaskID = t.TaskID" +
                        "               WHERE t.ProjectID = @projectID", con);
                    cmd.Parameters.AddWithValue("@projectID", projectID);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE FROM TASK" +
                        "               WHERE ProjectID = @projectID", con);
                    cmd.Parameters.AddWithValue("@projectID", projectID);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT COUNT(*) FROM PROJECT", con);
                    Int32 count1 = (Int32)cmd.ExecuteScalar();
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                    cmd = new SqlCommand("DELETE FROM PROJECT_COMMENT WHERE ProjectID = @projectID", con);
                    cmd.Parameters.AddWithValue("@projectID", projectID);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE FROM PROJECT WHERE ProjectID = @projectID", con);
                    cmd.Parameters.AddWithValue("@projectID", projectID);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT COUNT(*) FROM Project", con);
                    Int32 count2 = (Int32)cmd.ExecuteScalar();
                    adapt = new SqlDataAdapter(cmd);

                    if (count1 == count2 + 1)
                    {
                        MessageBox.Show("Deletion successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.Dispose();
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);

                SqlCommand cmd = new SqlCommand("UPDATE PROJECT SET ProjectStatus = 'Accepted' WHERE ProjectID = @projectID", con);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                cmd = new SqlCommand("UPDATE TASK SET TaskStatus = 'Accepted' WHERE ProjectID = @projectID", con);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                buttonAccept.Enabled = false;
                buttonAddComment.Enabled = false;
                buttonDelete.Enabled = false;
                buttonEdit.Enabled = false;
                buttonEditEmp.Enabled = false;
                buttonTasks.Enabled = false;
                getStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddComment_Click(object sender, EventArgs e)
        {
            AddComment addComment = new AddComment(projectID, userID, true);
            addComment.ShowDialog();
            getComments();
        }
    }
}
