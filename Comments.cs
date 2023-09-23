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
    public partial class Comments : Form
    {
        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";
        private int taskID, userID, projectID;
        private bool isInitialized = false;
        private bool isProject = false;

        private void getComments()
        {
            if (isProject)
            {
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("Select ProjectCommentID, ProjectCommentAuthor, ProjectCommentDate, ProjectComment " +
                        "                           FROM PROJECT_COMMENT WHERE ProjectID = @projectID" +
                        "                           ORDER BY ProjectCommentID DESC", con);
                    cmd.Parameters.AddWithValue("@projectID", projectID);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if(dataTable.Columns["ProjectCommentID"] != null)
                    {
                        dataTable.Columns["ProjectCommentID"].ColumnName = "TaskCommentID";
                    }
                    if (dataTable.Columns["ProjectCommentAuthor"] != null)
                    {
                        dataTable.Columns["ProjectCommentAuthor"].ColumnName = "TaskCommentAuthor";
                    }
                    if (dataTable.Columns["ProjectCommentDate"] != null)
                    {
                        dataTable.Columns["ProjectCommentDate"].ColumnName = "TaskCommentDate";
                    }
                    if (dataTable.Columns["ProjectComment"] != null)
                    {
                        dataTable.Columns["ProjectComment"].ColumnName = "TaskComment";
                    }
                    dataGridViewComments.DataSource = dataTable;
                    
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
                    SqlCommand cmd = new SqlCommand("Select TaskCommentID, TaskCommentAuthor, TaskCommentDate, TaskComment " +
                        "                           FROM TASK_COMMENT WHERE TaskID = @taskID" +
                        "                           ORDER BY TaskCommentID DESC", con);
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewComments.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        public Comments(int taskID, int userID)
        {
            InitializeComponent();
            dataGridViewComments.RowHeadersVisible = false;
            this.taskID = taskID;
            this.userID = userID;
            isInitialized = true;
            getComments();

            DataTable dataTableTask = GetData.getTaskByID(connString, taskID);
            if(dataTableTask.Rows[0]["TaskStatus"].ToString() == "Accepted")
            {
                buttonAddComment.Enabled = false;
            }
        }

        public Comments(int projectID, int userID, bool isProject)
        {
            InitializeComponent();
            dataGridViewComments.RowHeadersVisible = false;
            this.projectID = projectID;
            this.userID = userID;
            this.isProject = isProject;
            isInitialized = true;
            getComments();

            DataTable dataTableProject = GetData.getProjectByID(connString, taskID);
            if(dataTableProject.Rows.Count > 0)
            {
                if (dataTableProject.Rows[0]["ProjectStatus"].ToString() == "Accepted")
                {
                    buttonAddComment.Enabled = false;
                }
            }
            
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                getComments();
            }
        }

        private void buttonAddComment_Click(object sender, EventArgs e)
        {
            AddComment addComment = new AddComment(taskID, userID);
            addComment.ShowDialog();
            timerRefresh_Tick(sender, e);
        }
    }
}
