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
    public partial class AddComment : Form
    {

        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";
        private int taskID, userID, projectID;
        private bool isProject = false;

        public AddComment(int taskID, int userID)
        {
            InitializeComponent();
            this.taskID = taskID;
            this.userID = userID;
        }

        public AddComment(int projectID, int userID, bool isProject)
        {
            InitializeComponent();
            this.projectID = projectID;
            this.userID = userID;
            this.isProject = isProject;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(textBoxComment.Text == "")
            {
                MessageBox.Show("Cannot send empty comment.", "Empty comment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataTable dataTableUser = GetData.getUserData(connString, userID);
            if (isProject)
            {
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("INSERT INTO PROJECT_COMMENT(ProjectID, ProjectCommentAuthor, ProjectCommentDate, ProjectComment)" +
                        "                            VALUES(@projectID, @author, @date, @comment)", con);
                    cmd.Parameters.AddWithValue("@projectID", projectID);
                    cmd.Parameters.AddWithValue("@author", dataTableUser.Rows[0]["FirstName"].ToString() + " " + dataTableUser.Rows[0]["Surname"].ToString());
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@comment", textBoxComment.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Close();
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO TASK_COMMENT(TaskID, TaskCommentAuthor, TaskCommentDate, TaskComment)" +
                        "                            VALUES(@taskID, @author, @date, @comment)", con);
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    cmd.Parameters.AddWithValue("@author", dataTableUser.Rows[0]["FirstName"].ToString() + " " + dataTableUser.Rows[0]["Surname"].ToString());
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@comment", textBoxComment.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
