using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ExtensionMethods;

namespace ManagementApp
{
    public partial class AssignEmployee : Form
    {
        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";

        private int taskID, userID, select, projectID;
        private string projectName = null;
        private Int32 count1;
        private Int32 count2;
        Dictionary<int, bool> keyValuePairs;
        DataTable dataTableUser;
        DataTable dataTableProject;
        List<string> dataSourceDept, dataSourcePositionAll, dataSourcePosition;
        private bool isInitialized = false;
        private bool isLeaderSelect = false;
        private bool isProjectTaskAssign = false;

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

        private void getEmployeesProjectTask()
        {
            try
            {
                SqlCommand cmd = null;
                SqlConnection con = new SqlConnection(connString);

                DataTable dataTable = new DataTable();

                if (select == 1)
                {
                    buttonAll.BackColor = Color.CornflowerBlue;
                    buttonAll.ForeColor = Color.White;
                    buttonAssigned.BackColor = DefaultBackColor;
                    buttonAssigned.ForeColor = DefaultForeColor;
                    buttonNotAssigned.BackColor = DefaultBackColor;
                    buttonNotAssigned.ForeColor = DefaultForeColor;
                    string queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee ";
                    
                    queryString += " INNER JOIN ASSIGNED_PROJECT" +
                        "           ON EMPLOYEE.EmployeeID = ASSIGNED_PROJECT.EmployeeID";
                    
                    queryString += " where (Lower(FirstName) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%') " +
                        "            OR Lower(Surname) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%'))" +
                        "            AND ASSIGNED_PROJECT.ProjectID = @projectID" +
                        "            AND ISBLOCKED = 0 ";
                    if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                            else if (comboBoxPermission.Text.ToString() == "Not assigned")
                            {
                                queryString += " AND Permission IS NULL";
                            }
                            else
                            {
                                queryString += " AND Permission != 'Administrator'";
                            }
                    }
                    else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                    }
                    else if (comboBoxDepartment.Text.ToString() == "All")
                    {
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EMPLOYEE.EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                            if(dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                            {
                                queryString += " OR Permission IS NULL";
                            }
                        }
                    }

                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["Department"] == DBNull.Value)
                        {
                            dataRow["Department"] = "Not assigned";
                        }
                        if (dataRow["Permission"] == DBNull.Value)
                        {
                            dataRow["Permission"] = "Not assigned";
                        }
                    }


                }
                else if (select == 2)
                {
                    buttonAssigned.BackColor = Color.CornflowerBlue;
                    buttonAssigned.ForeColor = Color.White;
                    buttonAll.BackColor = DefaultBackColor;
                    buttonAll.ForeColor = DefaultForeColor;
                    buttonNotAssigned.BackColor = DefaultBackColor;
                    buttonNotAssigned.ForeColor = DefaultForeColor;
                    string queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee " +
                        "                           INNER JOIN ASSIGNED_TASK " +
                        "                           ON Employee.EmployeeID = ASSIGNED_TASK.EmployeeID ";
                    
                    queryString += " INNER JOIN ASSIGNED_PROJECT" +
                        "           ON EMPLOYEE.EmployeeID = ASSIGNED_PROJECT.EmployeeID";
                    
                    queryString += " where (Lower(FirstName) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%') " +
                        "            OR Lower(Surname) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%'))" +
                        "            AND TaskID = @taskID" +
                        "            AND ASSIGNED_PROJECT.ProjectID = @projectID" +
                        "            AND ISBLOCKED = 0 ";

                    if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                        }
                    }
                    else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                    }
                    else if (comboBoxDepartment.Text.ToString() == "All")
                    {
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                            {
                                queryString += " OR Permission IS NULL";
                            }
                        }
                    }

                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (keyValuePairs.ContainsKey((int)dataRow["EmployeeID"]))
                        {
                            if (keyValuePairs[(int)dataRow["EmployeeID"]] == false)
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
                            queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee ";
                            
                            queryString += " INNER JOIN ASSIGNED_PROJECT" +
                                "           ON EMPLOYEE.EmployeeID = ASSIGNED_PROJECT.EmployeeID";
                            
                            queryString += " WHERE NOT EXISTS(SELECT NULL FROM ASSIGNED_TASK " +
                                "            WHERE Employee.EmployeeID = ASSIGNED_TASK.EmployeeID " +
                                "            AND TaskID = @taskID) " +
                                "            AND (Lower(FirstName) LIKE " +
                                "            CONCAT('%', Lower(@searchEmp), '%') " +
                                "            OR Lower(Surname) LIKE " +
                                "            CONCAT('%', Lower(@searchEmp), '%'))" +
                                "            AND ASSIGNED_PROJECT.ProjectID = @projectID" +
                                "            AND ISBLOCKED = 0 ";

                            if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                            {
                                queryString += " AND Department = @department";
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    queryString += " AND Permission != 'Administrator'";
                                }
                            }
                            else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                            {
                                queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                            }
                            else if (comboBoxDepartment.Text.ToString() == "All")
                            {
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    queryString += " AND Permission != 'Administrator'";
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                                    {
                                        queryString += " OR Permission IS NULL";
                                    }
                                }
                            }

                            cmd = new SqlCommand(queryString, con); 
                            cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                            cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                            cmd.Parameters.AddWithValue("@employeeID", keyValuePair.Key);
                            cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                            cmd.Parameters.AddWithValue("@taskID", taskID);
                            cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
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

                    foreach (DataGridViewRow dataGridViewRow in dataEmp.Rows)
                    {
                        dataGridViewRow.Cells["SelectEmp"].Value = true;
                    }
                }
                else if (select == 3)
                {
                    buttonNotAssigned.BackColor = Color.CornflowerBlue;
                    buttonNotAssigned.ForeColor = Color.White;
                    buttonAll.BackColor = DefaultBackColor;
                    buttonAll.ForeColor = DefaultForeColor;
                    buttonAssigned.ForeColor = DefaultForeColor;
                    buttonAssigned.BackColor = DefaultBackColor;
                    string queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee ";
                    
                    queryString += " INNER JOIN ASSIGNED_PROJECT" +
                        "           ON EMPLOYEE.EmployeeID = ASSIGNED_PROJECT.EmployeeID";
                    
                    queryString += " WHERE NOT EXISTS(SELECT NULL FROM ASSIGNED_TASK " +
                        "            WHERE Employee.EmployeeID = ASSIGNED_TASK.EmployeeID " +
                        "            AND TaskID = @taskID) " +
                        "            AND (Lower(FirstName) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%') " +
                        "            OR Lower(Surname) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%'))" +
                        "            AND ASSIGNED_PROJECT.ProjectID = @projectID" +
                        "            AND ISBLOCKED = 0 ";

                    if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                            {
                                if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                {
                                    queryString += " AND EmployeeID = @userID";
                                }
                                else
                                {
                                    queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                }
                            }
                            else if (comboBoxPermission.Text.ToString() == "Not assigned")
                            {
                                queryString += " AND Permission IS NULL";
                            }
                            else
                            {
                                queryString += " AND Permission != 'Administrator'";
                            }
                        }
                    }
                    else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                    }
                    else if (comboBoxDepartment.Text.ToString() == "All")
                    {
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EMPLOYEE.EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                            {
                                queryString += " OR Permission IS NULL";
                            }
                        }
                    }

                    cmd = new SqlCommand(queryString, con);   
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                    cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (keyValuePairs.ContainsKey((int)dataRow["EmployeeID"]))
                        {
                            if (keyValuePairs[(int)dataRow["EmployeeID"]] == true)
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
                            queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee ";
                            
                            queryString += " INNER JOIN ASSIGNED_PROJECT" +
                                "           ON EMPLOYEE.EmployeeID = ASSIGNED_PROJECT.EmployeeID";
                            
                            queryString += " INNER JOIN ASSIGNED_TASK " +
                                "            ON Employee.EmployeeID = ASSIGNED_TASK.EmployeeID " +
                                "            where (Lower(FirstName) LIKE " +
                                "            CONCAT('%', Lower(@searchEmp), '%') " +
                                "            OR Lower(Surname) LIKE " +
                                "            CONCAT('%', Lower(@searchEmp), '%'))" +
                                "            AND TaskID = @taskID" +
                                "            AND ASSIGNED_PROJECT.ProjectID = @projectID" +
                                "            AND ISBLOCKED = 0 ";


                            if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                            {
                                queryString += " AND Department = @department";
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                    {
                                        if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                        {
                                            queryString += " AND EmployeeID = @userID";
                                        }
                                        else
                                        {
                                            queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                        }
                                    }
                                    else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                    {
                                        queryString += " AND Permission IS NULL";
                                    }
                                    else
                                    {
                                        queryString += " AND Permission != 'Administrator'";
                                    }
                                }
                            }
                            else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                            {
                                queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                            }
                            else if (comboBoxDepartment.Text.ToString() == "All")
                            {
                                queryString += " AND DEPARTMENT IS NOT NULL";
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                    {
                                        queryString += " AND EMPLOYEE.EmployeeID = @userID";
                                    }
                                    else
                                    {
                                        queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                    }
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    queryString += " AND Permission != 'Administrator'";
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                                    {
                                        queryString += " OR Permission IS NULL";
                                    }
                                }
                            }

                            cmd = new SqlCommand(queryString, con);
                            cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                            cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                            cmd.Parameters.AddWithValue("@employeeID", keyValuePair.Key);
                            cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                            cmd.Parameters.AddWithValue("@taskID", taskID);
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

                    foreach (DataGridViewRow dataGridViewRow in dataEmp.Rows)
                    {
                        dataGridViewRow.Cells["SelectEmp"].Value = false;
                    }
                }

                dataEmp.ReadOnly = true;
                dataEmp.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getEmployeesTask()
        {
            try
            {
                SqlCommand cmd = null;
                SqlConnection con = new SqlConnection(connString);
                DataTable dataTable = new DataTable();

                if (select == 1)
                {
                    buttonAll.BackColor = Color.CornflowerBlue;
                    buttonAll.ForeColor = Color.White;
                    buttonAssigned.BackColor = DefaultBackColor;
                    buttonAssigned.ForeColor = DefaultForeColor;
                    buttonNotAssigned.BackColor = DefaultBackColor;
                    buttonNotAssigned.ForeColor = DefaultForeColor;
                    string queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee ";

                    queryString += " where (Lower(FirstName) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%') " +
                        "            OR Lower(Surname) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%'))" +
                        "            AND ISBLOCKED = 0 ";
                    if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EMPLOYEE.EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                            {
                                queryString += " AND (Permission = 'Employee' OR EMPLOYEE.EmployeeID = @userID)";
                            }
                            else
                            {
                                queryString += " AND Permission != 'Administrator'";
                            }
                        }
                    }
                    else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                    }
                    else if(comboBoxDepartment.Text.ToString() == "All")
                    {
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EMPLOYEE.EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                            {
                                queryString += " OR Permission IS NULL";
                            }
                        }
                    }

                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();
                   
                    foreach(DataRow dataRow in dataTable.Rows)
                    {
                        if(dataRow["Department"] == DBNull.Value)
                        {
                            dataRow["Department"] = "Not assigned";
                        }
                        if(dataRow["Permission"] == DBNull.Value)
                        {
                            dataRow["Permission"] = "Not assigned";
                        }
                    }

                }
                else if (select == 2)
                {
                    buttonAssigned.BackColor = Color.CornflowerBlue;
                    buttonAssigned.ForeColor = Color.White;
                    buttonAll.BackColor = DefaultBackColor;
                    buttonAll.ForeColor = DefaultForeColor;
                    buttonNotAssigned.BackColor = DefaultBackColor;
                    buttonNotAssigned.ForeColor = DefaultForeColor;
                    string queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee " +
                        "                           INNER JOIN ASSIGNED_TASK " +
                        "                           ON Employee.EmployeeID = ASSIGNED_TASK.EmployeeID ";

                    queryString += " where (Lower(FirstName) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%') " +
                        "            OR Lower(Surname) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%'))" +
                        "            AND TaskID = @taskID";

                    if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                            {
                                queryString += " AND Permission != 'Administrator' AND (Permission != 'Manager' OR EMPLOYEE.EmployeeID = @userID)";
                            }
                            else
                            {
                                queryString += " AND Permission != 'Administrator'";
                            }
                        }
                    }
                    else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                    }
                    else if (comboBoxDepartment.Text.ToString() == "All")
                    {
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EMPLOYEE.EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                            {
                                queryString += " OR Permission IS NULL";
                            }
                        }
                    }

                    cmd = new SqlCommand(queryString, con);                   
                    cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                    
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (keyValuePairs.ContainsKey((int)dataRow["EmployeeID"]))
                        {
                            if (keyValuePairs[(int)dataRow["EmployeeID"]] == false)
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
                            queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee ";

                            queryString += " WHERE NOT EXISTS(SELECT NULL FROM ASSIGNED_TASK " +
                                "            WHERE Employee.EmployeeID = ASSIGNED_TASK.EmployeeID " +
                                "            AND TaskID = @taskID) " +
                                "            AND (Lower(FirstName) LIKE " +
                                "            CONCAT('%', Lower(@searchEmp), '%') " +
                                "            OR Lower(Surname) LIKE " +
                                "            CONCAT('%', Lower(@searchEmp), '%'))" +
                                "            AND ISBLOCKED = 0 ";

                            if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                            {
                                queryString += " AND Department = @department";
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                    {
                                        queryString += " AND EmployeeID = @userID";
                                    }
                                    else
                                    {
                                        queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                    }
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                                    {
                                        queryString += " AND Permission != 'Administrator' AND (Permission != 'Manager' OR EMPLOYEE.EmployeeID = @userID)";
                                    }
                                    else
                                    {
                                        queryString += " AND Permission != 'Administrator'";
                                    }
                                }
                            }
                            else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                            {
                                queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                            }
                            else if (comboBoxDepartment.Text.ToString() == "All")
                            {
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                    {
                                        queryString += " AND EMPLOYEE.EmployeeID = @userID";
                                    }
                                    else
                                    {
                                        queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                    }
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    queryString += " AND Permission != 'Administrator'";
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                                    {
                                        queryString += " OR Permission IS NULL";
                                    }
                                }
                            }

                            cmd = new SqlCommand(queryString, con);
                            cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                            cmd.Parameters.AddWithValue("@employeeID", keyValuePair.Key);
                            cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                            cmd.Parameters.AddWithValue("@taskID", taskID);
                            cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
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

                    foreach (DataGridViewRow dataGridViewRow in dataEmp.Rows)
                    {
                        dataGridViewRow.Cells["SelectEmp"].Value = true;
                    }
                }
                else if (select == 3)
                {
                    buttonNotAssigned.BackColor = Color.CornflowerBlue;
                    buttonNotAssigned.ForeColor = Color.White;
                    buttonAll.BackColor = DefaultBackColor;
                    buttonAll.ForeColor = DefaultForeColor;
                    buttonAssigned.ForeColor = DefaultForeColor;
                    buttonAssigned.BackColor = DefaultBackColor;
                    string queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee ";

                    queryString += " WHERE NOT EXISTS(SELECT NULL FROM ASSIGNED_TASK " +
                        "            WHERE Employee.EmployeeID = ASSIGNED_TASK.EmployeeID " +
                        "            AND TaskID = @taskID) " +
                        "            AND (Lower(FirstName) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%') " +
                        "            OR Lower(Surname) LIKE " +
                        "            CONCAT('%', Lower(@searchEmp), '%'))" +
                        "            AND ISBLOCKED = 0 ";

                    if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                            {
                                queryString += " AND Permission != 'Administrator' AND (Permission != 'Manager' OR EMPLOYEE.EmployeeID = @userID)";
                            }
                            else
                            {
                                queryString += " AND Permission != 'Administrator'";
                            }
                        }
                    }
                    else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                    }
                    else if (comboBoxDepartment.Text.ToString() == "All")
                    {
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EMPLOYEE.EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                            {
                                queryString += " OR Permission IS NULL";
                            }
                        }
                    }

                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                    cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                    cmd.Parameters.AddWithValue("@taskID", taskID);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (keyValuePairs.ContainsKey((int)dataRow["EmployeeID"]))
                        {
                            if (keyValuePairs[(int)dataRow["EmployeeID"]] == true)
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
                            queryString = "Select Surname, FirstName, Department, Permission, EMPLOYEE.EmployeeID from employee ";

                            queryString += " INNER JOIN ASSIGNED_TASK " +
                                "            ON Employee.EmployeeID = ASSIGNED_TASK.EmployeeID " +
                                "            where (Lower(FirstName) LIKE " +
                                "            CONCAT('%', Lower(@searchEmp), '%') " +
                                "            OR Lower(Surname) LIKE " +
                                "            CONCAT('%', Lower(@searchEmp), '%'))" +
                                "            AND TaskID = @taskID" +
                                "            AND ISBLOCKED = 0 ";


                            if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                            {
                                queryString += " AND Department = @department";
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                    {
                                        queryString += " AND EmployeeID = @userID";
                                    }
                                    else
                                    {
                                        queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                    }
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                                    {
                                        queryString += " AND Permission != 'Administrator' AND (Permission != 'Manager' OR EMPLOYEE.EmployeeID = @userID)";
                                    }
                                    else
                                    {
                                        queryString += " AND Permission != 'Administrator'";
                                    }
                                }
                            }
                            else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                            {
                                queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                            }
                            else if (comboBoxDepartment.Text.ToString() == "All")
                            {
                                queryString += " AND DEPARTMENT IS NOT NULL";
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                    {
                                        queryString += " AND EMPLOYEE.EmployeeID = @userID";
                                    }
                                    else
                                    {
                                        queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                    }
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    queryString += " AND Permission != 'Administrator'";
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                                    {
                                        queryString += " OR Permission IS NULL";
                                    }
                                }
                            }

                            cmd = new SqlCommand(queryString, con);
                            cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                            cmd.Parameters.AddWithValue("@employeeID", keyValuePair.Key);
                            cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                            cmd.Parameters.AddWithValue("@taskID", taskID);
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

                    foreach (DataGridViewRow dataGridViewRow in dataEmp.Rows)
                    {
                        dataGridViewRow.Cells["SelectEmp"].Value = false;
                    }
                }

                dataEmp.ReadOnly = true;
                dataEmp.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getEmployeesProject()
        {
            try
            {
                SqlCommand cmd = null;
                SqlConnection con = new SqlConnection(connString);
                DataTable dataTable = new DataTable();

                if (select == 1)
                {
                    buttonAll.BackColor = Color.CornflowerBlue;
                    buttonAll.ForeColor = Color.White;
                    buttonAssigned.BackColor = DefaultBackColor;
                    buttonAssigned.ForeColor = DefaultForeColor;
                    buttonNotAssigned.BackColor = DefaultBackColor;
                    buttonNotAssigned.ForeColor = DefaultForeColor;
                    string queryString = "Select Surname, FirstName, Department, Permission, EmployeeID from employee " +
                        "                           where (Lower(FirstName) LIKE " +
                        "                           CONCAT('%', Lower(@searchEmp), '%') " +
                        "                           OR Lower(Surname) LIKE " +
                        "                           CONCAT('%', Lower(@searchEmp), '%'))" +
                        "                           AND ISBLOCKED = 0";
                    if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                            {
                                queryString += " AND (Permission = 'Employee' OR EMPLOYEE.EmployeeID = @userID)";
                            }
                            else
                            {
                                queryString += " AND Permission != 'Administrator'";
                            }
                        }
                    }
                    else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                    }
                    else if(comboBoxDepartment.Text.ToString() == "All")
                    {
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                            {
                                queryString += " OR Permission IS NULL";
                            }
                        }
                    }

                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (dataRow["Department"] == DBNull.Value)
                        {
                            dataRow["Department"] = "Not assigned";
                        }
                        if (dataRow["Permission"] == DBNull.Value)
                        {
                            dataRow["Permission"] = "Not assigned";
                        }
                    }


                }
                else if (select == 2)
                {
                    buttonAssigned.BackColor = Color.CornflowerBlue;
                    buttonAssigned.ForeColor = Color.White;
                    buttonAll.BackColor = DefaultBackColor;
                    buttonAll.ForeColor = DefaultForeColor;
                    buttonNotAssigned.BackColor = DefaultBackColor;
                    buttonNotAssigned.ForeColor = DefaultForeColor;
                    string queryString = "Select Surname, FirstName, Department, Permission, Employee.EmployeeID from employee " +
                        "                           INNER JOIN ASSIGNED_PROJECT " +
                        "                           ON Employee.EmployeeID = ASSIGNED_PROJECT.EmployeeID " +
                        "                           where (Lower(FirstName) LIKE " +
                        "                           CONCAT('%', Lower(@searchEmp), '%') " +
                        "                           OR Lower(Surname) LIKE " +
                        "                           CONCAT('%', Lower(@searchEmp), '%'))" +
                        "                           AND ProjectID = @projectID" +
                        "                           AND ISBLOCKED = 0";

                    if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                            {
                                queryString += " AND (Permission = 'Employee' OR EMPLOYEE.EmployeeID = @userID)";
                            }
                            else
                            {
                                queryString += " AND Permission != 'Administrator'";
                            }
                        }
                    }
                    else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                    }
                    else if (comboBoxDepartment.Text.ToString() == "All")
                    {
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
                            {
                                queryString += " OR Permission IS NULL";
                            }
                        }
                    }

                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (keyValuePairs.ContainsKey((int)dataRow["EmployeeID"]))
                        {
                            if (keyValuePairs[(int)dataRow["EmployeeID"]] == false)
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
                            queryString = "Select Surname, FirstName, Department, Permission, Employee.EmployeeID from employee " +
                                "                           WHERE NOT EXISTS(SELECT NULL FROM ASSIGNED_PROJECT " +
                                "                           WHERE Employee.EmployeeID = ASSIGNED_PROJECT.EmployeeID " +
                                "                           AND ProjectID = @projectID) " +
                                "                           AND (Lower(FirstName) LIKE " +
                                "                           CONCAT('%', Lower(@searchEmp), '%') " +
                                "                           OR Lower(Surname) LIKE " +
                                "                           CONCAT('%', Lower(@searchEmp), '%'))" +
                                "                           AND ISBLOCKED = 0";

                            if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                            {
                                queryString += " AND Department = @department";
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                    {
                                        queryString += " AND EmployeeID = @userID";
                                    }
                                    else
                                    {
                                        queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                    }
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                                    {
                                        queryString += " AND (Permission = 'Employee' OR EMPLOYEE.EmployeeID = @userID)";
                                    }
                                    else
                                    {
                                        queryString += " AND Permission != 'Administrator'";
                                    }
                                }
                            }
                            else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                            {
                                queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                            }
                            else if (comboBoxDepartment.Text.ToString() == "All")
                            {
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                    {
                                        queryString += " AND EmployeeID = @userID";
                                    }
                                    else
                                    {
                                        queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                    }
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    queryString += " AND Permission != 'Administrator'";
                                }
                            }

                            cmd = new SqlCommand(queryString, con);
                            cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                            cmd.Parameters.AddWithValue("@employeeID", keyValuePair.Key);
                            cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                            cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                            cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
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

                    foreach (DataGridViewRow dataGridViewRow in dataEmp.Rows)
                    {
                        dataGridViewRow.Cells["SelectEmp"].Value = true;
                    }
                }
                else if (select == 3)
                {
                    buttonNotAssigned.BackColor = Color.CornflowerBlue;
                    buttonNotAssigned.ForeColor = Color.White;
                    buttonAll.BackColor = DefaultBackColor;
                    buttonAll.ForeColor = DefaultForeColor;
                    buttonAssigned.ForeColor = DefaultForeColor;
                    buttonAssigned.BackColor = DefaultBackColor;
                    string queryString = "Select Surname, FirstName, Department, Permission, Employee.EmployeeID from employee " +
                        "                           WHERE NOT EXISTS(SELECT NULL FROM ASSIGNED_PROJECT " +
                        "                           WHERE Employee.EmployeeID = ASSIGNED_PROJECT.EmployeeID " +
                        "                           AND ProjectID = @projectID) " +
                        "                           AND (Lower(FirstName) LIKE " +
                        "                           CONCAT('%', Lower(@searchEmp), '%') " +
                        "                           OR Lower(Surname) LIKE " +
                        "                           CONCAT('%', Lower(@searchEmp), '%'))" +
                        "                           AND ISBLOCKED = 0";

                    if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                    {
                        queryString += " AND Department = @department";
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                            {
                                queryString += " AND (Permission = 'Employee' OR EMPLOYEE.EmployeeID = @userID)";
                            }
                            else
                            {
                                queryString += " AND Permission != 'Administrator'";
                            }
                        }
                    }
                    else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                    {
                        queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                    }
                    else if (comboBoxDepartment.Text.ToString() == "All")
                    {
                        if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                        {
                            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                            {
                                queryString += " AND EmployeeID = @userID";
                            }
                            else
                            {
                                queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                            }
                        }
                        else if (comboBoxPermission.Text.ToString() == "Not assigned")
                        {
                            queryString += " AND Permission IS NULL";
                        }
                        else
                        {
                            queryString += " AND Permission != 'Administrator'";
                        }
                    }

                    cmd = new SqlCommand(queryString, con);
                    cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                    cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                    cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                    con.Close();
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        if (keyValuePairs.ContainsKey((int)dataRow["EmployeeID"]))
                        {
                            if (keyValuePairs[(int)dataRow["EmployeeID"]] == true)
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
                            queryString = "Select Surname, FirstName, Department, Permission, Employee.EmployeeID from employee " +
                                "                           INNER JOIN ASSIGNED_PROJECT " +
                                "                           ON Employee.EmployeeID = ASSIGNED_PROJECT.EmployeeID " +
                                "                           where (Lower(FirstName) LIKE " +
                                "                           CONCAT('%', Lower(@searchEmp), '%') " +
                                "                           OR Lower(Surname) LIKE " +
                                "                           CONCAT('%', Lower(@searchEmp), '%'))" +
                                "                           AND TaskID = @taskID" +
                                "                           AND ISBLOCKED = 0";


                            if (comboBoxDepartment.Text.ToString() != "All" && comboBoxDepartment.Text.ToString() != "Not assigned")
                            {
                                queryString += " AND Department = @department";
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                    {
                                        queryString += " AND EmployeeID = @userID";
                                    }
                                    else
                                    {
                                        queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                    }
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
                                    {
                                        queryString += " AND (Permission = 'Employee' OR EMPLOYEE.EmployeeID = @userID)";
                                    }
                                    else
                                    {
                                        queryString += " AND Permission != 'Administrator'";
                                    }
                                }
                            }
                            else if (comboBoxDepartment.Text.ToString() == "Not assigned")
                            {
                                queryString += " AND DEPARTMENT IS NULL AND (Permission != 'Administrator' OR Permission IS NULL)";
                            }
                            else if (comboBoxDepartment.Text.ToString() == "All")
                            {
                                if (comboBoxPermission.Text.ToString() != "All" && comboBoxPermission.Text.ToString() != "Not assigned")
                                {
                                    if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager" && comboBoxPermission.Text.ToString() == "Manager")
                                    {
                                        queryString += " AND EmployeeID = @userID";
                                    }
                                    else
                                    {
                                        queryString += " AND (Permission = @permission AND Permission != 'Administrator')";
                                    }
                                }
                                else if (comboBoxPermission.Text.ToString() == "Not assigned")
                                {
                                    queryString += " AND Permission IS NULL";
                                }
                                else
                                {
                                    queryString += " AND Permission != 'Administrator'";
                                }
                            }

                            cmd = new SqlCommand(queryString, con);
                            cmd.Parameters.AddWithValue("@searchEmp", textboxSearch.Text);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            cmd.Parameters.AddWithValue("@permission", comboBoxPermission.Text.ToString());
                            cmd.Parameters.AddWithValue("@employeeID", keyValuePair.Key);
                            cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text.ToString());
                            cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
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

                    foreach (DataGridViewRow dataGridViewRow in dataEmp.Rows)
                    {
                        dataGridViewRow.Cells["SelectEmp"].Value = false;
                    }
                }

                dataEmp.ReadOnly = true;
                dataEmp.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getProject(string projectName)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select ProjectLeader, ProjectID, Department, ProjectStatus FROM PROJECT " +
                    "                           WHERE ProjectName = @projectName" +
                    "                           AND ProjectStatus != 'Accepted'", con);
                cmd.Parameters.AddWithValue("@projectName", projectName);
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

        private void getProjectByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select ProjectLeader, ProjectName, Department FROM PROJECT " +
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

        public AssignEmployee(int taskID, int userID)
        {
            //assign emp to task
            InitializeComponent();
            this.taskID = taskID;
            this.userID = userID;
            select = 1;
            dataTableUser = GetData.getUserData(connString, userID);
            keyValuePairs = new Dictionary<int, bool>();

            dataSourcePositionAll = new List<string>();
            dataSourcePositionAll.Add("All");
            dataSourcePositionAll.Add("Employee");
            dataSourcePositionAll.Add("Manager");
            dataSourcePositionAll.Add("Not assigned");

            dataSourcePosition = new List<string>();
            dataSourcePosition.Add("All");
            dataSourcePosition.Add("Employee");
            dataSourcePosition.Add("Manager");

            comboBoxPermission.DataSource = dataSourcePositionAll;

            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
            {
                comboBoxDepartment.Text = dataTableUser.Rows[0]["Department"].ToString();
                comboBoxDepartment.Enabled = false;
            }
            else
            {
                getListDept();
                comboBoxDepartment.DataSource = dataSourceDept;
            }
            isInitialized = true;
            getEmployeesTask();
        }

        public AssignEmployee(int projectID, int userID, bool isLeaderSelect)
        {
            //assign project leader
            InitializeComponent();
            this.projectID = projectID;
            this.userID = userID;
            this.isLeaderSelect = isLeaderSelect;
            dataTableUser = GetData.getUserData(connString, userID);
            keyValuePairs = new Dictionary<int, bool>();
            dataTableProject = GetData.getProjectByID(connString, projectID);

            dataSourcePositionAll = new List<string>();
            dataSourcePositionAll.Add("All");
            dataSourcePositionAll.Add("Employee");
            dataSourcePositionAll.Add("Manager");
            if(dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
            {
                dataSourcePositionAll.Add("Not assigned");
            }
            
            dataSourcePosition = new List<string>();
            dataSourcePosition.Add("All");
            dataSourcePosition.Add("Employee");
            dataSourcePosition.Add("Manager");

            comboBoxPermission.DataSource = dataSourcePositionAll;

            buttonAll.Enabled = false;
            buttonAll.Visible = false;
            buttonAssigned.Enabled = false;
            buttonAssigned.Visible = false;
            buttonNotAssigned.Enabled = false;
            buttonNotAssigned.Visible = false;
            select = 1;

            this.Text = "Assign Project Leader";

            if (dataTableProject.Rows[0]["Department"] != DBNull.Value)
            {
                comboBoxDepartment.Enabled = false;
                comboBoxDepartment.Text = dataTableProject.Rows[0]["Department"].ToString();
                comboBoxDepartment.Text = dataTableProject.Rows[0]["Department"].ToString();
            }
            else
            {
                getListDept();
                comboBoxDepartment.DataSource = dataSourceDept;
            }
            isInitialized = true;
            getEmployeesTask();
        }

        public AssignEmployee(string projectName, int userID)
        {
            //assign to project
            InitializeComponent();
            this.projectName = projectName;
            dataTableUser = GetData.getUserData(connString, userID);
            keyValuePairs = new Dictionary<int, bool>();
            getProject(projectName);

            dataSourcePositionAll = new List<string>();
            dataSourcePositionAll.Add("All");
            dataSourcePositionAll.Add("Employee");
            dataSourcePositionAll.Add("Manager");
            if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
            {
                dataSourcePositionAll.Add("Not assigned");
            }

            dataSourcePosition = new List<string>();
            dataSourcePosition.Add("All");
            dataSourcePosition.Add("Employee");
            dataSourcePosition.Add("Manager");

            comboBoxPermission.DataSource = dataSourcePositionAll;

            select = 1;

            this.Text = "Assign employee(-s) to project";

            if (dataTableProject.Rows[0]["Department"] != DBNull.Value)
            {
                comboBoxDepartment.Text = dataTableProject.Rows[0]["Department"].ToString();
            }
            else
            {
                getListDept();
                comboBoxDepartment.DataSource = dataSourceDept;
            }
            isInitialized = true;
            getEmployeesProject();
        }

        public AssignEmployee(int taskID, int userID, string projectName)
        {
            //assign emp to task in project
            InitializeComponent();
            this.taskID = taskID;
            this.userID = userID;
            this.projectName = projectName;
            isProjectTaskAssign = true;
            dataEmp.RowHeadersVisible = false;
            select = 1;
            dataTableUser = GetData.getUserData(connString, userID);
            keyValuePairs = new Dictionary<int, bool>();
            getProject(projectName);
            dataSourcePosition = new List<string>();

            dataSourcePositionAll = new List<string>();
            dataSourcePositionAll.Add("All");
            dataSourcePositionAll.Add("Employee");
            dataSourcePositionAll.Add("Manager");
            if (dataTableUser.Rows[0]["Permission"].ToString() == "Administrator")
            {
                dataSourcePositionAll.Add("Not assigned");
            }

            dataSourcePosition = new List<string>();
            dataSourcePosition.Add("All");
            dataSourcePosition.Add("Employee");
            dataSourcePosition.Add("Manager");

            comboBoxPermission.DataSource = dataSourcePositionAll;

            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
            {
                comboBoxDepartment.Text = dataTableUser.Rows[0]["Department"].ToString();
                comboBoxDepartment.Enabled = false;
            }
            else
            {
                getListDept();
                comboBoxDepartment.DataSource = dataSourceDept;
            }
            isInitialized = true;
            getEmployeesProjectTask();
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

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if(isLeaderSelect)
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd = null;
                    int empID = 0;
                    int count = 0;
                    foreach (DataGridViewRow dataGridViewRow in dataEmp.Rows)
                    {
                        if ((bool)dataGridViewRow.Cells["SelectEmp"].Value == true)
                        {
                            empID = (int)dataGridViewRow.Cells["EmployeeID"].Value;
                            break;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    DataTable dataTable = null;
                    if (count >= dataEmp.Rows.Count)
                    {
                        cmd = new SqlCommand("UPDATE PROJECT SET ProjectLeader = NULL WHERE ProjectID = @projectID", con);
                        cmd.Parameters.AddWithValue("@projectID", projectID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT PESEL FROM EMPLOYEE WHERE EMPLOYEEID = @empID", con);
                        cmd.Parameters.AddWithValue("@empID", empID);
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        con.Close();

                        cmd = new SqlCommand("INSERT INTO ASSIGNED_PROJECT(ProjectID, EmployeeID)" +
                            "               VALUES(@projectID, @employeeID)", con);
                        cmd.Parameters.AddWithValue("@projectID", projectID);
                        cmd.Parameters.AddWithValue("@employeeID", empID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        cmd = new SqlCommand("SELECT ProjectStatus FROM PROJECT WHERE ProjectID = @projectID", con);
                        cmd.Parameters.AddWithValue("@projectID", projectID);
                        con.Open();
                        adapter = new SqlDataAdapter(cmd);
                        DataTable dataTableStatus = new DataTable();
                        adapter.Fill(dataTableStatus);
                        con.Close();

                        if (dataTableStatus.Rows[0]["ProjectStatus"].ToString() == "Pending")
                        {
                            cmd = new SqlCommand("UPDATE PROJECT SET ProjectStatus = 'Active' WHERE ProjectID = @projectID", con);
                            cmd.Parameters.AddWithValue("@projectID", projectID);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                        cmd = new SqlCommand("UPDATE PROJECT SET ProjectLeader = @projectLeader " +
                        "               WHERE ProjectName = @projectName" +
                        "               AND ProjectStatus != 'Accepted'", con);
                        cmd.Parameters.AddWithValue("@projectName", dataTableProject.Rows[0]["ProjectName"].ToString());
                        if (dataTable.Rows[0]["PESEL"] != DBNull.Value)
                        {
                            cmd.Parameters.AddWithValue("@projectLeader", dataTable.Rows[0]["PESEL"].ToString());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@projectLeader", DBNull.Value);
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        
                        

                        MessageBox.Show("Successfulyl assigned new project leader.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
  
                }
                else if (projectName != null && isProjectTaskAssign == false)
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd;
                    cmd = new SqlCommand("SELECT COUNT(*) FROM ASSIGNED_PROJECT", con);
                    con.Open();
                    count1 = (Int32)cmd.ExecuteScalar();
                    con.Close();

                    cmd = new SqlCommand("Select * FROM EMPLOYEE", con);
                    int countTemp = 0;
                    foreach (KeyValuePair<int, bool> keyValuePair in keyValuePairs)
                    {
                        if (keyValuePair.Value == true)
                        {
                            Int32 count;
                            cmd = new SqlCommand("Select COUNT(*) FROM ASSIGNED_PROJECT WHERE ProjectID = @projectID", con);
                            cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                            con.Open();
                            count = (Int32)cmd.ExecuteScalar();
                            con.Close();
                            cmd = new SqlCommand("Insert INTO ASSIGNED_PROJECT(ProjectID, EmployeeID)" +
                                "                   VALUES(@projectID, @employeeID)", con);
                            cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                            cmd.Parameters.AddWithValue("employeeID", keyValuePair.Key);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            
                            if (count == 0 && dataTableProject.Rows[0]["ProjectStatus"].ToString() == "Pending")
                            {
                                cmd = new SqlCommand("Update PROJECT SET ProjectStatus = 'Active' WHERE ProjectID = @projectID", con);
                                cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            cmd = new SqlCommand("UPDATE EMPLOYEE SET NewProject = 1 WHERE EMPLOYEEID = @employeeID", con);
                            cmd.Parameters.AddWithValue("employeeID", keyValuePair.Key);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            countTemp++;
                        }
                        else
                        {
                            cmd = new SqlCommand("DELETE FROM ASSIGNED_PROJECT" +
                                "                   WHERE ProjectID = @projectID" +
                                "                   AND EmployeeID = @employeeID", con);
                            cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                            cmd.Parameters.AddWithValue("employeeID", keyValuePair.Key);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            countTemp--;
                        }
                    }
                    cmd = new SqlCommand("Select COUNT(*) FROM ASSIGNED_PROJECT WHERE ProjectID = @projectID", con); ;
                    con.Open();
                    count2 = (Int32)cmd.ExecuteScalar();
                    con.Close();

                    if (count1 + countTemp == count2)
                    {
                        string message = "Successuly assigned employee(s) to the project.";
                        string title = "Success";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string message = "Something went wrong.";
                        string title = "Failure";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SqlConnection con = new SqlConnection(connString);
                    SqlCommand cmd;
                    cmd = new SqlCommand("SELECT COUNT(*) FROM assigned_task", con);
                    con.Open();
                    count1 = (Int32)cmd.ExecuteScalar();
                    con.Close();

                    cmd = new SqlCommand("Select * FROM EMPLOYEE", con);
                    int countTemp = 0;
                    foreach (KeyValuePair<int, bool> keyValuePair in keyValuePairs)
                    {
                        if (keyValuePair.Value == true)
                        {
                            Int32 count;
                            cmd = new SqlCommand("Select COUNT(*) FROM ASSIGNED_TASK WHERE TaskID = @taskID", con);
                            cmd.Parameters.AddWithValue("@taskID", taskID);
                            con.Open();
                            count = (Int32)cmd.ExecuteScalar();
                            con.Close();
                            cmd = new SqlCommand("Insert INTO ASSIGNED_TASK(TaskID, EmployeeID)" +
                                "                   VALUES(@taskID, @employeeID)", con);
                            cmd.Parameters.AddWithValue("@taskID", taskID);
                            cmd.Parameters.AddWithValue("employeeID", keyValuePair.Key);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            cmd = new SqlCommand("SELECT TaskStatus FROM TASK WHERE TaskID = @taskID", con);
                            cmd.Parameters.AddWithValue("@taskID", taskID);
                            con.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable dataTableTask = new DataTable();
                            adapter.Fill(dataTableTask);
                            con.Close();

                            if (count == 0 && dataTableTask.Rows[0]["TaskStatus"].ToString() == "Pending")
                            {
                                cmd = new SqlCommand("Update TASK SET TaskStatus = 'Active' WHERE TaskID = @taskID", con);
                                cmd.Parameters.AddWithValue("@taskID", taskID);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                            cmd = new SqlCommand("UPDATE EMPLOYEE SET NewTask = 1 WHERE EMPLOYEEID = @employeeID", con);
                            cmd.Parameters.AddWithValue("employeeID", keyValuePair.Key);
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
                            cmd.Parameters.AddWithValue("@taskID", taskID);
                            cmd.Parameters.AddWithValue("employeeID", keyValuePair.Key);
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
                        string message = "Successuly assigned employee(s) to the task.";
                        string title = "Success";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string message = "Something went wrong.";
                        string title = "Failure";
                        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void dataEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = this.dataEmp.Columns[e.ColumnIndex].Name;
            int count = 0;
            
            if (Convert.ToBoolean(dataEmp.Rows[e.RowIndex].Cells["SelectEmp"].EditedFormattedValue) == false && e.RowIndex >= 0 && columnName == "SelectEmp")
            {
                if (isLeaderSelect)
                {
                    foreach (DataGridViewRow dataGridViewRow in dataEmp.Rows)
                    {
                        if (Convert.ToBoolean(dataGridViewRow.Cells["SelectEmp"].EditedFormattedValue) == true)
                        {
                            count++;
                            if(count != 0)
                            {
                                MessageBox.Show("You can only choose one project leader.", "Project Leader", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                dataEmp.Rows[e.RowIndex].Cells["SelectEmp"].Value = true;
                keyValuePairs[(int)dataEmp.Rows[e.RowIndex].Cells["EmployeeID"].Value] = (bool)dataEmp.Rows[e.RowIndex].Cells["SelectEmp"].Value;
                timerRefresh_Tick(sender, e);
            }
            else if (Convert.ToBoolean(dataEmp.Rows[e.RowIndex].Cells["SelectEmp"].EditedFormattedValue) == true && e.RowIndex >= 0 && columnName == "SelectEmp")
            {
                try
                {
                    SqlConnection con = new SqlConnection(connString);
                    if(projectName == null)
                    {
                        SqlCommand cmd = new SqlCommand("Select * FROM TASK WHERE TaskID = @taskID", con);
                        cmd.Parameters.AddWithValue("@taskID", taskID);
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        con.Close();

                        if (dataTable.Rows[0]["TaskStatus"].ToString() == "Pending" || dataTable.Rows[0]["TaskStatus"].ToString() == "Active")
                        {
                            dataEmp.Rows[e.RowIndex].Cells["SelectEmp"].Value = false;
                            keyValuePairs[(int)dataEmp.Rows[e.RowIndex].Cells["EmployeeID"].Value] = (bool)dataEmp.Rows[e.RowIndex].Cells["SelectEmp"].Value;
                        }
                        else
                        {
                            MessageBox.Show("You cannot remove employees that were part of task that is either completed of is being fixed.", "Cannot remove",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("Select * FROM PROJECT WHERE ProjectID = @projectID", con);
                        cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        con.Close();

                        if (dataTable.Rows[0]["ProjectStatus"].ToString() == "Pending" || dataTable.Rows[0]["ProjectStatus"].ToString() == "Active")
                        {
                            dataEmp.Rows[e.RowIndex].Cells["SelectEmp"].Value = false;
                            keyValuePairs[(int)dataEmp.Rows[e.RowIndex].Cells["EmployeeID"].Value] = (bool)dataEmp.Rows[e.RowIndex].Cells["SelectEmp"].Value;
                        }
                        else
                        {
                            MessageBox.Show("You cannot remove employees that were part of project that is either completed of is being fixed.", "Cannot remove",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                timerRefresh_Tick(sender, e);
            }
        }

        private void buttonSubmitClose_Click(object sender, EventArgs e)
        {
            buttonAssign_Click(sender, e);
            this.Close();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (isInitialized)
            {
                if (isProjectTaskAssign)
                {
                    getEmployeesProjectTask();
                }
                else if (projectName != null)
                {
                    getEmployeesProject();
                }
                else
                {
                    getEmployeesTask();
                }
            }
        }

        private void comboBoxDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBoxDepartment.Text == "Not assigned")
            {
                comboBoxPermission.Text = "Not assigned";
                comboBoxPermission.Enabled = false;
            }
            else if(comboBoxDepartment.Text == "All")
            {
                comboBoxPermission.DataSource = dataSourcePositionAll;
                comboBoxPermission.SelectedIndex = 0;
            }
            else
            {
                comboBoxPermission.DataSource = dataSourcePosition;
                comboBoxPermission.SelectedIndex = 0;
            }
            if (comboBoxDepartment.Text != "Not assigned" && comboBoxPermission.Enabled == false)
            {
                comboBoxPermission.Text = "All";
                comboBoxPermission.Enabled = true;
            }
            timerRefresh_Tick(sender, e);
        }

        private void dataEmp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmd;
                if(dataEmp.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dataRow in dataEmp.Rows)
                    {
                        if (dataRow.Cells["Department"].Value == null)
                        {
                            dataRow.Cells["Department"].Value = "Not assigned";
                        }
                        if (dataRow.Cells["Position"].Value == null)
                        {
                            dataRow.Cells["Position"].Value = "Not assigned";
                        }
                        if (keyValuePairs.ContainsKey((int)dataRow.Cells["EmployeeID"].Value))
                        {
                            dataRow.Cells["SelectEmp"].Value = keyValuePairs[(int)dataRow.Cells["EmployeeID"].Value];
                        }
                        else
                        {
                            if (isProjectTaskAssign)
                            {
                                cmd = new SqlCommand("SELECT COUNT(*) FROM ASSIGNED_TASK WHERE TaskID = @taskID AND EmployeeID = @employeeID", con);
                                cmd.Parameters.AddWithValue("@taskID", taskID);
                            }
                            else if (projectName != null)
                            {
                                cmd = new SqlCommand("SELECT COUNT(*) FROM ASSIGNED_PROJECT WHERE ProjectID = @projectID AND EmployeeID = @employeeID", con);
                                cmd.Parameters.AddWithValue("@projectID", (int)dataTableProject.Rows[0]["ProjectID"]);
                            }
                            else
                            {
                                cmd = new SqlCommand("SELECT COUNT(*) FROM ASSIGNED_TASK WHERE TaskID = @taskID AND EmployeeID = @employeeID", con);
                                cmd.Parameters.AddWithValue("@taskID", taskID);
                            }
                            cmd.Parameters.AddWithValue("@employeeID", (int)dataRow.Cells["EmployeeID"].Value);
                            con.Open();
                            Int32 checkBox = (Int32)cmd.ExecuteScalar();
                            con.Close();
                            if (checkBox > 0)
                            {

                                dataRow.Cells["SelectEmp"].Value = true;
                            }
                            else
                            {
                                dataRow.Cells["SelectEmp"].Value = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
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
    }
}
