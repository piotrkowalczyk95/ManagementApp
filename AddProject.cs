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
    public partial class AddProject : Form
    {
        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";
        private DataTable dataTableUser, dataTableProject;
        private int userID, projectID;
        private List<string> dataSourceDept;

        private void getListDept()
        {
            try
            {
                dataSourceDept = new List<string>();
                dataSourceDept.Add("Not assigned");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public AddProject(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            dataTableUser = GetData.getUserData(connString, userID);
            if(dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
            {
                comboBoxDept.Text = dataTableUser.Rows[0]["Department"].ToString();
                comboBoxDept.Enabled = false;
            }
            else
            {
                getListDept();
                comboBoxDept.DataSource = dataSourceDept;
            }
            dateTimeDue.MinDate = DateTime.Now.AddDays(1);
            dateTimeDue.Value = DateTime.Now.AddDays(1);
            comboBoxPriority.SelectedIndex = 0;
            checkBoxScrum.Checked = true;
        }

        public AddProject(int userID, int projectID)
        {
            InitializeComponent();
            this.userID = userID;
            this.projectID = projectID;
            dataTableUser = GetData.getUserData(connString, userID);
            dataTableProject = GetData.getProjectByID(connString, projectID);

            textBoxProjName.Text = dataTableProject.Rows[0]["ProjectName"].ToString();
            textBoxProjName.Enabled = false;
            comboBoxPriority.SelectedItem = dataTableProject.Rows[0]["ProjectPriority"].ToString();
            dateTimeDue.Value = (DateTime)dataTableProject.Rows[0]["ProjectDue"];
            dateTimeDue.MinDate = (DateTime)dataTableProject.Rows[0]["ProjectDue"];
            if (dataTableProject.Rows[0]["ProjectType"].ToString() == "Scrum")
            {
                checkBoxScrum.Checked = true;
            }
            else
            {
                checkBoxWaterfall.Checked = true;
            }

            if(dataTableProject.Rows[0]["ProjectDesc"] != DBNull.Value)
            {
                textBoxDesc.Text = dataTableProject.Rows[0]["ProjectDesc"].ToString();
            }

            if (dataTableUser.Rows[0]["Department"] == DBNull.Value)
            {
                comboBoxDept.Text = "Not assigned";
            }
            else
            {
                comboBoxDept.Text = dataTableUser.Rows[0]["Department"].ToString();
            }
            comboBoxDept.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this window?\nUnsubmitted changes will be lost.",
                "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void newProject()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PROJECT WHERE ProjectName = @projectName AND ProjectStatus != 'Accepted'", con);
                cmd.Parameters.AddWithValue("@projectName", textBoxProjName.Text);
                con.Open();
                Int32 count = (Int32)cmd.ExecuteScalar();
                con.Close();
                if (count > 0)
                {
                    MessageBox.Show("Another active project with the same name already exists.", "Duplicate name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cmd = new SqlCommand("INSERT INTO PROJECT(ProjectName, ProjectDue, ProjectPriority, ProjectType, ProjectDesc, Department, ProjectStatus)" +
                    "VALUES(@projName, @projDue, @projPriority, @projType, @projDesc, @projDept, @projStatus)", con);
                cmd.Parameters.AddWithValue("@projName", textBoxProjName.Text);
                cmd.Parameters.AddWithValue("@projDue", dateTimeDue.Value);
                cmd.Parameters.AddWithValue("@projPriority", comboBoxPriority.SelectedItem.ToString());
                if (checkBoxScrum.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@projType", "Scrum");
                }
                else if (checkBoxWaterfall.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@projType", "Waterfall");
                }
                if (textBoxDesc.Text == "")
                {
                    cmd.Parameters.AddWithValue("@projDesc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@projDesc", textBoxDesc.Text);
                }
                if (comboBoxDept.Text.ToString() == "Not assigned")
                {
                    cmd.Parameters.AddWithValue("@projDept", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@projDept", comboBoxDept.Text.ToString());
                }
                cmd.Parameters.AddWithValue("@projStatus", "Pending");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                AddProjectTasks addProjectTasks = new AddProjectTasks(userID, textBoxProjName.Text);
                addProjectTasks.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editProject()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PROJECT WHERE ProjectName = @projectName " +
                    "                           AND ProjectStatus != 'Accepted'" +
                    "                           AND ProjectID != @projectID", con);
                cmd.Parameters.AddWithValue("@projectName", textBoxProjName.Text);
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                Int32 count = (Int32)cmd.ExecuteScalar();
                con.Close();
                if (count > 0)
                {
                    MessageBox.Show("Another active project with the same name already exists.", "Duplicate name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                cmd = new SqlCommand("UPDATE PROJECT SET ProjectDue = @projDue, ProjectPriority = @projPriority, " +
                    "               ProjectType = @projType, ProjectDesc = @projDesc" +
                    "               WHERE ProjectID = @projectID", con);
                cmd.Parameters.AddWithValue("@projDue", dateTimeDue.Value);
                cmd.Parameters.AddWithValue("@projPriority", comboBoxPriority.SelectedItem.ToString());
                if (checkBoxScrum.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@projType", "Scrum");
                }
                else if (checkBoxWaterfall.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@projType", "Waterfall");
                }
                if (textBoxDesc.Text == "")
                {
                    cmd.Parameters.AddWithValue("@projDesc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@projDesc", textBoxDesc.Text);
                }
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                cmd = new SqlCommand("UPDATE TASK SET Priority = @priority" +
                    "                   WHERE ProjectID = @projectID", con);
                cmd.Parameters.AddWithValue("@priority", comboBoxPriority.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@projectID", projectID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                AddProjectTasks addProjectTasks = new AddProjectTasks(userID, textBoxProjName.Text);
                addProjectTasks.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if(dataTableProject == null)
            {
                newProject();
            }
            else
            {
                editProject();
            }
        }

        private void checkBoxScrum_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxScrum.Checked == true)
            {
                checkBoxWaterfall.Checked = false;
            }
            else
            {
                checkBoxWaterfall.Checked = true;
            }
        }

        private void checkBoxWaterfall_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWaterfall.Checked == true)
            {
                checkBoxScrum.Checked = false;
            }
            else
            {
                checkBoxScrum.Checked = true;
            }
        }
    }
}
