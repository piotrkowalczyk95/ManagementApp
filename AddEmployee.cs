using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using ExtensionMethods;
using System.Net.Mail;

namespace ManagementApp
{
    public partial class AddEmployee : Form
    {
        string connString = @"Data Source=PITER;Initial Catalog = ManagementApp; 
                            Integrated Security = True; Connect Timeout = 30; 
                            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                            MultiSubnetFailover=False";
        private Int32 count1, count2;
        private string dateCheck;
        private int userID;
        private int employeeID = -1;
        DataTable dataTableUser;

        public AddEmployee(int userID)
        {
            InitializeComponent();
            datetimeBirth.Value = DateTime.Now;
            this.userID = userID;
            dataTableUser = ExtensionMethods.GetData.getUserData(connString, userID);
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            cmd = new SqlCommand("SELECT COUNT(*) FROM employee", con);
            con.Open();
            count1 = (Int32)cmd.ExecuteScalar();
            con.Close();
            comboBoxPermission.SelectedItem = "Employee";

            if(dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
            {
                List<string> dataSource = new List<string>();
                dataSource.Add("None");
                dataSource.Add(dataTableUser.Rows[0]["Department"].ToString());
                comboBoxDepartment.DataSource = dataSource;
                comboBoxDepartment.SelectedItem = "None";
                comboBoxPermission.SelectedItem = "Employee";
                comboBoxPermission.Enabled = false;
            }
            else
            {
                cmd = new SqlCommand("Select DISTINCT DepartmentName FROM DEPARTMENT", con);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapt.Fill(dataTable);
                con.Close();
                List<string> department = new List<string>();
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        department.Add(dataRow["DepartmentName"].ToString());
                    }
                }
                department.Add("None");
                comboBoxDepartment.DataSource = department;
                comboBoxDepartment.SelectedItem = "None";
                comboBoxPermission.Enabled = false;
            }
        }

        public AddEmployee(int userID, int employeeID)
        {
            InitializeComponent();
            datetimeBirth.Value = DateTime.Now;
            this.Text = "Edit Employee";
            this.employeeID = employeeID;
            this.userID = userID;
            dataTableUser = ExtensionMethods.GetData.getUserData(connString, userID);
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("Select * FROM EMPLOYEE WHERE EmployeeID = @employeeID", con);
            cmd.Parameters.AddWithValue("@employeeID", employeeID);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapt.Fill(dataTable);
            SqlCommand cmdDept = new SqlCommand("Select DepartmentName FROM DEPARTMENT", con);
            SqlDataAdapter adaptDept = new SqlDataAdapter(cmdDept);
            DataTable dataTableDept = new DataTable();
            adaptDept.Fill(dataTableDept);
            con.Close();

            if (dataTableUser.Rows[0]["Permission"].ToString() == "Manager")
            {
                List<string> dataSource = new List<string>();
                dataSource.Add("None");
                dataSource.Add(dataTableUser.Rows[0]["Department"].ToString());
                comboBoxDepartment.DataSource = dataSource;
                comboBoxPermission.Enabled = false;

            }
            else
            {
                cmd = new SqlCommand("Select DISTINCT DepartmentName FROM DEPARTMENT", con);
                con.Open();
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(dataTable);
                con.Close();
                List<string> department = new List<string>();
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        department.Add(dataRow["DepartmentName"].ToString());
                    }
                }
                department.Add("None");
                comboBoxDepartment.DataSource = department;
            }

            textboxName.Text = dataTable.Rows[0]["FirstName"].ToString();
            textboxSurname.Text = dataTable.Rows[0]["Surname"].ToString();
            DateTime birthDate = (DateTime)dataTable.Rows[0]["BirthDate"];
            datetimeBirth.Value = birthDate;
            textboxPesel.Text = dataTable.Rows[0]["Pesel"].ToString();
            textboxStreet.Text = dataTable.Rows[0]["Street"].ToString();
            if (dataTable.Rows[0]["Apartment"] != null)
            {
                textboxApt.Text = dataTable.Rows[0]["Apartment"].ToString();
            }
            textboxPost.Text = dataTable.Rows[0]["Postcode"].ToString();
            textboxCity.Text = dataTable.Rows[0]["City"].ToString();
            if(dataTable.Rows[0]["Department"] != DBNull.Value)
            {
                comboBoxDepartment.Text = dataTable.Rows[0]["Department"].ToString();
            }
            else
            {
                comboBoxDepartment.Text = "None";
            }       

            if(comboBoxDepartment.Text == "None")
            {
                comboBoxPermission.Enabled = false;
            }
            else
            {
                comboBoxPermission.Text = dataTable.Rows[0]["Permission"].ToString();
            }
            if (dataTable.Rows[0]["PhoneNumber"] != null)
            {
                textBoxPhone.Text = dataTable.Rows[0]["PhoneNumber"].ToString();
            }
            if(dataTable.Rows[0]["Email"] != null)
            {
                textBoxEmail.Text = dataTable.Rows[0]["Email"].ToString();
            }
            if((bool)dataTable.Rows[0]["PhoneVisible"] == true)
            {
                checkBoxPhone.Checked = true;
            }
            if ((bool)dataTable.Rows[0]["EmailVisible"] == true)
            {
                checkBoxEmail.Checked = true;
            }
        }

        static int controlSum(String str)
        {
            if (str == null)
            {
                return -1;
            }
            int sum = 9 * (str[0] - '0') + 7 * (str[1] - '0') + 3 * (str[2] - '0') + 1 * (str[3] - '0')
                    + 9 * (str[4] - '0') + 7 * (str[5] - '0') + 3 * (str[6] - '0') + 1 * (str[7] - '0')
                    + 9 * (str[8] - '0') + 7 * (str[9] - '0');

            sum = sum % 10;

            return sum;
        }

        private int validate(String pesel)
        {
           
            if (pesel.Length != 11)
            { 
                return (1);
            }
            bool isNumeric = long.TryParse(pesel, out _);
            if (isNumeric == false)
            { 
                return (2);
            }

            if (controlSum(pesel) != (pesel[10] - '0'))
                {
                    return (3);
                }

            return 0;
        }

        private int date(String pesel)
        {
            int year;

            if ((pesel[2] - '0') == 2 || (pesel[2] - '0') == 3)
            {
                year = 2000 + (pesel[0] - '0') * 10 + (pesel[1] - '0');
            }
            else if ((pesel[2] - '0') == 4 || (pesel[2] - '0') == 5)
            {
                year = 2100 + (pesel[0] - '0') * 10 + (pesel[1] - '0');
            }
            else if ((pesel[2] - '0') == 6 || (pesel[2] - '0') == 7)
            {
                year = 2200 + (pesel[0] - '0') * 10 + (pesel[1] - '0');
            }
            else if ((pesel[2] - '0') == 8 || (pesel[2] - '0') == 9)
            {
                year = 1800 + (pesel[0] - '0') * 10 + (pesel[1] - '0');
            }
            else
            {
                year = 1900 + (pesel[0] - '0') * 10 + (pesel[1] - '0');
            }

            int month;

            if (year >= 1800 && year <= 1899)
            {
                month = (pesel[2] - '0' - 8) * 10 + (pesel[3] - '0');
            }
            else if ((year >= 2000 && year <= 2099))
            {
                month = (pesel[2] - '0' - 2) * 10 + (pesel[3] - '0');
            }
            else if ((year >= 2100 && year <= 2199))
            {
                month = (pesel[2] - '0' - 4) * 10 + (pesel[3] - '0');
            }
            else if ((year >= 2200 && year <= 2299))
            {
                month = (pesel[2] - '0' - 6) * 10 + (pesel[3] - '0');
            }
            else
            {
                month = (pesel[2] - '0') * 10 + (pesel[3] - '0');
            }

            int day = (pesel[4] - '0') * 10 + (pesel[5] - '0');

            if (day > 31 || (day > 30 && (month == 4 || month == 6 || month == 9 || month == 11)) ||
                    (month == 2 && (((year % 4) != 0 && day > 28) || ((year % 4) == 0 && day > 29))) ||
                    day < 1 || month < 1 || month > 12)
            {
                return -1;
            }

            if (month < 10)
            {
                if (day < 10)
                {
                    dateCheck = "0" + day + ".0" + month + "." + year;
                }
                else
                {
                    dateCheck = day + ".0" + month + "." + year;
                }
            }
            else
            {
                if (day < 10)
                {
                    dateCheck = "0" + day + "." + month + "." + year;
                }
                else
                {
                    dateCheck = day + "." + month + "." + year;
                }
            }  
            dateCheck += " 00:00:00";
            return 0;
        }

        private string removeSymbols(string username)
        {
            var regexItem = new Regex("^[ę]*$");
            username = regexItem.Replace(username, "e");
            regexItem = new Regex("^[ó]*$");
            username = regexItem.Replace(username, "o");
            regexItem = new Regex("^[ą]*$");
            username = regexItem.Replace(username, "a");
            regexItem = new Regex("^[ś]*$");
            username = regexItem.Replace(username, "s");
            regexItem = new Regex("^[ł]*$");
            username = regexItem.Replace(username, "l");
            regexItem = new Regex("^[żź]*$");
            username = regexItem.Replace(username, "z");
            regexItem = new Regex("^[ć]*$");
            username = regexItem.Replace(username, "c");
            regexItem = new Regex("^[ń]*$");
            username = regexItem.Replace(username, "n");

            return username;
        }

        private string generatePassword()
        {
            string generatedPassword = "";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%&";
            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                generatedPassword = generatedPassword + chars[random.Next(chars.Length)];
            }
            return generatedPassword;
        }

        private void newEmployee()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmdCheck = new SqlCommand("SELECT * FROM employee WHERE Pesel = @pesel", con);
                cmdCheck.Parameters.AddWithValue("@pesel", textboxPesel.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmdCheck);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count != 0)
                {
                    MessageBox.Show("Employee already exists.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd;

                cmd = new SqlCommand("INSERT INTO EMPLOYEE(FirstName, Surname, BirthDate, Pesel, Street, Postcode, City, Apartment, Department, Permission," +
                        "               PhoneNumber, Email) " +
                        "               VALUES(@firstname, @surname, @birthdate, @pesel, @street, @postcode, @city, @apartment, @department, @permission," +
                        "               @phone, @email)", con);
                if (cmd != null)
                {
                    cmd.Parameters.AddWithValue("@firstname", textboxName.Text);
                    cmd.Parameters.AddWithValue("@surname", textboxSurname.Text);
                    cmd.Parameters.AddWithValue("@birthdate", datetimeBirth.Value.Date);
                    cmd.Parameters.AddWithValue("@pesel", textboxPesel.Text);
                    cmd.Parameters.AddWithValue("@street", textboxStreet.Text);
                    if (textboxApt.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@apartment", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@apartment", textboxApt.Text);
                    }

                    cmd.Parameters.AddWithValue("@postcode", textboxPost.Text);
                    cmd.Parameters.AddWithValue("@city", textboxCity.Text);
                    if (comboBoxDepartment.SelectedItem.ToString() != "None")
                    {
                        cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text);
                        cmd.Parameters.AddWithValue("@permission", comboBoxPermission.SelectedItem);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@department", DBNull.Value);
                        cmd.Parameters.AddWithValue("@permission", DBNull.Value);
                    }
                    if (textBoxEmail.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@email", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                    }
                    if (textBoxPhone.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@phone", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                    }
                    if (checkBoxPhone.Checked)
                    {
                        cmd.Parameters.AddWithValue("@phoneVisible", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@phoneVisible", 0);
                    }
                    if (checkBoxEmail.Checked)
                    {
                        cmd.Parameters.AddWithValue("@emailVisible", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@emailVisible", 0);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to add employee to database.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
                

                adapt = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapt.Fill(ds);

                con.Close();

                con = new SqlConnection(connString);
                cmd = new SqlCommand("SELECT COUNT(*) FROM employee", con);
                con.Open();
                count2 = (Int32)cmd.ExecuteScalar();
                con.Close();
                if (count1 + 1 == count2)
                {
                    cmd = new SqlCommand("Select EmployeeID FROM EMPLOYEE WHERE Pesel = @pesel", con);
                    cmd.Parameters.AddWithValue("@pesel", textboxPesel.Text);
                    con.Open();
                    Int32 empLoginID = (Int32)cmd.ExecuteScalar();
                    con.Close();
                    string username = textboxName.Text + textboxSurname.Text;
                    username = username.ToLower();
                    con.Open();
                    cmd = new SqlCommand("SELECT COUNT (*) FROM LOGIN WHERE Username = @username", con);
                    cmd.Parameters.AddWithValue("@username", username);
                    Int32 loginNumber = (Int32)cmd.ExecuteScalar();
                    con.Close();
                    if(loginNumber > 0)
                    {
                        username += loginNumber.ToString();
                    }
                    cmd = new SqlCommand("INSERT INTO LOGIN(Username, Pswrd, EmployeeID) VALUES (@username, @password,  " +
                        "(SELECT EmployeeID FROM EMPLOYEE WHERE EmployeeID = @empID))", con);
                    username = removeSymbols(username);
                    string password = generatePassword();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@empID", empLoginID);
                    con.Open();
                    cmd.BeginExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfuly added employee to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Login: " + username + "\nPassword: " + password + "\nCoppied to clipboard.", "Login credinals", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clipboard.SetText(username + "\n" +password);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add employee to database.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editEmployee()
        {
            try
            {
                SqlConnection con = new SqlConnection(connString);
                SqlCommand cmdCheck = new SqlCommand("SELECT * FROM employee WHERE Pesel = @pesel", con);
                cmdCheck.Parameters.AddWithValue("@pesel", textboxPesel.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmdCheck);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 1)
                {
                    MessageBox.Show("Duplicate PESEL number", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd;
                cmd = new SqlCommand("UPDATE EMPLOYEE SET FirstName = @firstname, Surname = @surname, BirthDate = @birthdate, Pesel = @pesel, Street = @street, " +
                    "Apartment = @apartment, Postcode = @postcode, City = @city, Department = @department, Permission = @permission, PhoneNumber = @phone, Email = @email, " +
                    "PhoneVisible = @phoneVisible, EmailVisible = @emailVisible" +
                    " WHERE EmployeeID = @employeeID", con);
                if (cmd != null)
                {
                    cmd.Parameters.AddWithValue("@firstname", textboxName.Text);
                    cmd.Parameters.AddWithValue("@surname", textboxSurname.Text);
                    cmd.Parameters.AddWithValue("@birthdate", datetimeBirth.Value.Date);
                    cmd.Parameters.AddWithValue("@pesel", textboxPesel.Text);
                    cmd.Parameters.AddWithValue("@street", textboxStreet.Text);
                    if(textboxApt.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@apartment", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@apartment", textboxApt.Text);
                    }

                    cmd.Parameters.AddWithValue("@postcode", textboxPost.Text);
                    cmd.Parameters.AddWithValue("@city", textboxCity.Text);
                    if (comboBoxDepartment.SelectedItem.ToString() != "None")
                    {
  
                        cmd.Parameters.AddWithValue("@department", comboBoxDepartment.Text);
                        cmd.Parameters.AddWithValue("@permission", comboBoxPermission.SelectedItem);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@department", DBNull.Value);
                        cmd.Parameters.AddWithValue("@permission", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    if(textBoxEmail.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@email", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                    }
                    if(textBoxPhone.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@phone", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                    }
                    if (checkBoxPhone.Checked)
                    {
                        cmd.Parameters.AddWithValue("@phoneVisible", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@phoneVisible", 0);
                    }
                    if (checkBoxEmail.Checked)
                    {
                        cmd.Parameters.AddWithValue("@emailVisible", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@emailVisible", 0);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to add employee to database.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                }
               
                adapt = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapt.Fill(ds);

                con.Close();
                
                MessageBox.Show("Successfuly edited employee !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool validateEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textboxName.Text == "" || textboxSurname.Text == "" || textboxPesel.Text == "" 
                || textboxCity.Text == "" || textboxPost.Text == "" || textboxStreet.Text == "")
            {
                MessageBox.Show("Please fill all boxes marked with *.");
                return;
            }

            if(date(textboxPesel.Text) != 0 || validate(textboxPesel.Text) != 0)
            {
                MessageBox.Show("Incorrect PESEL number or it does not match birth date.", "PESEL Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(!dateCheck.Equals(datetimeBirth.Value.Date.ToString()))
            {
                MessageBox.Show("Incorrect birth date.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(textBoxPhone.TextLength < 9 && textBoxPhone.TextLength != 0)
            {
                MessageBox.Show("Incorrect phone number.", "Phone number Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(validateEmail(textBoxEmail.Text) == false)
            {
                MessageBox.Show("Incorrect e-mail address.", "E-mail Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DateTime now = DateTime.Today;
            DateTime birthday = datetimeBirth.Value;
            int age = now.Year - birthday.Year;
            if(birthday > now.AddYears(-age))
            {
                age--;
            }

            if(age < 18)
            {
                MessageBox.Show("Empoyee under 18");
                return;
            }
            if(employeeID == -1)
            {
                newEmployee();
            }
            else
            {
                editEmployee();
            }
            
        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxDepartment.Text == "None")
            {
                comboBoxPermission.Enabled = false;
            }
            else if(dataTableUser.Rows[0]["Permission"].ToString() != "Manager")
            {
                comboBoxPermission.Enabled = true;
                comboBoxPermission.SelectedItem = "Employee";
            }
        }

        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this window?\nUnsubmitted changes will be lost.", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.Yes)
            {
                this.Close();
            } 
        }
    }
}
