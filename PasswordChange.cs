using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ManagementApp
{
    public partial class PasswordChange : Form
    {
        private string login, password, connString;
        public PasswordChange(string login, string password, string connString)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
            this.connString = connString;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxOldPass.Text == "" || textBoxNewPass.Text == "" || textBoxNewPass2.Text == "")
            {
                MessageBox.Show("Please, fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxOldPass.Text == textBoxNewPass.Text)
            {
                MessageBox.Show("New password can't be the same as old.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBoxNewPass.Text != textBoxNewPass2.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBoxOldPass.Text != password)
            {
                MessageBox.Show("Incorrect password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBoxNewPass.Text == textBoxNewPass2.Text)
            {
                var regexItem = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).*$");
                if (textBoxNewPass.Text.Length < 8)
                {
                    MessageBox.Show("Password is too short.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (regexItem.IsMatch(textBoxNewPass.Text))
                {
                    SqlCommand cmd;
                    SqlConnection con = new SqlConnection(connString);
                    try
                    {
                        cmd = new SqlCommand("UPDATE Login Set Pswrd = @password WHERE Username = @username and Pswrd = @passwordOld", con);
                        cmd.Parameters.AddWithValue("@password", textBoxNewPass.Text);
                        cmd.Parameters.AddWithValue("@username", login);
                        cmd.Parameters.AddWithValue("@passwordOld", password);
                        SqlCommand cmd2 = new SqlCommand("UPDATE Login Set LoginFlag = @loginFlag WHERE Username = @username and Pswrd = @password", con);
                        cmd2.Parameters.AddWithValue("@loginFlag", 1);
                        cmd2.Parameters.AddWithValue("@username", login);
                        cmd2.Parameters.AddWithValue("@password", textBoxNewPass.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("Password changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your password doesn't contain neccessary signs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
