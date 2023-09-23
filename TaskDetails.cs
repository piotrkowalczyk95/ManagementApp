using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ExtensionMethods;
using System.Linq;

namespace ManagementApp
{
    public partial class TaskDetails : Form
    {

        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        private int taskID, userID, projectID;
        private Int32 count1;
        private Int32 count2;
        DataTable dataTableUser;
        DataTable dataTableProject;

        private int checkAssignment()
        {
            try
            {
                int count = 0;
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM ASSIGNED_TASK" +
                    "                           WHERE TaskID = @taskID" +
                    "                           AND EmployeeID = @userID", con);
                cmd.Parameters.AddWithValue("@taskID", taskID);
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                count = (int)cmd.ExecuteScalar();
                con.Close();

                if(dataTableUser.Rows[0]["Permission"].ToString() == "Manager" || dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                {
                    count++;
                }

                return count;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }

        public TaskDetails(int taskID, int userID)
        {
            InitializeComponent();
            this.taskID = taskID;
            this.userID = userID;
            dataTableUser = GetData.getUserData(connString, userID);
            dataEmp.RowHeadersVisible = false;
            dataGridViewComments.RowHeadersVisible = false;
            getTask();
            buttonViewComments.Enabled = false;
            getEmployees();
            getComments();

            if(checkAssignment() <= 0)
            {
                buttonStatus.Enabled = false;
                buttonStatus.Text = "No permission";
            }

            if (dataTableUser.Rows[0]["Permission"].ToString() == "Employee" || dataTableUser.Rows[0]["Permission"] == DBNull.Value)
            {
                buttonEdit.Enabled = false;
                buttonEdit.Visible = false;
                buttonDelete.Enabled = false;
                buttonDelete.Visible = false;
                buttonEditEmp.Enabled = false;
                buttonEditEmp.Visible = false;
            }

            DataTable dataTable = GetData.getTaskByID(connString, taskID);
            if (dataTable.Rows[0]["TaskStatus"].ToString() == "Accepted")
            {
                buttonAddComment.Enabled = false;
                buttonDelete.Enabled = false;
                buttonStatus.Enabled = false;
                buttonEditEmp.Enabled = false;
            }
        }

        public TaskDetails(int taskID, int userID, int projectID)
        {
            InitializeComponent();
            this.taskID = taskID;
            this.userID = userID;
            this.projectID = projectID;
            dataTableUser = GetData.getUserData(connString, userID);
            dataTableProject = GetData.getProjectByID(connString, projectID);
            dataEmp.RowHeadersVisible = false;
            dataGridViewComments.RowHeadersVisible = false;
            getTask();
            buttonViewComments.Enabled = false;
            getEmployees();
            getComments();

            if (checkAssignment() <= 0)
            {
                buttonStatus.Enabled = false;
                buttonStatus.Text = "No permission";
            }

            if (dataTableUser.Rows[0]["Permission"].ToString() == "Employee" || dataTableUser.Rows[0]["Permission"] == DBNull.Value)
            {
                buttonEdit.Enabled = false;
                buttonEdit.Visible = false;
                buttonDelete.Enabled = false;
                buttonDelete.Visible = false;
                buttonEditEmp.Enabled = false;
                buttonEditEmp.Visible = false;
            }

            DataTable dataTable = GetData.getTaskByID(connString, taskID);
            if (dataTableProject.Rows[0]["ProjectType"].ToString() == "Waterfall")
            {
                
                if (getPrevious((int)dataTable.Rows[0]["ProjectSortNumber"]) == false)
                {
                    buttonStatus.Enabled = false;
                }
            }
            
            if (dataTable.Rows[0]["TaskStatus"].ToString() == "Accepted")
            {
                buttonAddComment.Enabled = false;
                buttonDelete.Enabled = false;
                buttonStatus.Enabled = false;
                buttonEditEmp.Enabled = false;
            }
        }

        private bool getPrevious(int sortNumber)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT TaskStatus FROM TASK WHERE ProjectID = @projectID AND ProjectSortNumber = @sortNumber", con);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                cmd.Parameters.AddWithValue("@sortNumber", sortNumber - 1);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.Close();

                if(dataTable.Rows.Count > 0)
                {
                    if (dataTable.Rows[0]["TaskStatus"] != DBNull.Value)
                    {
                        if (dataTable.Rows[0]["TaskStatus"].ToString() == "Done")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to remove this task from database?\nThis action cannot be reverted.";
            string title = "Delete task?";
            var res = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(res == DialogResult.Yes)
            {
                try
                {
                    if(dataTableProject != null)
                    {
                        SqlConnection con = new SqlConnection(connString);
                        SqlCommand cmd;
                        con.Open();

                        cmd = new SqlCommand("SELECT ProjectSortNumber FROM task WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@taskID", taskID);
                        Int32 sortValueStart = (Int32)cmd.ExecuteScalar();

                        cmd = new SqlCommand("SELECT COUNT(*) FROM task WHERE ProjectID = @projectID", con);
                        cmd.Parameters.AddWithValue("@projectID", projectID);
                        Int32 sortValueEnd = (Int32)cmd.ExecuteScalar();

                        cmd = new SqlCommand("DELETE FROM assigned_task WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@taskID", taskID);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("SELECT COUNT(*) FROM task", con);
                        count1 = (Int32)cmd.ExecuteScalar();
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                        cmd = new SqlCommand("DELETE FROM TASK_COMMENT WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@taskID", taskID);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE FROM task WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@taskID", taskID);
                        cmd.ExecuteNonQuery();

                        for(int i = sortValueStart; i < sortValueEnd; i++)
                        {
                            cmd = new SqlCommand("UPDATE TASK SET ProjectSortNumber = @sortNumber " +
                                "               WHERE ProjectSortNumber = @sortNumberOld" +
                                "               AND ProjectID = @projectID", con);
                            cmd.Parameters.AddWithValue("@sortNumber", i);
                            cmd.Parameters.AddWithValue("@sortNumberOld", i + 1);
                            cmd.Parameters.AddWithValue("@projectID", projectID);
                            cmd.ExecuteNonQuery();
                        }

                        cmd = new SqlCommand("SELECT COUNT(*) FROM task", con);
                        count2 = (Int32)cmd.ExecuteScalar();
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
                    else
                    {
                        SqlConnection con = new SqlConnection(connString);
                        SqlCommand cmd;
                        con.Open();

                        cmd = new SqlCommand("DELETE FROM assigned_task WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@taskID", taskID);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("SELECT COUNT(*) FROM task", con);
                        count1 = (Int32)cmd.ExecuteScalar();
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                        cmd = new SqlCommand("DELETE FROM TASK_COMMENT WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@taskID", taskID);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE FROM task WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@taskID", taskID);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("SELECT COUNT(*) FROM task", con);
                        count2 = (Int32)cmd.ExecuteScalar();
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.Dispose(); ;
            }
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            if(dataTableProject != null)
            {
                AssignEmployee assignEmployee = new AssignEmployee(taskID, userID, dataTableProject.Rows[0]["ProjectName"].ToString());
                assignEmployee.ShowDialog();
                timerRefresh_Tick(sender, e);
            }
            else
            {
                AssignEmployee assignEmployee = new AssignEmployee(taskID, userID);
                assignEmployee.ShowDialog();
                timerRefresh_Tick(sender, e);
            }

        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            getTask();
            getEmployees();
            getComments();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(dataTableProject != null)
            {
                AddTask addTask = new AddTask(taskID, dataTableProject.Rows[0]["ProjectName"].ToString());
                addTask.ShowDialog();
                timerRefresh_Tick(sender, e);
            }
            else
            {
                AddTask addTask = new AddTask(userID, taskID);
                addTask.ShowDialog();
                timerRefresh_Tick(sender, e);
            }
            
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" || dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
            {
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("UPDATE TASK SET TaskStatus = @status WHERE TaskID = @taskID", con);
                    cmd.Parameters.AddWithValue("@status", "To be fixed");
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    buttonStatus.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(dataTableProject != null)
            {
                if(dataTableProject.Rows[0]["ProjectLeader"] != DBNull.Value)
                {
                    if (dataTableUser.Rows[0]["Pesel"].ToString() == dataTableProject.Rows[0]["ProjectLeader"].ToString())
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection(connString);
                            SqlCommand cmd = new SqlCommand("UPDATE TASK SET TaskStatus = @status WHERE TaskID = @taskID", con);
                            cmd.Parameters.AddWithValue("@status", "To be fixed");
                            cmd.Parameters.AddWithValue("@taskID", taskID);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                
            }
            getTask();
        }

        private void buttonViewComments_Click(object sender, EventArgs e)
        {
            Comments comments = new Comments(taskID, userID);
            comments.ShowDialog();
            getComments();
        }

        private void buttonAddComment_Click(object sender, EventArgs e)
        {
            AddComment addComment = new AddComment(taskID, userID);
            addComment.ShowDialog();
            getComments();
        }

        private void buttonStatus_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT TaskStatus FROM TASK WHERE TaskID = @taskID", con);
                cmd.Parameters.AddWithValue("@taskID", taskID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.Close();
                if (dataTable.Rows[0]["TaskStatus"].ToString() == "Pending" || dataTable.Rows[0]["TaskStatus"].ToString() == "Active" 
                    || dataTable.Rows[0]["TaskStatus"].ToString() == "To be fixed")
                {
                    cmd = new SqlCommand("UPDATE TASK SET TaskStatus = @status, TaskSubmitted = @date WHERE TaskID = @taskID", con);
                    cmd.Parameters.AddWithValue("@status", "Verifying");
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    buttonStatus.Enabled = true;
                }
                else if (dataTable.Rows[0]["TaskStatus"].ToString() == "Verifying")
                {
                    if (dataTableProject != null)
                    {
                        if (dataTableUser.Rows[0]["Pesel"] == dataTableProject.Rows[0]["ProjectLeader"])
                        {
                            try
                            {
                                cmd = new SqlCommand("UPDATE TASK SET TaskStatus = @status, TaskSubmitted = @date WHERE TaskID = @taskID", con);
                                cmd.Parameters.AddWithValue("@status", "Done");
                                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@taskID", taskID);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if(dataTableUser.Rows[0]["Permission"].ToString() == "Manager" || dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                        {
                            try
                            {
                                cmd = new SqlCommand("UPDATE TASK SET TaskStatus = @status, TaskSubmitted = @date WHERE TaskID = @taskID", con);
                                cmd.Parameters.AddWithValue("@status", "Done");
                                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                                cmd.Parameters.AddWithValue("@taskID", taskID);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            buttonStatus.Enabled = false;
                            buttonStatus.Text = "Awaiting Verification";
                        }

                    }
                    else
                    {
                        cmd = new SqlCommand("UPDATE TASK SET TaskStatus = @status, TaskSubmitted = @date WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@status", "Done");
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@taskID", taskID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }  
                }
                else if (dataTable.Rows[0]["TaskStatus"].ToString() == "Done")
                {
                    if(dataTableProject != null)
                    {
                        buttonStatus.Enabled = false;
                        buttonStatus.Text = "Done";

                    }
                    else
                    {
                        if (dataTableUser.Rows[0]["Permission"].ToString() == "Employee")
                        {
                            buttonStatus.Enabled = false;
                            buttonStatus.Text = "Awaiting Confirmation";
                        }
                        else
                        {
                            cmd = new SqlCommand("Select FirstName, Surname FROM EMPLOYEE WHERE EmployeeID = @employeeID", con);
                            cmd.Parameters.AddWithValue("@employeeID", userID);
                            con.Open();
                            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                            dataTable = new DataTable();
                            adapt.Fill(dataTable);
                            string supervisor = dataTable.Rows[0]["FirstName"].ToString() + " " + dataTable.Rows[0]["Surname"].ToString();
                            con.Close();
                            cmd = new SqlCommand("UPDATE TASK SET TaskStatus = @status, Supervisor = @supervisor, " +
                                "TaskSubmitted = @date WHERE TaskID = @taskID", con);
                            cmd.Parameters.AddWithValue("@status", "Accepted");
                            cmd.Parameters.AddWithValue("@supervisor", supervisor);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@taskID", taskID);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                else
                {
                    buttonStatus.Visible = false;
                    buttonReturn.Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            getTask();
        }

        private void getEmployees()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT Surname, FirstName, Department, PhoneNumber, PhoneVisible, Email, EmailVisible FROM EMPLOYEE" +
                    "                           INNER JOIN ASSIGNED_TASK" +
                    "                           ON EMPLOYEE.EmployeeID = ASSIGNED_TASK.EmployeeID" +
                    "                           WHERE ASSIGNED_TASK.TaskID = @taskID", con);
                cmd.Parameters.AddWithValue("@taskID", taskID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                con.Close();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (dataTableUser.Rows[0]["Permission"].ToString() != "Manager" && dataTableUser.Rows[0]["Permission"].ToString() != "Administrator")
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
                    else
                    {
                        if (dataRow["PhoneNumber"] == DBNull.Value)
                        {
                            dataRow["PhoneNumber"] = "Unavailable";
                        }
                        if (dataRow["Email"] == DBNull.Value)
                        {
                            dataRow["Email"] = "Unavailable";
                        }
                    }
                    
                }
                dataEmp.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getComments()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd, cmdCount;

                cmd = new SqlCommand("SELECT TOP 3 TaskCommentID, TaskCommentAuthor, TaskCommentDate, TaskComment " +
                    "               FROM TASK_COMMENT WHERE TaskID = @taskID " +
                    "               ORDER BY TaskCommentID DESC", con);
                cmd.Parameters.AddWithValue("@taskID", taskID);
                cmdCount = new SqlCommand("SELECT COUNT(*) FROM TASK_COMMENT WHERE TaskID = @taskID", con);
                cmdCount.Parameters.AddWithValue("@taskID", taskID);

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

        private void getTask()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;

                cmd = new SqlCommand("SELECT TaskName, Priority, DueDate, TaskStatus, TaskDesc, TaskSubmitted, Supervisor FROM task WHERE TaskID = @taskID", con);
                cmd.Parameters.AddWithValue("@taskID", taskID);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapt.Fill(dataTable);
                con.Close();

                buttonReturn.Visible = false;
                buttonReturn.Enabled = false;
                labelTaskname.Text = dataTable.Rows[0]["TaskName"].ToString();
                DateTime dueDate = (DateTime)dataTable.Rows[0]["DueDate"];
                labelDue.Text = dueDate.ToString("dd-MM-yyyy");
                labelPriority.Text = dataTable.Rows[0]["Priority"].ToString();
                string dateSubmit = null;
                if(dataTable.Rows[0]["TaskSubmitted"] != DBNull.Value)
                {
                    DateTime dateTemp = (DateTime)dataTable.Rows[0]["TaskSubmitted"];
                    dateSubmit = dateTemp.ToString("dd-MM-yyyy");
                }
                
                if (dataTable.Rows[0]["TaskDesc"] != DBNull.Value)
                {
                    labelDesc.Text = dataTable.Rows[0]["TaskDesc"].ToString();
                }
                else
                {
                    labelDesc.Text = "No submitted description";
                }
                if (dataTable.Rows[0]["TaskStatus"].ToString() != "Pending" && dataTable.Rows[0]["TaskStatus"].ToString() != "Active" &&
                    dataTable.Rows[0]["TaskStatus"].ToString() != "Accepted") 
                {
                    if(dataTable.Rows[0]["TaskStatus"].ToString() == "Verifying")
                    {
                        buttonStatus.Text = "Change Status to \"Done\"";

                        
                        if (dataTableUser.Rows[0]["Pesel"] != dataTableProject.Rows[0]["ProjectLeader"] &&
                            (dataTableUser.Rows[0]["Permission"].ToString() != "Manager" && dataTableUser.Rows[0]["Permission"].ToString() != "Administrator"))
                        {
                            buttonStatus.Enabled = false;
                        }
                                           }
                    else if(dataTable.Rows[0]["TaskStatus"].ToString() == "To be fixed")
                    {
                        buttonStatus.Text = "Change Status to \"Verifying\"";
                    }
                    else if(dataTable.Rows[0]["TaskStatus"].ToString() == "Done")
                    {
                        if(dataTableProject != null)
                        {
                            buttonStatus.Enabled = false;
                            buttonStatus.Text = "Done";
                        }
                        if (dataTableUser.Rows[0]["Permission"].ToString() == "Employee")
                        {
                            buttonStatus.Enabled = false;
                            buttonStatus.Text = "Awaiting Confirmation";
                        }
                        else
                        {
                            buttonReturn.Enabled = true;
                            buttonReturn.Visible = true;
                            buttonStatus.Text = "Accept Task";
                        }
                    }
                    labelStatus.Text = dataTable.Rows[0]["TaskStatus"].ToString() + " " + dateSubmit;
                }
                else if(dataTable.Rows[0]["TaskStatus"].ToString() == "Accepted")
                {
                    buttonAddComment.Enabled = false;
                    buttonDelete.Enabled = false;
                    buttonEdit.Enabled = false;
                    buttonEditEmp.Enabled = false;
                    buttonStatus.Enabled = false;
                    buttonReturn.Visible = false;
                    buttonStatus.Visible = false;
                    labelStatus.Text = "Accepted by " + dataTable.Rows[0]["Supervisor"].ToString() + " " + dateSubmit;
                }
                else
                {
                    labelStatus.Text = dataTable.Rows[0]["TaskStatus"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
