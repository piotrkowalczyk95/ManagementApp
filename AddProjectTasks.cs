using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ManagementApp
{
    public partial class AddProjectTasks : Form
    {
        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";
        DataTable dataTableProject;
        private string projectName;
        private int userID;

        private void getProject()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select ProjectLeader, ProjectID, ProjectType FROM PROJECT " +
                    "                           WHERE ProjectName = @projectName" +
                    "                           AND ProjectStatus != 'Accepted'", con);
                cmd.Parameters.AddWithValue("@projectName", projectName);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dataTableProject = new DataTable();
                adapter.Fill(dataTableProject);
                con.Close();

                if (dataTableProject.Rows[0]["ProjectLeader"] != DBNull.Value)
                {
                    cmd = new SqlCommand("SELECT FirstName, Surname FROM EMPLOYEE WHERE PESEL = @projectLeader", con);
                    cmd.Parameters.AddWithValue("@projectLeader", dataTableProject.Rows[0]["ProjectLeader"].ToString());
                    con.Open();
                    adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    con.Close();
                    labelLeader.Text = dataTable.Rows[0]["FirstName"].ToString() + " " + dataTable.Rows[0]["Surname"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getTasks(int projectID)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select ProjectSortNumber, TaskName, DueDate, TaskStatus, TaskID" +
                    "                           FROM TASK WHERE ProjectID = @projectID" +
                    "                           ORDER BY ProjectSortNumber ASC", con);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTableTask = new DataTable();
                adapter.Fill(dataTableTask);
                con.Close();

                dataGridViewTask.DataSource = dataTableTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public AddProjectTasks(int userID, string projectName)
        {
            InitializeComponent();
            this.projectName = projectName;
            this.userID = userID;
            dataGridViewTask.AutoGenerateColumns = false;
            getProject();
            if(dataTableProject.Rows[0]["ProjectID"] != DBNull.Value)
            {
                getTasks((int)dataTableProject.Rows[0]["ProjectID"]);
                if(dataTableProject.Rows[0]["ProjectType"].ToString() != "Waterfall")
                {
                    dataGridViewTask.Columns["Up"].Visible = false;
                    dataGridViewTask.Columns["Down"].Visible = false;
                }
            } 
        }

        private void buttonProjectLeader_Click(object sender, EventArgs e)
        {
            AssignEmployee assignEmployee = new AssignEmployee((int)dataTableProject.Rows[0]["ProjectID"], userID, true);
            assignEmployee.ShowDialog();
            getProject();
        }

        private void moveTaskUp(int sortID)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT DueDate FROM TASK WHERE ProjectID = @projectID AND ProjectSortNumber = @sortNumber", con);
                cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                cmd.Parameters.AddWithValue("@sortNumber", sortID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTableCurr = new DataTable();
                adapter.Fill(dataTableCurr);
                con.Close();

                cmd = new SqlCommand("SELECT DueDate FROM TASK WHERE ProjectID = @projectID AND ProjectSortNumber = @sortNumber", con);
                cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                cmd.Parameters.AddWithValue("@sortNumber", sortID);
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                DataTable dataTableNew = new DataTable();
                adapter.Fill(dataTableNew);
                con.Close();

                cmd = new SqlCommand("UPDATE TASK SET DueDate = @dueDate, ProjectSortNumber = 0" +
                    "               WHERE ProjectSortNumber = @sortNumber AND ProjectID = @projectID", con);
                cmd.Parameters.AddWithValue("@dueDate", dataTableCurr.Rows[0]["DueDate"]);
                cmd.Parameters.AddWithValue("@sortNumber", sortID - 1);
                cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                SqlCommand cmd2 = new SqlCommand("UPDATE TASK SET DueDate = @dueDate, ProjectSortNumber = @sortNumberNew" +
                    "                               WHERE ProjectSortNumber = @sortNumberOld AND ProjectID = @projectID", con);
                cmd2.Parameters.AddWithValue("@dueDate", dataTableNew.Rows[0]["DueDate"]);
                cmd2.Parameters.AddWithValue("@sortNumberNew", sortID - 1);
                cmd2.Parameters.AddWithValue("@sortNumberOld", sortID);
                cmd2.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                SqlCommand cmd3 = new SqlCommand("UPDATE TASK SET ProjectSortNumber = @sortNumber WHERE ProjectSortNumber = 0" +
                    "                               AND ProjectID = @projectID", con);
                cmd3.Parameters.AddWithValue("@sortNumber", sortID);
                cmd3.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            getTasks((int)dataTableProject.Rows[0]["ProjectID"]);
        }

        private void moveTaskDown(int sortID)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;

                cmd = new SqlCommand("SELECT DueDate FROM TASK WHERE ProjectID = @projectID AND ProjectSortNumber = @sortNumber", con);
                cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                cmd.Parameters.AddWithValue("@sortNumber", sortID);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTableCurr = new DataTable();
                adapter.Fill(dataTableCurr);
                con.Close();

                cmd = new SqlCommand("SELECT DueDate FROM TASK WHERE ProjectID = @projectID AND ProjectSortNumber = @sortNumber", con);
                cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                cmd.Parameters.AddWithValue("@sortNumber", sortID + 1);
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                DataTable dataTableNew = new DataTable();
                adapter.Fill(dataTableNew);
                con.Close();

                cmd = new SqlCommand("UPDATE TASK SET DueDate = @dueDate, ProjectSortNumber = 0" +
                    "               WHERE ProjectSortNumber = @sortNumber AND ProjectID = @projectID", con);
                cmd.Parameters.AddWithValue("@dueDate", dataTableCurr.Rows[0]["DueDate"]);
                cmd.Parameters.AddWithValue("@sortNumber", sortID + 1);
                cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                SqlCommand cmd2 = new SqlCommand("UPDATE TASK SET DueDate = @dueDate, ProjectSortNumber = @sortNumberNew" +
                    "                               WHERE ProjectSortNumber = @sortNumberOld AND ProjectID = @projectID", con);
                cmd2.Parameters.AddWithValue("@dueDate", dataTableNew.Rows[0]["DueDate"]);
                cmd2.Parameters.AddWithValue("@sortNumberNew", sortID + 1);
                cmd2.Parameters.AddWithValue("@sortNumberOld", sortID);
                cmd2.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                SqlCommand cmd3 = new SqlCommand("UPDATE TASK SET ProjectSortNumber = @sortNumber WHERE ProjectSortNumber = 0" +
                    "                               AND ProjectID = @projectID", con);
                cmd3.Parameters.AddWithValue("@sortNumber", sortID);
                cmd3.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            getTasks((int)dataTableProject.Rows[0]["ProjectID"]);
        }

        private void dataGridViewTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = this.dataGridViewTask.Columns[e.ColumnIndex].Name;
            if (e.RowIndex >= 0 && columnName == "Up")
            {
                if(e.RowIndex > 0)
                {
                    moveTaskUp((int)dataGridViewTask.Rows[e.RowIndex].Cells["ID"].Value);
                }
            }
            else if (e.RowIndex >= 0 && columnName == "Down")
            {
                if (e.RowIndex + 1 < dataGridViewTask.Rows.Count)
                {
                    moveTaskDown((int)dataGridViewTask.Rows[e.RowIndex].Cells["ID"].Value);
                }
            }
            else if(e.RowIndex >= 0 && columnName == "EditTask")
            {
                AddTask addTask = new AddTask((int)dataGridViewTask.Rows[e.RowIndex].Cells["TaskID"].Value, projectName);
                addTask.ShowDialog();
                getTasks((int)dataTableProject.Rows[0]["ProjectID"]);
            }
        }

        private void buttonTask_Click(object sender, EventArgs e)
        {
            AddTask addTask = new AddTask(projectName);
            addTask.ShowDialog();
            getTasks((int)dataTableProject.Rows[0]["ProjectID"]);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
